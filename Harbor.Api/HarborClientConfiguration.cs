using Harbor.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Harbor.Api
{
    public class HarborClientConfiguration
    {
        public Uri RegistryUri { get; internal set; }
        public Credentials Credentials { get; internal set; }
        public HarborClientConfiguration(Uri registryUri, Credentials credentials)
        {
            if(registryUri == null)
                throw new ArgumentNullException(nameof(registryUri));

            if(credentials == null)
                throw new ArgumentNullException(nameof(credentials));


            RegistryUri = registryUri;
            Credentials = credentials;
        }
        public HarborClient CreateClient()
        {
            return new HarborClient(this);
        }
    }
}
