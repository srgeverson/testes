using JWT;
using JWT.Algorithms;
using JWT.Exceptions;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Security.Cryptography;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace WebServiceWCF
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WebServiceWCF : IWebServiceWCF
    {
        private static string SECRET = ConfigurationManager.AppSettings["secret"];

        public UsuarioLogado Autenticar(UsuarioLogin usuarioLogin)
        {
            try
            {
                var extraHeaders = new Dictionary<string, object> { };
                var payload = new Dictionary<string, object> {
                    { "usuario", usuarioLogin.login },
                    { "roles", new int[] { } },
                    { "iat", 0 },
                    { "exp", DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds()}
                };
                var key = Convert.FromBase64String(SECRET);
                IJwtAlgorithm algorithm = new HMACSHA256Algorithm(); // symmetric
                IJsonSerializer serializer = new JsonNetSerializer();
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
                var token = encoder.Encode(extraHeaders, payload, key);

                return new UsuarioLogado() { Nome = usuarioLogin.login, Token = token };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TokenValidado Autorizar()
        {
            try
            {
                IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
                string token = request.Headers["Authorization"].Replace("Bearer ", "");
                IJsonSerializer serializer = new JsonNetSerializer();
                var provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtAlgorithm algorithm = new HMACSHA256Algorithm(); // symmetric
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);
                var key = Convert.FromBase64String(SECRET);
                return new TokenValidado() { StatusCode = 200, Mensagem = decoder.Decode(token, key, verify: true) };
            }
            catch (TokenNotYetValidException tnyvex)
            {
                return new TokenValidado() { StatusCode = 401, Mensagem = tnyvex.Message };
            }
            catch (TokenExpiredException teex)
            {
                return new TokenValidado() { StatusCode = 401, Mensagem = teex.Message };
            }
            catch (SignatureVerificationException svex)
            {
                return new TokenValidado() { StatusCode = 401, Mensagem = svex.Message };
            }
        }

        public string GerarMensagemDeBoasVindas(string nome)
        {
            return string.Format("Seja bem vindo {0}!", nome);
        }

        public Pessoa NomeESobreNome(string nome, string sobreNome)
        {
            return new Pessoa() { Nome = nome, SobreNome = sobreNome };
        }
    }
}
