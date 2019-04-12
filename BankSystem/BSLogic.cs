using Data.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
   public  class BSLogic
    {
        AccountRepository accRepo = new AccountRepository();
        TransactionRepository transRepo = new TransactionRepository();
        UserRepository userRepo = new UserRepository();
        AddressRepository addressRepo = new AddressRepository();

        public IEnumerable<TransactionModel> GetTransactions()
        {
            return transRepo.GetTransactions();
        }

        public string GenerateIBAN()
        {
            Random random = new Random();
            string something = "SK";
            while (something.Length<24)
            {
                something += $"{random.Next(0, 9)}";
            }
            

            return something;
        }


        public void CreateUser(string FirstName, string LastName, string IDCardNumber,string PhoneNumber,
            string Email,string StreetName, int HomeNumber, string City, string PostalCode,decimal DebetLimit)
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

       
    }

}
