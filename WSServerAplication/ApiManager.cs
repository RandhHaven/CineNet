namespace WSServerAplication
{
    using CineEntity;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;

    public class ApiManager
    {
        public static Token GetTokenApiManager(string urlBase, string pathCertificate, string clientID, string clientSecret, string grantType)
        {
            Uri url = new Uri(urlBase);
            Token token = new Token();

            try
            {
                var certHandler = new WebRequestHandler();

                var certPath = pathCertificate;

                var certificate = new X509Certificate2(certPath);
                certHandler.ClientCertificates.Add(certificate);

                using (var client = new HttpClient(certHandler))
                {
                    var Content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("client_id", clientID),
                        new KeyValuePair<string, string>("client_secret", clientSecret),
                        new KeyValuePair<string, string>("grant_type", grantType)
                    });

                    var result = client.PostAsync(url, Content).Result;

                    if (result.IsSuccessStatusCode)
                    {
                        token = JsonConvert.DeserializeObject<Token>(result.Content.ReadAsStringAsync().Result);
                        token.estado = result.IsSuccessStatusCode;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return token;
        }

    }
}
