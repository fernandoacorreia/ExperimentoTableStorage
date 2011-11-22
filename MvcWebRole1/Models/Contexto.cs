using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebRole1.Models
{
    public class Contexto : Microsoft.WindowsAzure.StorageClient.TableServiceContext
    {
        public Contexto(string baseAddress, Microsoft.WindowsAzure.StorageCredentials credentials)
            : base(baseAddress, credentials)
        { }

        public IQueryable<Contato> Contato
        {
            get
            {
                return this.CreateQuery<Contato>("Contato");
            }
        }
    }
}