// Made by ivnktrv
// My github - https://github.com/ivnktrv

using xyz_cryptor;

namespace xyz_main;

class XYZmain
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("[-] Вы не передали параметров! За справкой: xyz -h (или --help)");
        }
        else
        {
            XYZcryptor x = new XYZcryptor();
            try
            {
                if (args[0] == "-e" || args[0] == "--encrypt")
                {
                    x.encrypt(args[1], args[2]);
                }
                else if (args[0] == "-d" || args[0] == "--decrypt")
                {
                    if (args.Length == 3)
                    {
                        x.decrypt(args[1], int.Parse(args[2]), print: true);
                    }
                    else
                    {
                        if (args[3] == "--outfile")
                        {
                            x.decrypt(args[1], int.Parse(args[2]), outFile: args[4]);
                        }
                    }
                    
                }
                else if (args[0] == "-h" || args[0] == "--help")
                {
                    Console.WriteLine(
                        "\nxyz -h (или --help) <- справка" +
                        "\n\nxyz -e (или --encrypt) [файл, который будет зашифрован] [имя зашифрованного файла (передать без расширения!)] <- зашифровать файл" +
                        "\n\nxyz -d (или --decrypt) [.xyz файл] [ключ] <- расшифровать .xyz файл и вывести содержимое в консоль" +
                        "\nxyz -d (или --decrypt) [.xyz файл] [ключ] --outfile [файл который будет расшифрован] <- расшифровать .xyz файл и записать в файл"
                    );
                }
                else
                {
                    Console.WriteLine("[-] Неизвестный параметр");
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("[-] Недостаточно аргументов. За помощью: xyz -h (или --help)");
            }
        }
    }
}
//      0  1    2      3       4
// xyz -d file key --outfile s.txt