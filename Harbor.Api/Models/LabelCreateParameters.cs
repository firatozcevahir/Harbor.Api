using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Newtonsoft.Json;

namespace Harbor.Api.Models
{
    public class LabelCreateParameters
    {
        [JsonProperty("project_id")]
        public long ProjectId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonIgnore]
        public LabelScope Scope { get; set; }

        [JsonProperty("scope")]
        private string _scope
        {
            get
            {
                if (Scope == LabelScope.Global)
                    return "g";
                else
                {
                    return "p";
                }
            }
        }
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonIgnore]
        public LabelColor Color { get; set; }

        [JsonProperty("color")]
        private string _color
        {
            get
            {
                var color = Convert.ToString(Color.GetHashCode(), 16).ToUpper().PadLeft(6,'0');
                return $"#{color}";
            }
        }
    }

    public enum LabelColor
    {
        Black = 0x000000,
        Red = 0xC92100,
        Green = 0x48960C
    }

    public enum LabelScope
    {
        Global,
        Private
    }
}
