using Inlämning1.WebUI.Models;
using System;
using Xunit;

namespace Inlämning1.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Withdraw()
        {
            //Arrange
            var account = new Account { Balance = 5234.234M, AccountID = 4 };
            var repo = new BankRepository();
            var expectedBalance = 5034.234M;
            //Act
            repo.Withdraw(200, account);
            //Assert
            Assert.Equal(expectedBalance, account.Balance);
        }

        [Fact]
        public void Deposit()
        {
            //Arrange
            var account = new Account { Balance = 1334.584M, AccountID = 5 };
            var repo = new BankRepository();
            var expectedBalance = 1534.584M;
            //Act
            repo.Deposit(200, account);
            //Assert
            Assert.Equal(expectedBalance, account.Balance);
        }
        
        [Fact]
        public void WithdrawTooMuch()
        {
            //Arrange
            var account = new Account { Balance = 20 };
            var repo = new BankRepository();
            decimal withdrawAmount = 2000M;
            //Assert & Act
            Assert.Throws<ArgumentOutOfRangeException>(() => repo.Withdraw(withdrawAmount, account));
        }
    }
}
