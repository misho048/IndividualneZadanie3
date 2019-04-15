using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class TransactionModel 
    {
        /// <summary>
        /// Holds data for Transaction Model 
        /// </summary>
        public int ID { get; set; }
        public string IDFrom { get; set; }
        public string IDTo{ get; set; }
        public DateTime Date { get; set; }
        public decimal Value{ get; set; }
        public string Type { get; set; }
        /// <summary>
        /// these symbols are not required so we give them some basic value
        /// 
        /// </summary>
        public string VariableSymbol { get; set; } = "";
        public string SpecificSymbol { get; set; } = "";
        public string ConstantSymbol { get; set; } = "";
        public string Message { get; set; } = "";
    }
}
