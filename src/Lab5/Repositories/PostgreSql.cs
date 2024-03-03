using Itmo.ObjectOrientedProgramming.Abstraction;
using Itmo.ObjectOrientedProgramming.Models;
using Npgsql;

namespace Repositories;

public class PostgreSql : IBankAccountRepository
{
    private readonly string _connection;

    public PostgreSql(string connection)
    {
        _connection = connection;
    }

    public BankAccount? FindBankAccount(string accountNumber, string pinCode)
    {
        const string sql = """
                           SELECT *
                           FROM "BankAccounts"
                           WHERE "Bank_Accounts" = @AccountNumber AND "PIN" = @PinCode
                           """;

        using (var connection = new NpgsqlConnection(_connection))
        {
            connection.Open();

            using (var command = new NpgsqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@AccountNumber", accountNumber);
                command.Parameters.AddWithValue("@PinCode", pinCode);

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read() is false)
                    {
                        return null;
                    }

                    string bankAccount = reader.GetString(0);
                    string pin = reader.GetString(1);
                    double balance = reader.GetDouble(2);

                    return new BankAccount(
                        AccountNumber: bankAccount,
                        PinCode: pin,
                        Balance: balance);
                }
            }
        }
    }

    public Admin? FindAdmin(string password)
    {
        const string sql = """
                           SELECT *
                           FROM "Admins"
                           WHERE "Password" = @Password
                           """;

        using (var connection = new NpgsqlConnection(_connection))
        {
            connection.Open();

            using (var command = new NpgsqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Password", password);

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read() is false)
                    {
                        return null;
                    }

                    string passvord = reader.GetString(1);
                    int id = reader.GetInt32(0);

                    return new Admin(
                        Id: id,
                        Password: passvord);
                }
            }
        }
    }

    public void CreateNewBankAccount(BankAccount bankAccount)
    {
        if (bankAccount is null)
        {
            Console.WriteLine("Вы не авторизовались");
            return;
        }

        const decimal startBalance = 0;
        const string sql = """
                           INSERT INTO "BankAccounts" ("Bank_Accounts", "PIN", "Balance")
                           VALUES (@AccountNumber, @PinCode, @Balance)
                           """;

        using (var connection = new NpgsqlConnection(_connection))
        {
            connection.Open();

            using (var command = new NpgsqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@AccountNumber", bankAccount.AccountNumber);
                command.Parameters.AddWithValue("@PinCode", bankAccount.PinCode);
                command.Parameters.AddWithValue("@Balance", startBalance);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Новый счет успешно создан.");
                }
                else
                {
                    Console.WriteLine("Ошибка при создании счета.");
                }
            }
        }
    }

    public void ShowBalance(BankAccount bankAccount)
    {
        if (bankAccount is null)
        {
            Console.WriteLine("Вы не авторизовались");
            return;
        }

        const string sql = """
                           SELECT *
                           FROM "BankAccounts"
                           WHERE "Bank_Accounts" = @BankAccount
                           """;

        using (var connection = new NpgsqlConnection(_connection))
        {
            connection.Open();

            using (var command = new NpgsqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@BankAccount", bankAccount.AccountNumber);

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read() is false)
                    {
                        Console.WriteLine("Неправильный номер счета или пин-код");
                        return;
                    }

                    double balance = reader.GetDouble(2);
                    Console.WriteLine($"Ваш баланс: {balance} RUB");
                }
            }
        }
    }

    public void TakeOffMoney(BankAccount bankAccount, double amountMoney)
    {
        if (bankAccount is null)
        {
            Console.WriteLine("Вы не авторизовались");
            return;
        }

        if (!BalanceCheck(bankAccount, amountMoney))
        {
            Console.WriteLine("На балансе недостаточно денег для снятия");
            return;
        }

        const string sql = """
                           UPDATE "BankAccounts" 
                           SET "Balance" = "Balance" - @AmountMoney 
                           WHERE "Bank_Accounts" = @BankAccount;
                           """;

        using (var connection = new NpgsqlConnection(_connection))
        {
            connection.Open();

            using (var command = new NpgsqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@AmountMoney", amountMoney);
                command.Parameters.AddWithValue("@BankAccount", bankAccount.AccountNumber);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine($"Вы сняли {amountMoney} RUB со счета");
                    AddOperationHistory(bankAccount, amountMoney, "-");
                }
                else
                {
                    Console.WriteLine($"Ошибка при вычитании суммы со счета или счет не найден.");
                }
            }
        }
    }

    public void TopUpAccount(BankAccount bankAccount, double amountMoney)
    {
        if (bankAccount is null)
        {
            Console.WriteLine("Вы не авторизовались");
            return;
        }

        const string sql = """
                           UPDATE "BankAccounts"
                           SET "Balance" = "Balance" + @AmountMoney
                           WHERE "Bank_Accounts" = @BankAccount;
                           """;

        using (var connection = new NpgsqlConnection(_connection))
        {
            connection.Open();

            using (var command = new NpgsqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@AmountMoney", amountMoney);
                command.Parameters.AddWithValue("@BankAccount", bankAccount.AccountNumber);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine($"Вы пополнили счет на {amountMoney} RUB");
                    AddOperationHistory(bankAccount, amountMoney, "+");
                }
                else
                {
                    Console.WriteLine($"Ошибка при вычитании суммы со счета или счет не найден.");
                }
            }
        }
    }

    public void ShowHistoryOperation(BankAccount bankAccount)
    {
        if (bankAccount is null)
        {
            Console.WriteLine("Вы не авторизовались");
            return;
        }

        using (var connection = new NpgsqlConnection(_connection))
        {
            connection.Open();

            const string sql = """
                               SELECT *
                               FROM "OperationHistory"
                               WHERE "Bank_Account" = @BankAccount
                               """;

            using (var command = new NpgsqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@BankAccount", bankAccount.AccountNumber);

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("История операций:");

                    while (reader.Read())
                    {
                        string accountNumber = reader.GetString(0);
                        string amount = reader.GetString(1);
                        DateTime transactionDate = reader.GetDateTime(2);

                        Console.WriteLine($"{accountNumber} | {amount} RUB | {transactionDate}");
                    }
                }
            }
        }
    }

    private bool BalanceCheck(BankAccount bankAccount, double amountMoney)
    {
        if (bankAccount is null)
        {
            Console.WriteLine("Вы не авторизовались");
            return false;
        }

        const string sql = """
                           SELECT *
                           FROM "BankAccounts"
                           WHERE "Bank_Accounts" = @BankAccount
                           """;

        using (var connection = new NpgsqlConnection(_connection))
        {
            connection.Open();

            using (var command = new NpgsqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@BankAccount", bankAccount.AccountNumber);

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read() is false)
                    {
                        return false;
                    }

                    double currentBalance = reader.GetDouble(2);
                    return currentBalance >= amountMoney;
                }
            }
        }
    }

    private void AddOperationHistory(BankAccount bankAccount, double amountMoney, string operation)
    {
        if (bankAccount is null)
        {
            Console.WriteLine("Вы не авторизовались");
            return;
        }

        const string sql = """
                           INSERT INTO "OperationHistory" ("Bank_Account", "Change", "Date")
                           VALUES (@BankAccount, @Change, @Date)
                           """;

        using (var connection = new NpgsqlConnection(_connection))
        {
            connection.Open();

            using (var command = new NpgsqlCommand(sql, connection))
            {
                string amount = operation + amountMoney;
                command.Parameters.AddWithValue("@BankAccount", bankAccount.AccountNumber);
                command.Parameters.AddWithValue("@Change", amount);
                command.Parameters.AddWithValue("@Date", DateTime.Now);

                command.ExecuteNonQuery();
            }
        }
    }
}