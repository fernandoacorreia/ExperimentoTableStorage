using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebRole1.Models
{
    public class Contato : Microsoft.WindowsAzure.StorageClient.TableServiceEntity
    {
        public Contato()
        {
            PartitionKey = DateTime.UtcNow.ToString("MMddyyyy");
            RowKey = string.Format("{0:10}_{1}", DateTime.MaxValue.Ticks - DateTime.Now.Ticks, Guid.NewGuid());
        }

        public string Nome { get; set; }
        public string Telefone { get; set; }
        // REMOVER A LINHA ABAIXO PARA O PRIMEIRO TESTE
        public DateTime? Data{ get; set; }
    }
}