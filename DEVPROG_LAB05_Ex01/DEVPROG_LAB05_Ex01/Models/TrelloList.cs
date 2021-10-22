using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DEVPROG_LAB05_Ex01.Models
{
    public class TrelloList
    {
        [JsonProperty(PropertyName = "id")]
        public string ListId { get; set; }
        public string Name { get; set; }
    }
}
