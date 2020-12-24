using System;
using System.Collections.Generic;
using System.Text;

namespace Harbor.Api.Models
{
    public class ProjectListParameters
    {
        public string ProjectName { get; set; }
        public bool IsPublic { get; set; }
        public string Owner { get; set; }
    }
}
