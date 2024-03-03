using Itmo.ObjectOrientedProgramming.Abstraction;
using Itmo.ObjectOrientedProgramming.Models;

namespace Commands.User;

public class TopUpAccount : ICommand
{
    private IBankAccountRepository _repository;
    private BankAccount _account;
    private double _amountMoney;

    public TopUpAccount(IBankAccountRepository repository, BankAccount account, string amountMoney)
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
        _repository.TopUpAccount(_account, _amountMoney);
    }
}