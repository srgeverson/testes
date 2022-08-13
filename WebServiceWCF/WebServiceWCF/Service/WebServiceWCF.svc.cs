using JWT;
using JWT.Algorithms;
using JWT.Exceptions;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace WebServiceWCF
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WebServiceWCF : IWebServiceWCF
    {
        private static string SECRET = ConfigurationManager.AppSettings["secret"];
        private static string EXPIRED = ConfigurationManager.AppSettings["expired"];

        public UsuarioLogado Autenticar(UsuarioLogin usuarioLogin)
        {
            try
            {
                if (string.IsNullOrEmpty(SECRET)) throw new Exception("Não foi encontrado a chave secreta de validação do token.");
                if (string.IsNullOrEmpty(EXPIRED)) throw new Exception("Não foi definido tempo de validação do token.");

                var extraHeaders = new Dictionary<string, object> { };
                var payload = new Dictionary<string, object> {
                    { "usuario", usuarioLogin.login },
                    { "roles", new int[] { } },
                    { "iat", 0 },
                    { "exp", DateTimeOffset.UtcNow.AddSeconds(Convert.ToDouble(EXPIRED)).ToUnixTimeSeconds()}
                };
                var key = Convert.FromBase64String(SECRET);
                IJwtAlgorithm algorithm = new HMACSHA256Algorithm(); // symmetric
                IJsonSerializer serializer = new JsonNetSerializer();
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
                var token = encoder.Encode(extraHeaders, payload, key);

                return new UsuarioLogado() { Nome = usuarioLogin.login, Token = token, Mensagem = "Usuário autorizado" };
            }
            catch (Exception ex) 
            {
                throw new WebFaultException<TokenValidado>(new TokenValidado() { StatusCode = 401, Mensagem = ex.Message }, HttpStatusCode.Unauthorized);
            }
        }

        public TokenValidado Autorizar()
        {
            try
            {
                string token = null;
                IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
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
            catch (TokenNotYetValidException tnyvex)
            {
                throw new WebFaultException<TokenValidado>(new TokenValidado() { StatusCode = 401, Mensagem = tnyvex.Message }, HttpStatusCode.Unauthorized);
            }
            catch (TokenExpiredException teex)
            {
                throw new WebFaultException<TokenValidado>(new TokenValidado() { StatusCode = 401, Mensagem = teex.Message }, HttpStatusCode.Unauthorized);
            }
            catch (SignatureVerificationException svex)
            {
                throw new WebFaultException<TokenValidado>(new TokenValidado() { StatusCode = 401, Mensagem = svex.Message }, HttpStatusCode.Unauthorized);
            }
            catch (Exception ex)
            {
                throw new WebFaultException<TokenValidado>(new TokenValidado() { StatusCode = 401, Mensagem = ex.Message }, HttpStatusCode.Unauthorized);
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
