using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLicenca.Model
{

    public class API
    {

        private Uri InitialURL = new Uri("http://localhost:8081/");
        private static String RequestURL { get; set; }
        public enum RequestType { POST, GET };
        private static FormUrlEncodedContent RequestData { get; set; }


        public async Task<string> handleAsync(RequestType type)
        {

            String result = string.Empty;

            switch (type)
            {
                case RequestType.POST:
                    try {  Debug.WriteLine("Dados enviados com a request: "+ RequestData); using (var client = new HttpClient()) { Uri url = new Uri(InitialURL + RequestURL); Debug.WriteLine("Request enviada para "+ url.ToString()); var response = await client.PostAsync(url, RequestData); response.EnsureSuccessStatusCode(); var content = await response.Content.ReadAsStringAsync();  result = content; } } catch(Exception E) { Debug.WriteLine("Erro!\n" + E.Message); }
                    break;

                case RequestType.GET:

                    break;

                default:
                    result = "Erro no tipo de requisição";
                    break;
            }
            return result;
        }

        public string test()
        {
            return API.MD5_Convert("123");
        }

        public async Task<bool> AuthenticateAsync(String user, String password)
        {
            try
            {
                API obj_api = new API();
                String passmd5 = API.MD5_Convert(password);

                RequestURL = "usuario/logar/";
                RequestData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("username", user),
                    new KeyValuePair<string, string>("password", password),
                });


                var result = await obj_api.handleAsync(RequestType.POST);
                var dataArray = JsonConvert.DeserializeObject<ApiResponse>(result);
                if (dataArray != null && dataArray.Status != "error")
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro:\n{ex.Message}");
            }
            return false;

        }


        public static string MD5_Convert(string input)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }


    }
}
