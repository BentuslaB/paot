using System;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {


private const string AllChars =
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                "abcdefghijklmnopqrstuvwxyz" +
                "0123456789" +
                "!@#$%^&*()-_=+[]{};:,.<>?/\\|`~";
            static void Main()
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.Write("Введите длину пароля: ");
                if (!int.TryParse(Console.ReadLine(), out int length) || length <= 0)
                {
                    Console.WriteLine("Ошибка: введите положительное целое число.");
                    return;
                }
                string password = GeneratePassword(length);
                Console.WriteLine($"Сгенерированный пароль: {password}");
            }
            static string GeneratePassword(int length)
            {
                if (length <= 0)
                    throw new ArgumentException("Длина пароля должна быть больше нуля.");
                char[] result = new char[length];
                byte[] randomBytes = new byte[length];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(randomBytes);
                }

                for (int i = 0; i < length; i++)
                {
                    int index = randomBytes[i] % AllChars.Length;
                    result[i] = AllChars[index];
                }

                return new string(result);
            }
        }
    }
  

