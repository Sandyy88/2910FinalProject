using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo4.Helpers
{
    public class UserProfile
    {
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
