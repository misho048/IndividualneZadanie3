using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class CardModel 
    {
        /// <summary>
        /// holds data for Credit card
        /// </summary>
        public int ID { get; set; }
        public DateTime Validity { get; set; }
        public string Pin { get; set; }
        public string CardNumber { get; set; }
        public int Account_ID { get; set; }
        public bool IsValid { get; set; }


    }
}
