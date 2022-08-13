using JWT;
using JWT.Algorithms;
using JWT.Exceptions;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.ServiceModel.Activation;
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
                    { "exp", 0}
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

        public string Autorizar()
        {
            const string token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJjbGFpbTEiOjAsImNsYWltMiI6ImNsYWltMi12YWx1ZSJ9.8pwBI_HtXqI3UgQHQ_rDRnSQRxFL1SR8fbQoS-5kM5s";
            const string secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                var provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtAlgorithm algorithm = new HMACSHA256Algorithm(); // symmetric
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);

                return decoder.Decode(token, secret, verify: true);
            }
            catch (TokenExpiredException teex)
            {
                throw teex;
            }
            catch (SignatureVerificationException svex)
            {
               throw svex;
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
