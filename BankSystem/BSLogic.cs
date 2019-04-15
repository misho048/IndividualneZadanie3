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
{
    public class BSLogic
    {
        
        AccountRepository accRepo = new AccountRepository();
        TransactionRepository transRepo = new TransactionRepository();
        UserRepository userRepo = new UserRepository();
        AddressRepository addressRepo = new AddressRepository();
        CardsRepository cardsRepo = new CardsRepository();
        ManagerOverview managerOverviews = new ManagerOverview();

        public IEnumerable<TransactionModel> GetTransactions()
        {
            return transRepo.GetTransactions();

        }

        public string GenerateIBAN()
        {
            Random random = new Random();
            string something = "SK";
            while (something.Length < 24)
            {
                something += $"{random.Next(0, 9)}";
            }


            return something;
        }


        public void CreateUser(string FirstName, string LastName, string IDCardNumber, string PhoneNumber,
            string Email, string StreetName, int HomeNumber, string City, string PostalCode, decimal DebetLimit)
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
            acc.DebtLimit = 0;
            acc.UserID = userRepo.GetLastID();
            acc.IBAN = GenerateIBAN();




            accRepo.CreateNewAccount(acc);


        }


        public IEnumerable<UserModel> FilterUsersByIDCard(string filter)
        {
            return userRepo.GetUsersByIDCardList(filter);
        }

        public IEnumerable<TransactionModel> GetTransactionsByIdCard(string clientIdCard)
        {
            return transRepo.GetTransactionsByIDCard(clientIdCard);

        }

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


        public string GetIbanbyAccountID(int id)
        {
            return accRepo.GetIbanByID(id);
        }

        public string[] GetDataToUpdate(string clientIdCard)
        {
            return userRepo.GetDataForUpdate(clientIdCard);
        }

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

        public IEnumerable<CardModel> GetCreditcardsByIDCard(string clientCardID)
        {
            return cardsRepo.GetCardsByClientCardID(clientCardID);

        }

        public void CreateNewCreditcard(string clientCardID, int pin, string generatedNumber)
        {
            cardsRepo.CreateNewCreditcard(clientCardID, pin, generatedNumber);
        }

        public string GenerateCardNumber()
        {
            return cardsRepo.GenerateCreditCardNumber();
        }

        public void ResetPin(string creditcardNumber, int pin)
        {
            cardsRepo.ChangePin(creditcardNumber, pin);
        }

        public decimal GetBalancebyClientIdCard(string clientIdCard)
        {
            return accRepo.GetBalanceByClientIdCard(clientIdCard);
        }

        public DataSet GetDSforAccounts()
        {
            return accRepo.FillDataSet();
        }

        public string GetIdCardByIban(string iban)
        {
            return accRepo.GetUserCardIdbyIban(iban);
        }
        #region managerOverview
        public DataSet GetTopClients()
        {
            return managerOverviews.GetTopTenClients();
        }

        public DataSet GetBankAssets()
        {
            return managerOverviews.GetBankAssets();
        }

        public DataSet GetAccountsCount()
        {
            return managerOverviews.GetAccountsCount();
        }

        public DataSet GetAccountsCountForMonth()
        {
            return managerOverviews.GetAccountsCountForMonth();
        }

        public DataSet GetDemography()
        {
            return managerOverviews.GetDemography();
        }
        #endregion

        public DataSet GetFilteredAccounts(string filter, string filterWord)
        {
            return accRepo.FilterDataAccounts(filter,filterWord);
        }

        public bool CloseAccount (string cardNumber)
        {
            if (GetBalancebyClientIdCard(cardNumber) == 0)
            {

                accRepo.CloseAccount(cardNumber);
                return true;
            }
            else {
                return false;
            }
               
        }
    }

}
