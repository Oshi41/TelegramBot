using System;
using System.IO;
using Microsoft.VisualStudio.Services.Client;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Tests.Tfs
{
    public class Base
    {
        class TfsSettings
        {
            public string Name { get; set; }
            public string Pass { get; set; }
            public string Link { get; set; }
        }        
        
        [Test]
        public void Connect()
        {
            var raw = File.ReadAllText("./Tfs/test.json");
            var obj = JsonConvert.DeserializeObject<TfsSettings>(raw);
            var uri = new Uri(obj.Link);

            var creds = new VssClientCredentials(new VssBasicCredential(obj.Name, obj.Pass));
            var connection = new VssConnection(uri, creds);
            
            Assert.IsNotNull(connection.AuthenticatedIdentity);
            Assert.IsTrue(connection.HasAuthenticated);
        }
    }
}