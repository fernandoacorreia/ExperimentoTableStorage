using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

namespace MvcWebRole1.Models
{
    public class DataSource
    {
        private static CloudStorageAccount storageAccount;
        public Contexto Contexto;

        static DataSource()
        {
            storageAccount = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
            CloudTableClient.CreateTablesFromModel(
                typeof(Contexto),
                storageAccount.TableEndpoint.AbsoluteUri,
                storageAccount.Credentials);
        }

        public DataSource()
        {
            this.Contexto = new Contexto(storageAccount.TableEndpoint.AbsoluteUri, storageAccount.Credentials);
            this.Contexto.RetryPolicy = RetryPolicies.Retry(3, TimeSpan.FromSeconds(1));
        }
    }
}