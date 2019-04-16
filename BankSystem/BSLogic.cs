using Data;
using Data.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{/// <summary>
/// conncets repositaries methods with forms
/// </summary>
    public class BSLogic
    {
        /// <summary>
        /// creating instances of repositary
        /// </summary>
        AccountRepository accRepo = new AccountRepository();
        TransactionRepository transRepo = new TransactionRepository();
        UserRepository userRepo = new UserRepository();
        AddressRepository addressRepo = new AddressRepository();
        CardsRepository cardsRepo = new CardsRepository();
        ManagerOverview managerOverviews = new ManagerOverview();
        /// <summary>
        /// gets all transaction from repositary
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TransactionModel> GetTransactions()
        {
            return transRepo.GetTransactions();

        }
        /// <summary>
        /// methiod for generating reasons to life
        /// </summary>
        /// <returns></returns>
        public string GenerateIBAN()
        {
            Random random = new Random();
            string something = "SK";
            while (something.Length < 23)
            {
                something += $"{random.Next(0, 9)}";
            }


            return something;
        }

/// <summary>
/// creates userModel addressMOdel  and AccoutnMOdel 
/// and send them to reposiraries
/// </summary>
/// <param name="FirstName"></param>
/// <param name="LastName"></param>
/// <param name="IDCardNumber"></param>
/// <param name="PhoneNumber"></param>
/// <param name="Email"></param>
/// <param name="StreetName"></param>
/// <param name="HomeNumber"></param>
/// <param name="City"></param>
/// <param name="PostalCode"></param>
/// <param name="DebetLimit"></param>
        public void CreateUser(string FirstName, string LastName, string IDCardNumber, string PhoneNumber,
            string Email, string StreetName, int HomeNumber, string City, string PostalCode, decimal DebetLimit,string IBAN)
        {
            UserModel user = new UserModel
            {
                FirstName = FirstName,
                LastName = LastName,
                IDCardName = IDCardNumber,
                PhoneNumber = PhoneNumber,
                Email = Email
            };

            AddressModel address = new AddressModel
            {
                StreetName = StreetName,
                HomeNumber = HomeNumber,
                City = City,
                PostalCode = PostalCode
            };

            userRepo.CreateUser(user, addressRepo, address);

            AccountsModel acc = new AccountsModel();

            acc.Balance = 0;
            acc.DebtLimit = DebetLimit;
            acc.UserID = userRepo.GetLastID();
            acc.IBAN = IBAN;




            accRepo.CreateNewAccount(acc);


        }


        /// <summary>
        /// returns list of Users filtered by ID
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IEnumerable<UserModel> FilterUsersByIDCard(string filter)
        {
            return userRepo.GetUsersByIDCardList(filter);
        }

        /// <summary>
        /// gets all transactions done by user
        /// </summary>
        /// <param name="clientIdCard"></param>
        /// <returns></returns>
        public IEnumerable<TransactionModel> GetTransactionsByIdCard(string clientIdCard)
        {
            return transRepo.GetTransactionsByIDCard(clientIdCard);

        }

        /// <summary>
        /// create transactionmodel and calls specific transactions
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <param name="IBAN"></param>
        /// <param name="variableSymbol"></param>
        /// <param name="specificSymbol"></param>
        /// <param name="constantSymbol"></param>
        /// <param name="message"></param>
        /// <param name="clientIdCard"></param>
        public void SaveTransaction(decimal value, string type, string IBAN, string variableSymbol, string specificSymbol,
            string constantSymbol, string message, string clientIdCard)
        {
            TransactionModel transaction = new TransactionModel();
            transaction.Value = value;
            transaction.Type = type;
            transaction.VariableSymbol = variableSymbol;
            transaction.SpecificSymbol = specificSymbol;
            transaction.ConstantSymbol = constantSymbol;
            transaction.Message = message;


            if (type.Equals("Regular Transaction"))
            {
                transRepo.SaveRegularTransaction(transaction, clientIdCard, IBAN);

            }

            if (type.Contains("Deposit"))
            {
                transRepo.SaveTransactionDeposit(value, clientIdCard);
            }

            if (type.Contains("Withdraw"))
            {
                transRepo.SaveTransactionWithdraw(clientIdCard, value);
            }

        }

        /// <summary>
        /// return the list of all ibans from repositary
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllIbans()
        {
            return accRepo.GetAllIbans();
        }

        /// <summary>
        /// return Iban by Account ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetIbanbyAccountID(int id)
        {
            return accRepo.GetIbanByID(id);
        }

        /// <summary>
        /// return string list of data to update 
        /// </summary>
        /// <param name="clientIdCard"></param>
        /// <returns></returns>
        public string[] GetDataToUpdate(string clientIdCard)
        {
            return userRepo.GetDataForUpdate(clientIdCard);
        }

        /// <summary>
        /// create usermoder addressmodel and account mdoel and sends them to repositaries 
        /// </summary>
        /// <param name="dataToUpdate"></param>
        public void UpdateUserInfo(string[] dataToUpdate)
        {
            AddressModel address = new AddressModel
            {
                ID = Convert.ToInt32(dataToUpdate[6]),
                StreetName = dataToUpdate[8],
                HomeNumber = Convert.ToInt32(dataToUpdate[9]),
                City = dataToUpdate[10],
                PostalCode = dataToUpdate[11]
            };
            addressRepo.UpdateAddress(address);

            UserModel user = new UserModel
            {
                ID = Convert.ToInt32(dataToUpdate[0]),
                FirstName = dataToUpdate[1],
                LastName = dataToUpdate[2],
                IDCardName = dataToUpdate[3],
                PhoneNumber = dataToUpdate[4],
                Email = dataToUpdate[5]
            };
            userRepo.UpdateUser(user);

            AccountsModel account = new AccountsModel
            {
                DebtLimit = Convert.ToDecimal(dataToUpdate[13]),
                IBAN = dataToUpdate[12],

            };

            accRepo.UpdateAccount(account);



        }

        /// <summary>
        /// return the list of credit cards each user got 
        /// taken from repositoriues
        /// </summary>
        /// <param name="clientCardID"></param>
        /// <returns></returns>
        public IEnumerable<CardModel> GetCreditcardsByIDCard(string clientCardID)
        {
            return cardsRepo.GetCardsByClientCardID(clientCardID);

        }

        /// <summary>
        /// send data to repositories to create new creaditcard to the user
        /// </summary>
        /// <param name="clientCardID"></param>
        /// <param name="pin"></param>
        /// <param name="generatedNumber"></param>
        public void CreateNewCreditcard(string clientCardID, int pin, string generatedNumber)
        {
            cardsRepo.CreateNewCreditcard(clientCardID, pin, generatedNumber);
        }

        /// <summary>
        /// returns generated card number from repositories
        /// </summary>
        /// <returns></returns>
        public string GenerateCardNumber()
        {
            return cardsRepo.GenerateCreditCardNumber();
        }

        /// <summary>
        /// calls reset pin from repositary
        /// </summary>
        /// <param name="creditcardNumber"></param>
        /// <param name="pin"></param>

        public void ResetPin(string creditcardNumber, int pin)
        {
            cardsRepo.ChangePin(creditcardNumber, pin);
        }

        /// <summary>
        /// get balance from client based on IDcard from repositray
        /// </summary>
        /// <param name="clientIdCard"></param>
        /// <returns></returns>
        public decimal GetBalancebyClientIdCard(string clientIdCard)
        {
            return accRepo.GetBalanceByClientIdCard(clientIdCard);
        }
        /// <summary>
        /// Gets dataset from repositary
        /// </summary>
        /// <returns></returns>
        public DataSet GetDSforAccounts()
        {
            return accRepo.FillDataSet();
        }
        /// <summary>
        /// return ID card froma  IBAN
        /// </summary>
        /// <param name="iban"></param>
        /// <returns></returns>
        public string GetIdCardByIban(string iban)
        {
            return accRepo.GetUserCardIdbyIban(iban);
        }
        #region managerOverview
        /// <summary>
        /// Gets top clients for amanager overview
        /// </summary>
        /// <returns></returns>
        public DataSet GetTopClients()
        {
            return managerOverviews.GetTopTenClients();
        }

        /// <summary>
        /// gets dataset of all bank assets for manager overview
        /// </summary>
        /// <returns></returns>
        public DataSet GetBankAssets()
        {
            return managerOverviews.GetBankAssets();
        }

        /// <summary>
        /// gets avvoutn count number for amanager overview
        /// </summary>
        /// <returns></returns>
        public DataSet GetAccountsCount()
        {
            return managerOverviews.GetAccountsCount();
        }

        /// <summary>
        /// gets account count in months for manager overview
        /// </summary>
        /// <returns></returns>
        public DataSet GetAccountsCountForMonth()
        {
            return managerOverviews.GetAccountsCountForMonth();
        }

        /// <summary>
        /// get ordered acitues by a account count in cititues
        /// </summary>
        /// <returns></returns>
        public DataSet GetDemography()
        {
            return managerOverviews.GetDemography();
        }
        #endregion

        /// <summary>
        /// gets FIltered account form repositary
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="filterWord"></param>
        /// <returns></returns>
        public DataSet GetFilteredAccounts(string filter, string filterWord)
        {
            return accRepo.FilterDataAccounts(filter, filterWord);
        }

        public bool CloseAccount(string cardNumber)
        {
            if (GetBalancebyClientIdCard(cardNumber) == 0)
            {

                accRepo.CloseAccount(cardNumber);
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// block or unblock card, always change the value
        /// </summary>
        /// <param name="creditCardNumber"></param>

        public void BlockUnblockCard(string creditCardNumber)
        {
            cardsRepo.BlockUnblockCard(creditCardNumber);
        }

        public bool IsThereAnyCards(string CLientIdCard)
        {
            if (cardsRepo.GetAcitiveCardsCount(CLientIdCard) == 0)
            {
                return false;
            }

            else
            {
                return true;
            }
        }
        /// <summary>
        /// checks if the balance is good enought to make a transaction
        /// </summary>
        /// <param name="CLientIdCard"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool IsTransactionPossible (string CLientIdCard,decimal value)
        {
            decimal debetLimit = Convert.ToDecimal(GetDataToUpdate(CLientIdCard)[13]);
            decimal balance = GetBalancebyClientIdCard(CLientIdCard);

            if (value > (balance + debetLimit))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}


