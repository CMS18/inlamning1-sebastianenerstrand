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

        [Fact]
        public void Transfer()
        {
            //Arrange
            var amountToTransfer = 100m;
            var accountFrom = new Account { Balance = 225.5m, AccountID = 1};
            var accountTo = new Account { Balance = 10m, AccountID = 2};

            //Assert
            accountFrom.Transfer(accountFrom, accountTo, amountToTransfer);

            //Assert
            Assert.Equal(225.5m-amountToTransfer, accountFrom.Balance);
            Assert.Equal(10m + amountToTransfer, accountTo.Balance);
        }

        [Fact]
        public void TransferAmountOVerZero()
        {
            //Arrange
            var amountToTransfer = 101m;
            var accountFrom = new Account { Balance = 100m, AccountID = 1 };
            var accountTo = new Account { Balance = 10m, AccountID = 2 };

            //Act and assert
            Assert.Throws<ArgumentOutOfRangeException>(() => accountFrom.Transfer(accountFrom, accountTo, amountToTransfer));
        }
    }
}
