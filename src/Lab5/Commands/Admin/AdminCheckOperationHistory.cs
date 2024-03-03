using Itmo.ObjectOrientedProgramming.Abstraction;
using Itmo.ObjectOrientedProgramming.Models;

namespace Commands.Admin;

public class AdminCheckOperationHistory : ICommand
{
    private IBankAccountRepository _repository;
    private string _account;

    public AdminCheckOperationHistory(IBankAccountRepository repository, string account)
    {
        _repository = repository;
        _account = account;
    }

    public void Execute()
    {
        var account = new BankAccount(_account, "1234", 0);
        _repository.ShowHistoryOperation(account);
    }
}