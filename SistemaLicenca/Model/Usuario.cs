using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLicenca.Model
{

    public class ApiResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public List<Usuario> Message { get; set; }
    }
    public class Usuario
    {
            [JsonProperty("id")]
            public string id { get; set; }

            [JsonProperty("username")]
            public string username { get; set; }

            [JsonProperty("password")]
            public string password { get; set; }

            [JsonProperty("expiration")]
            public object expiration { get; set; } 
    }
}
