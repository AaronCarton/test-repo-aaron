using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DEVPROG_LAB05_Ex01.Models
{
    public class TrelloBoard
    {
        [JsonProperty(PropertyName = "id")]
        public string BoardId { get; set; }
        public string Name { get; set; }
        [JsonProperty(PropertyName = "starred")]
        public bool IsFavorite { get; set; }
    }
}
