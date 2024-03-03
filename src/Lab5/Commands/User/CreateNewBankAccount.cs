using Itmo.ObjectOrientedProgramming.Abstraction;
using Itmo.ObjectOrientedProgramming.Models;

namespace Commands.User;

public class CreateNewBankAccount : ICommand
{
    private IBankAccountRepository _repository;
    private string _bankAccount;
    private string _pin;

    public CreateNewBankAccount(string bankAccount, string pin, IBankAccountRepository repository)
    {
        _repository = repository;
        _bankAccount = bankAccount;
        _pin = pin;
    }

    public void Execute()
    {
        var bankAccount = new BankAccount(_bankAccount, _pin, 0);
        _repository.CreateNewBankAccount(bankAccount);
    }
}