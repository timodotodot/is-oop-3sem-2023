using Itmo.ObjectOrientedProgramming.Abstraction;
using Itmo.ObjectOrientedProgramming.Models;

namespace Commands.User;

public class CheckBalance : ICommand
{
    private IBankAccountRepository _repository;
    private BankAccount _bankAccount;

    public CheckBalance(IBankAccountRepository repository, BankAccount bankAccount)
    {
        _repository = repository;
        _bankAccount = bankAccount;
    }

    public void Execute()
    {
        _repository.ShowBalance(_bankAccount);
    }
}