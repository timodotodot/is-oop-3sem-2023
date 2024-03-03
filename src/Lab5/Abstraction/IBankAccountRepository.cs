using Itmo.ObjectOrientedProgramming.Models;

namespace Itmo.ObjectOrientedProgramming.Abstraction;

public interface IBankAccountRepository
{
    BankAccount? FindBankAccount(string accountNumber, string pinCode);
    Admin? FindAdmin(string password);
    void CreateNewBankAccount(BankAccount bankAccount);
    void ShowBalance(BankAccount bankAccount);
    void TakeOffMoney(BankAccount bankAccount, double amountMoney);
    void TopUpAccount(BankAccount bankAccount, double amountMoney);
    void ShowHistoryOperation(BankAccount bankAccount);
}