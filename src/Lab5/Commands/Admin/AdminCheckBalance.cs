using Itmo.ObjectOrientedProgramming.Abstraction;
using Itmo.ObjectOrientedProgramming.Models;

namespace Commands.Admin;

public class AdminCheckBalance : ICommand
{
    private IBankAccountRepository _repository;
    private string _bankAccount;

    public AdminCheckBalance(IBankAccountRepository repository, string bankAccount)
    {
        _repository = repository;
        _bankAccount = bankAccount;
    }

    public void Execute()
    {
        var account = new BankAccount(_bankAccount, "1234", 1234);
        _repository.ShowBalance(account);
    }
}