using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class TransactionModel : IModels
    {
        public int ID { get; set; }
        public int IDFrom { get; set; }
        public int IDTo{ get; set; }
        public DateTime Date { get; set; }
        public decimal Value{ get; set; }
        public string Type { get; set; }
    }
}
