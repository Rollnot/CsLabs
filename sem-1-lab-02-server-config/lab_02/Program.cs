using System.ComponentModel;
using System.Runtime.InteropServices.Marshalling;

namespace lab_02;

public static class Program
{

    public static string CheckConfiguration(int ram, int players, bool start, bool password) 
    {
        if (start == true)
        {
            if (players == 0)
            {
                return "[ERROR] Количество игроков должно быть больше нуля.";
            }
            if (ram < 2)
            {
                return "[ERROR] Серверу недостаточно оперативной памяти.";
            }
            if (players/ram >= 8)
            {
                Console.WriteLine("[WARNING] Для такого количества игроков рекомендуется больше оперативной памяти.");
            }
            if (password == true)
            {
                Console.WriteLine("[WARNING] Сервер защищён паролем.");
            }
            return "[INFO] Сервер запущен.";
        }
        else 
        {
            return "[INFO] Отмена запуска сервера...";
        }
    }

    public static string Password(string PasswordInput)
    {
        if (PasswordInput == "y")
        {
            return "true";
        }
        else
        {
            return "false";
        } 
    }

    public static string Start(string StartInput)
    {
        if (StartInput == "y")
        {
            return "true";
        }
        else
        {
            return "false";
        } 
    }

    static void Main(string[] args)
    {
        Console.Write("Введите количество оперативной памяти (в ГБ): ");
        string RamInput = Console.ReadLine();
        int ram = Convert.ToInt32(RamInput);

        Console.Write("Введите количество игроков: ");
        string PlayersInput = Console.ReadLine();
        int players = Convert.ToInt32(PlayersInput);

        Console.Write("Установить пароль? [y/N] ");
        string PasswordInput = Console.ReadLine();
        bool password = Convert.ToBoolean(Password(PasswordInput));

        Console.WriteLine(
            $"""

            Оперативная память: {ram}ГБ
            Игроки: {players}
            Пароль: {password}

            """);

        Console.Write("Запустить сервер? [y/N] ");
        string StartInput = Console.ReadLine();
        bool start = Convert.ToBoolean(Start(StartInput));


        Console.WriteLine(CheckConfiguration(ram, players, start, password));
    }
}
