using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
   public class AddressModel 
    {
        /// <summary>
        /// model to hold data for a Adress
        /// </summary>
        public int ID { get; set; }
        public string StreetName { get; set; }
        public int HomeNumber { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}
