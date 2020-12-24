using System;
using System.Collections.Generic;
using System.Text;

namespace Harbor.Api.Models
{
    public class TagListParameters
    {
        public string ProjectName { get; set; }
        public string RepositoryName { get; set; }
        public string Reference { get; set; }
        public bool WithSignature { get; set; } = false;
        public bool WithImmutableStatus { get; set; } = false;
    }
}
