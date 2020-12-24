using System;
using System.Collections.Generic;
using System.Text;

namespace Harbor.Api
{
    public interface IHarborClient
    {
        HarborClientConfiguration Configuration { get; }
    }
}
