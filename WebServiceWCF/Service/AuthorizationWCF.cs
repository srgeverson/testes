using AppClassLibraryDomain.model;
using AppClassLibraryDomain.service;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Web;
using BCryptNet = BCrypt.Net.BCrypt;

namespace WebServiceWCF.Service
{
    public class AuthorizationWCF
    {
        private static string SECRET = ConfigurationManager.AppSettings["secret"];
        private static string EXPIRED = ConfigurationManager.AppSettings["expired"];

        public UsuarioLogado gerarToken(Usuario usuario, UsuarioLogin usuarioLogin, PermissaoService permissaoService)
        {
            if (!BCryptNet.Verify(usuarioLogin.senha, usuario.Senha)) throw new Exception("Senha inválida!");

            if (string.IsNullOrEmpty(SECRET)) throw new Exception("Não foi encontrado a chave secreta de validação do token.");
            if (string.IsNullOrEmpty(EXPIRED)) throw new Exception("Não foi definido tempo de validação do token.");

            int[] permissoesId = permissaoService.PermissoesPorEmail(usuarioLogin.login)
                .Select(permissao => permissao.Id)
                .ToList()
                .ConvertAll(x => x.Value)
                .ToArray();
            var utcNow = DateTimeOffset.UtcNow;
            var extraHeaders = new Dictionary<string, object> { };
            var payload = new Dictionary<string, object> {
                    { "sub", usuario.Id }, //(subject) = Entidade à quem o token pertence, normalmente o ID do usuário;
                    { "iss", Assembly.GetExecutingAssembly().GetName().Name }, //(issuer) = Emissor do token;
                    { "roles", permissoesId },
                    { "name", usuario.Nome },
                    { "iat", utcNow.ToUnixTimeSeconds() }, //(issued at) = Timestamp de quando o token foi criado;
                    { "exp", utcNow.AddSeconds(Convert.ToDouble(EXPIRED)).ToUnixTimeSeconds()}, // (expiration) = Timestamp de quando o token irá expirar;
                    { "aud", "AppGenérico" } //(audience) = Destinatário do token, representa a aplicação que irá usá-lo.
                };
            var key = Convert.FromBase64String(SECRET);
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm(); // symmetric
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            var token = encoder.Encode(extraHeaders, payload, key);

            return new UsuarioLogado() { Nome = usuarioLogin.login, Token = token, Mensagem = "Usuário autorizado" };
        }

        public TokenValidado validarToken(IncomingWebRequestContext request)
        {
            string token = null;
            try
            {
                token = request.Headers["Authorization"].ToString().Replace("Bearer", "").Trim();

                if (string.IsNullOrEmpty(token)) throw new Exception("Token não encontrado!");
            }
            catch (NullReferenceException) { throw new Exception("Não foi encotrado um tipo de autorização!"); }
            catch (Exception ex) { throw ex; }

            IJsonSerializer serializer = new JsonNetSerializer();
            var provider = new UtcDateTimeProvider();
            IJwtValidator validator = new JwtValidator(serializer, provider);
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm(); // symmetric
            IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);
            var key = Convert.FromBase64String(SECRET);
            return new TokenValidado()
            {
                StatusCode = 200,
                Mensagem = string.IsNullOrEmpty(decoder.Decode(token, key, verify: true)) ? string.Empty : "Token válido!"
            };
        }
    }
}