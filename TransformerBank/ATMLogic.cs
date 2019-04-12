using Data.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformerBank
{
    public class ATMLogic
    {
        AccountRepository AccRepo = new AccountRepository();
        TransactionRepository TransRepo = new TransactionRepository();

        public AccountsModel GetBalance(string cardNumber)
        {
            
            return AccRepo.GetAccountsByCard(cardNumber);
        }

        public string OwnerNameByCardNumber(string cardNumber)
        {
            return AccRepo.GetAccountOwnerName(cardNumber);
        }

        public void AddWithdrawTransaction (decimal Value,string cardNumber)
        {
            TransactionModel model = new TransactionModel();

            model.IDFrom = AccRepo.SelectAccountIDByCard(cardNumber);
            model.IDTo = model.IDFrom;
            model.Value = Value;
            model.Type = "Withdraw";
            AccRepo.MakeWithdraw(cardNumber, Value);
            TransRepo.SaveTransaction(model);
        }


    }
}
