using System;
using System.Collections.Generic;
using System.Text;

namespace Harbor.Api.Models
{
    public class ArtifactListParameters
    {
        public string ProjectName { get; set; }
        public string RepositoryName { get; set; }
        public bool WithTag { get; set; } = true;
        public bool WithLabel { get; set; }
        public bool WithScanOverview { get; set; }
        public bool WithSignature { get; set; }
        public bool WithImmutableStatus { get; set; }

    }
}
