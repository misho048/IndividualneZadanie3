using Data.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformerBank
{/// <summary>
/// this class makes all the instances and most of the computing for ATM 
/// </summary>
    public class ATMLogic
    {
        /// <summary>
        /// creates instances of repositories
        /// </summary>
        AccountRepository AccRepo = new AccountRepository();
        TransactionRepository TransRepo = new TransactionRepository();
        CardsRepository cardsRepo = new CardsRepository();
        /// <summary>
        /// counting bad attempts to login with specific card
        /// </summary>
        private Dictionary<string, int> badAttemptsCount = new Dictionary<string, int>();

        /// <summary>
        /// returns Balance on the accoutn by credit card number
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        public AccountsModel GetBalance(string cardNumber)
        {

            return AccRepo.GetAccountsByCard(cardNumber);
        }

        /// <summary>
        /// returns Name of the account owner base d on credit card number
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        public string OwnerNameByCardNumber(string cardNumber)
        {
            return AccRepo.GetAccountOwnerName(cardNumber);
        }

        /// <summary>
        /// method for withdrawing money from the account
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        public bool AddWithdrawTransaction(decimal value, string cardNumber)
        {
            TransactionModel model = new TransactionModel();

            model.IDFrom = AccRepo.SelectAccountIDByCard(cardNumber).ToString();
            model.IDTo = model.IDFrom;
            model.Value = value;
            model.Type = "Withdraw";

            if (AccRepo.IsPossibleCreditCard(value, cardNumber))
            {
                TransRepo.SaveTransactionWithdraw(AccRepo.SelectAccountIDByCard(cardNumber), value);
                return true;
            }
            else return false;
            
        }

        /// <summary>
        /// method for checking pin
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <param name="pin"></param>
        /// <returns></returns>
        public bool CheckPin(string cardNumber, int pin)
        {
            return cardsRepo.CheckPin(cardNumber, pin);
        }

        /// <summary>
        /// method for chceking card, if is not blocked, if the login is right
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        public string CheckCard(string cardNumber)
        {
            List<CardModel> cardList = new List<CardModel>(cardsRepo.GetCards());
            foreach (var item in cardList)
            {
                if ((item.CardNumber.Equals(cardNumber)) && item.IsValid.Equals(true))
                {
                    return "Good";
                }
                else if ((item.CardNumber.Equals(cardNumber)) && (!item.IsValid.Equals(true)))
                {
                    return "Blocked";
                }

            }

            return "WrongLogin";

        }

        /// <summary>
        /// reset bad attempts on the card 
        /// its called when the login and password matchs
        /// </summary>
        /// <param name="cardName"></param>
        public void ResetBadAttempts(string cardName)
        {
            badAttemptsCount[cardName] = 0;
        }

        /// <summary>
        /// when bad login attempt happend this method is called and increase count 
        /// if the count hits 3 card is blocked
        /// </summary>
        /// <param name="cardName"></param>
        /// <returns></returns>
        public bool AddBadAttempt(string cardName)
        {
            if (!badAttemptsCount.Keys.Contains(cardName))
            {
                badAttemptsCount.Add(cardName, 1);
            }
            else
            {
                badAttemptsCount[cardName]++;
            }
            if (badAttemptsCount[cardName] == 3)
            {
                cardsRepo.BlockUnblockCard(cardName);
                return false;
            }
            ///in case we reset the card
            else if (badAttemptsCount[cardName] > 3)
            {
                ResetBadAttempts(cardName);
            }
            return true;

        }




    }
}
