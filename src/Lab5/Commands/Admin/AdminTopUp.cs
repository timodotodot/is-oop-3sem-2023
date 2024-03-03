using Itmo.ObjectOrientedProgramming.Abstraction;
using Itmo.ObjectOrientedProgramming.Models;

namespace Commands.Admin;

public class AdminTopUp : ICommand
{
    private IBankAccountRepository _repository;
    private string _account;
    private double _amountMoney;

    public AdminTopUp(IBankAccountRepository repository, string account, string amountMoney)
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
        var account = new BankAccount(_account, "1234", 1234);
        _repository.TopUpAccount(account, _amountMoney);
    }
}