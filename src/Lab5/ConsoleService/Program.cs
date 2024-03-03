using Commands;
using Commands.Admin;
using Commands.User;
using Itmo.ObjectOrientedProgramming.Abstraction;
using Itmo.ObjectOrientedProgramming.Models;
using Repositories;

namespace ConsoleService;

public static class Program
{
    public static void Main()
    {
        IBankAccountRepository repo =
            new PostgreSql("Host=localhost;Username=postgres;Password=EkUh231204;Database=Bank");
        var parser = new Handler();
        parser.RegisterCommand("create", args => new Commands.User.CreateNewBankAccount(args[0], args[1], repo));

        BankAccount? account;
        Admin? admin;

        string? mode = Console.ReadLine();
        switch (mode)
        {
            case "user":
                string? number = Console.ReadLine();
                string? pin = Console.ReadLine();

                if (number is null || pin is null)
                {
                    Console.WriteLine("Arg is missing");
                    return;
                }

                account = repo.FindBankAccount(number, pin);

                if (account is null)
                {
                    Console.WriteLine("Неправильный номер или пин-код");
                    return;
                }

                parser.RegisterCommand("balance", _ =>
                    new CheckBalance(repo, account));
                parser.RegisterCommand("take_off", args =>
                    new TakeOffMoney(repo, account, args[0]));
                parser.RegisterCommand("top_up", args =>
                    new TopUpAccount(repo, account, args[0]));
                parser.RegisterCommand("history", _ =>
                    new OperationHistory(repo, account));
                break;

            case "admin":
                string? password = Console.ReadLine();

                if (password is null)
                {
                    Console.WriteLine("Password is null");
                    return;
                }

                admin = repo.FindAdmin(password);

                if (admin is null)
                {
                    Console.WriteLine("Неверный пароль!!!!");
                    return;
                }

                parser.RegisterCommand("balance", args =>
                    new Commands.Admin.AdminCheckBalance(repo, args[0]));
                parser.RegisterCommand("take_off", args =>
                    new Commands.Admin.AdminTakeOff(repo, args[0], args[1]));
                parser.RegisterCommand("top_up", args =>
                    new AdminTopUp(repo, args[0], args[1]));
                parser.RegisterCommand("history", args =>
                    new AdminCheckOperationHistory(repo, args[0]));

                break;
            default:
                Console.WriteLine("Неправильный режим работы");
                break;
        }

        string? command = Console.ReadLine();

        if (command is not null)
        {
            string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            parser.ProcessCommand(commandArgs);
        }
    }
}