using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class AccountsModel : IModels
    {
        public int ID { get; set; }
        public string IBAN { get; set; }
        public decimal Balance { get; set; }
        public decimal DebtLimit { get; set; }
        public int UserID { get; set; }
    }
}
