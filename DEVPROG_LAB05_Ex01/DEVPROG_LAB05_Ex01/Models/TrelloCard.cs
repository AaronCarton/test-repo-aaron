using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DEVPROG_LAB05_Ex01.Models
{
    public class TrelloCard
    {
        [JsonProperty(PropertyName = "id")]
        public string CardId { get; set; }
        public string Name { get; set; }
        [JsonProperty(PropertyName = "closed")]
        public bool IsClosed { get; set; }

    }
}
