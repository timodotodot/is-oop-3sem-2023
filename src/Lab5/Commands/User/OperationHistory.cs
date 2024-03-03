using Itmo.ObjectOrientedProgramming.Abstraction;
using Itmo.ObjectOrientedProgramming.Models;

namespace Commands.User;

public class OperationHistory : ICommand
{
    private IBankAccountRepository _repository;
    private BankAccount _account;

    public OperationHistory(IBankAccountRepository repository, BankAccount account)
    {
        _repository = repository;
        _account = account;
    }

    public void Execute()
    {
        _repository.ShowHistoryOperation(_account);
    }
}