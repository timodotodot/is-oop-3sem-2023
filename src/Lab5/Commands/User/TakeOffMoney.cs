using Itmo.ObjectOrientedProgramming.Abstraction;
using Itmo.ObjectOrientedProgramming.Models;

namespace Commands.User;

public class TakeOffMoney : ICommand
{
    private IBankAccountRepository _repository;
    private BankAccount _account;
    private double _amountMoney;

    public TakeOffMoney(IBankAccountRepository repository, BankAccount account, string amountMoney)
    {
        _repository = repository;
        _account = account;

        if (double.TryParse(amountMoney, out double doubleValue))
        {
            _amountMoney = doubleValue;
        }
    }

    public void Execute()
    {
        _repository.TakeOffMoney(_account, _amountMoney);
    }
}