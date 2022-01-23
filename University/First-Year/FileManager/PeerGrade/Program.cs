using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PeerGrade
{
    class Program
    {
        static void Main(string[] args)
        {
            // Запускаем инструкциию к программе.
            StartOfTheProgram();
            // Текущий адрес делаем пустым.
            string currentDirectory = "";
            // Запускаем выбор стартовых команд.
            OptionExecution(DefaultCommands(),ref currentDirectory,1);
        }

        static void StartOfTheProgram()
        {
            // Считываем текст из файла с инструкцией и выводим в консоль.
            Console.ForegroundColor = ConsoleColor.White;
            String line;
            try
            {
                StreamReader sr = new StreamReader("Instructions.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch
            {
                Console.WriteLine("Файл с инструкцией не найден или поврежден");
            }
            Console.ReadKey(true);
            Console.Clear();
        }

        static string[] DefaultCommands()
        {
            // Метод возвращает массив стартовых комманд.
            string[] commands = new string[11];
            commands[0] = "Просмотр списка дисков компьютера и выбор диска";
            commands[1] = "Выбор директории";
            commands[2] = "Просмотр списка файлов в директории";
            commands[3] = "Вывод содержимого текстового файла в консоль в кодировке UTF-8";
            commands[4] = "Вывод содержимого текстового файла в консоль в выбранной кодировке";
            commands[5] = "Копирование файла";
            commands[6] = "Перемещение файла в выбранную директорию";
            commands[7] = "Удаление файла";
            commands[8] = "Создание простого текстового файла в кодировке UTF-8";
            commands[9] = "Создание простого текстового файла в выбранной кодировке";
            commands[10] = "Конкатенация содержимого двух или более текстовых файлов и вывод результата в консоль в кодировке UTF - 8.";
            return commands;
        }

        private static void OptionExecution(string[] options,ref string currentDirectory, int typeOfSelection)
        { 
            // Метод реализует выбор доступных опций.

            // Инициализируем переменную, содержащую сведения о нажатой клавише.
            ConsoleKeyInfo input;
            int currentoption = 0;
            do
            {
                Console.WriteLine("Текущий адрес: " + currentDirectory);
                Console.WriteLine();
                Console.WriteLine("\tСписок доступных опций");
                if (options.Length == 0)
                {
                    Console.WriteLine("Эта директория пуста");
                    Console.WriteLine("Нажмите любую клавишу для продолжения");
                    Console.ReadKey(true);
                    break;
                }
                PrintingOptions(options, currentoption);
                // Нажимаем одну из доступных клавиш для выбора опции.
                input = Console.ReadKey(true);
                currentoption = SelectingOption(options, input, currentoption);
                // Запускаем нужную опциию.
                if (input.Key == ConsoleKey.Enter)
                {
                    // Для начальных комманд typeOfSelection равен 1, для остальных случаев - 2.
                    if (typeOfSelection == 1)
                    {
                        currentDirectory = CommandExecution(currentoption, currentDirectory);
                    }
                    else
                    {
                        // При выполнении одной из начальных комманд текущий адрес меняется на тот, с которым мы работаем.
                        currentDirectory = options[currentoption];
                        break;
                    }

                }
                Console.Clear();
                // При нажатии "Escape" цикл завершается.
            }
            while (input.Key != ConsoleKey.Escape);
        }

        private static void PrintingOptions(string[] options, int currentoption)
        {
            // Данный метод выводит в консоль доступные опции вместе с текущей, выделенной зеленым.

            for (int i = 0; i < options.Length; i++)
            {
                if (i == currentoption)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(options[i]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                    Console.WriteLine(options[i]);
            }
        }

        private static int SelectingOption(string[] options, ConsoleKeyInfo input, int currentoption)
        {
            // Данный метод осуществляет выбор текущей опции.
            if (input.Key == ConsoleKey.DownArrow)
            {
                if (currentoption == options.Length - 1)
                    currentoption = 0;
                else
                    currentoption += 1;
            }
            if (input.Key == ConsoleKey.UpArrow)
            {
                if (currentoption == 0)
                    currentoption = options.Length - 1;
                else
                    currentoption -= 1;
            }

            return currentoption;
        }

        static string CommandExecution(int currentcommand,string currentDirectory)
        {
            // Данный метод осуществляет запуск методов, соответствующих выбранной начальной комманде.
            try
            {
                switch (currentcommand)
                {
                    case 0:
                        return FirstCommand();
                    case 1:
                        return SecondCommands(currentDirectory);
                    case 2:
                        return ThirdCommand(currentDirectory);
                    case 3:
                        return FourthCommand(currentDirectory);
                    case 4:
                        return FifthCommand(currentDirectory);
                    case 5:
                        return SixthCommand(currentDirectory);
                    case 6:
                        return SeventhCommand(currentDirectory);
                    case 7:
                        return EighthCommand(currentDirectory);
                    case 8:
                        return NinthCommand(currentDirectory);
                    case 9:
                        return TenthCommand(currentDirectory);
                    case 10:
                        return EleventhCommand(currentDirectory);
                    default:
                        return "";

                }
            }
            catch
            {
                Console.WriteLine("По какой-то причине операция не удалась");
                Console.WriteLine("Для продолжения нажмите любую клавишу");
                Console.ReadKey(true);
                return "";
            }           
        }

        /*
         * Некоторые из следующих методов принимают на вход текущий адрес и работают с ним.
         * При удалении текущий адрес  становится пустым.
         * При перемещении файла текущий адрес становится адресом места перемещения.
         * При создании файла текущий адрес становиться адресом созданного файла.
        */

        static string FirstCommand()
        {
            // Данный метод отправляет массив с именами дисков в OptionExecution для выбора нужного.
            Console.Clear();
            string[] Drives = Environment.GetLogicalDrives();
            string currentDirectory = "";
            OptionExecution(Drives,ref currentDirectory,2);
            return currentDirectory;
        }

        static string SecondCommands(string currentDirectory)
        {
            // Данный метод отправляет массив с именами директорий в OptionExecution для выбора нужной.
            try
            {
                Console.Clear();
                string[] Directories = Directory.GetDirectories(currentDirectory);
                OptionExecution(Directories, ref currentDirectory, 2);
                return currentDirectory;
            }
            catch
            {
                Console.WriteLine("Текущая директория: " + currentDirectory);
                Console.WriteLine();
                Console.WriteLine("\tСписок доступных опций");
                Console.WriteLine("Нет доступных директорий");
                Console.WriteLine("Нажмите любую клавишу для продолжения");
                Console.ReadKey(true);
                return currentDirectory;
            }
        }

        static string ThirdCommand(string currentDirectory)
        {
            // Данный метод отправляет массив с именами файлов в OptionExecution для выбора нужного.
            try
            {
                Console.Clear();
                string[] Files = Directory.GetFiles(currentDirectory);
                OptionExecution(Files, ref currentDirectory, 2);
                return currentDirectory;
            }
            catch
            {
                Console.WriteLine("Текущая директория: " + currentDirectory);
                Console.WriteLine();
                Console.WriteLine("\tСписок доступных опций");
                Console.WriteLine("Нет доступных файлов");
                Console.WriteLine("Нажмите любую клавишу для продолжения");
                Console.ReadKey(true);
                return currentDirectory;
            }
        }
        
        static string FourthCommand(string currentDirectory)
        {
            // Данный метод выводит текстовый файл в консоль.
            Console.Clear();
            String line;
            try
            {
                StreamReader sr = new StreamReader(@currentDirectory);
                line = sr.ReadLine();
                // Если строка пустая, то метод перестанет выводить текст.
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch
            {
                Console.WriteLine("Файл не существует или поврежден");
                Console.WriteLine("Для продолжения нажмите любую клавишу.");
                Console.ReadKey(true);
                return currentDirectory;
            }
            Console.WriteLine();
            Console.WriteLine("Для продолжения нажмите любую клавишу");
            Console.ReadKey(true);
            Console.Clear();
            return currentDirectory;
        }

        static string FifthCommand(string currentDirectory)
        {
            // Данный метод выводит текстовый файл в консоль в выбранной кодировке.
            Console.Clear();
            // Создаем массив кодировок.
            string[] encodings = { "UTF-32", "UTF-7", "ASCII" };
            bool inputCorrect = true;
            string output = "";
            // Запускаем метод, отвечающий зы выбор кодировки
            FifthCommandEncodings(encodings, ref inputCorrect, ref output);
            Console.Clear();
            String line;

            try
            {
                StreamReader sr = new StreamReader(@currentDirectory, Encoding.GetEncoding(output));
                line = sr.ReadLine();
                // Если строка пустая, то метод перестанет выводить текст.
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch
            {
                Console.WriteLine("Файл не существует или поврежден");
                Console.WriteLine("Для продолжения нажмите любую клавишу");
                Console.ReadKey(true);
                return currentDirectory;
            }
            Console.WriteLine();
            Console.WriteLine("Для продолжения нажмите любую клавишу");
            Console.ReadKey(true);
            Console.Clear();
            return currentDirectory;
        }

        private static void FifthCommandEncodings(string[] encodings, ref bool inputCorrect, ref string output)
        {
            // Данный метод отвечает за выбор кодировки.
            while (inputCorrect)
            {
                Console.WriteLine("Список доступных кодировок");
                Console.WriteLine(encodings[0]);
                Console.WriteLine(encodings[1]);
                Console.WriteLine(encodings[2]);
                Console.WriteLine("Пожалуйста, напишите выбранную кодировку");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "UTF-32":
                        output = "UTF-32";
                        inputCorrect = false;
                        break;
                    case "UTF-7":
                        output = "UTF-7";
                        inputCorrect = false;
                        break;
                    case "ASCII":
                        output = "ASCII";
                        inputCorrect = false;
                        break;
                    default:
                        inputCorrect = true;
                        Console.WriteLine("Кодировка была введена неправильно");
                        break;

                }
                Console.Clear(); 
            }
        }

        private static string SixthCommand(string currentDirectory)
        {
            // Данный метод создает копию исходного файла.
            Console.Clear();
            // Проверяем, что текущий адрес непустой.
            if (currentDirectory == "")
            {
                Console.WriteLine("Текущий адрес пуст");
                Console.WriteLine("Для продолжения нажмите любую клавишу");
                Console.ReadKey();
                return currentDirectory;
            }
            string FileName;
            do
            {
                Console.WriteLine("Введите название нового файла(не должно содержать символ\"\\\")");
                FileName = Console.ReadLine();
            }
            // Проверяем, чтобы в названии файла не было служебного символа "\". 
            while (FileName.Contains('\\'));
            int index = 0;
            char[] PreviousDirectory = currentDirectory.ToCharArray();
            for (int i = PreviousDirectory.Length - 1; i >= 0; i--)
            {
                if (PreviousDirectory[i] == '\\')
                {
                    index = i;
                    break;
                }
            }
            // Путь к копии файла будет тот же самый, только с другим названием файла, поэтому мы убираем все, что находится после первого "\". 
            string result = currentDirectory.Remove(index) + Path.DirectorySeparatorChar + FileName;
            try
            {
                File.Copy(@currentDirectory, @result, true);
                currentDirectory = result;
                Console.WriteLine("Копирование прошло успешно");
                Console.WriteLine("Для продолжения нажмите любую клавишу");
            }
            catch
            {
                Console.WriteLine("Исходный файл не существует или введенные данные некорректны");
                Console.WriteLine("Для продолжения нажмите любую клавишу");
            }
            Console.ReadKey();    
            return currentDirectory;
        }

        private static string SeventhCommand(string currentDirectory)
        {
            // Данный метод перемещает в другую директорию исходный файл.
            Console.Clear();
            string FileName;
            Console.WriteLine("Введите полный путь к директории, в которой будет находиться файл");
            FileName = Console.ReadLine();
            string result = currentDirectory;
            int index = 0;
            char[] PreviousDirectory = currentDirectory.ToCharArray();
            for (int i = PreviousDirectory.Length - 1; i >= 0; i--)
            {
                if (PreviousDirectory[i] == '\\')
                {
                    index = i;
                    break;
                }
            }     
            try
            {
                // Путь к копии файла будет уже другой, только название файла останется прежним, поэтому мы убираем все, что находится до первого "\".
                result = FileName + result.Remove(0, index + 1);
                File.Move(@currentDirectory, @result, true);
                currentDirectory = result;
                Console.WriteLine("Перемещение прошло успешно");
                Console.WriteLine("Для продолжения нажмите любую клавишу");
            }
            catch
            {
                Console.WriteLine("Исходный файл не существует или у вас нет прав");
                Console.WriteLine("Для продолжения нажмите любую клавишу");
            }

            Console.ReadKey();

            return currentDirectory;
        }
        static string EighthCommand(string currentDirectory)
        {
            // Данный метод удаляет файл, находящийся по текущему адресу.
            Console.Clear();
            try
            {
                File.Delete(currentDirectory);
                Console.WriteLine("Удаление прошло успешно");
                Console.WriteLine("Для продолжения нажмите любую клавишу");
                Console.ReadKey(true);
                currentDirectory = "";
                return currentDirectory;
            }
            catch
            {
                Console.WriteLine("Удаление прошло безуспешно, возможно файл не существует или текущий адрес не является файлом");
                Console.WriteLine("Для продолжения нажмите любую клавишу");
                Console.ReadKey();
                return currentDirectory;
            }
        }
        
        static string NinthCommand(string currentDirectory)
        {
            // Данный метод создает текстовый файл в кодировке UTF-8 в текущей директории.
            Console.Clear();
            // Проверяем, что текущий адрес непустой.
            if (currentDirectory == "")
            {
                Console.WriteLine("Текущий адрес пуст");
                Console.WriteLine("Для продолжения нажмите любую клавишу");
                Console.ReadKey();
                return currentDirectory;
            }
            Console.Clear();
            char[] PreviousDirectory = currentDirectory.ToCharArray();
            // Проверяем, что текущий адрес не является файлом.
            for (int i = PreviousDirectory.Length - 1; i >= 0; i--)
            {
                if (PreviousDirectory[i] != '\\')
                {
                    if (PreviousDirectory[i] == '.')
                    {
                        Console.WriteLine("Текущий адрес не является директорией");
                        Console.WriteLine("Для продолжения нажмите любую клавишу");
                        Console.ReadKey();
                        return currentDirectory;
                    }
                }
                else
                    break;
            }
            string FileName;
            do
            {
                Console.WriteLine("Введите название нового файла(не должно содержать символ\"\\\")");
                FileName = Console.ReadLine();
            }
            while (FileName.Contains('\\'));
            string result = currentDirectory + Path.DirectorySeparatorChar + FileName;
            string output = "UTF-8";
            // Вызываем метод WritingTheFile и закидываем в него текущий адрес, кодировку UTF-8 и путь к файлу.
            return WritingTheFile(ref currentDirectory, output, result);
        }

        static string TenthCommand(string currentDirectory)
        {
            // Данный метод создает текстовый файл в выбранной пользователем кодировке в текущей директории.
            Console.Clear();
            // Проверяем, что текущий адрес непустой.
            if (currentDirectory == "")
            {
                Console.WriteLine("Текущий адрес пуст");
                Console.WriteLine("Для продолжения нажмите любую клавишу");
                Console.ReadKey();
                return currentDirectory;
            }
            char[] PreviousDirectory = currentDirectory.ToCharArray();
            // Проверяем, что текущий адрес не является файлом.
            for (int i = PreviousDirectory.Length - 1; i >= 0; i--)
            {
                if (PreviousDirectory[i] != '\\')
                {
                    if (PreviousDirectory[i] == '.')
                    {
                        Console.WriteLine("Текущий адрес не является директорией");
                        Console.WriteLine("Для продолжения нажмите любую клавишу");
                        Console.ReadKey();
                        return currentDirectory;
                    }
                }
                else
                    break;
            }
            // Создаем массива доступных кодировок.
            string[] encodings = { "UTF-32", "UTF-7", "ASCII" };
            bool inputCorrect = true;
            string output = "";
            // Вызываем метод выбора кодировки.
            FifthCommandEncodings(encodings, ref inputCorrect, ref output);
            string FileName;
            do
            {
                Console.WriteLine("Введите название нового файла(не должно содержать символ\"\\\")");
                FileName = Console.ReadLine();
            }
            while (FileName.Contains('\\'));
            string result = currentDirectory + Path.DirectorySeparatorChar + FileName;
            Console.ReadKey(true);
            return WritingTheFile(ref currentDirectory, output, result);
        }

        private static string WritingTheFile(ref string currentDirectory, string output, string result)
        {
            // Данный метод записывает входные данные в текстовый файл в выбранной кодировке.
            string line;
            try
            {
                StreamWriter sw = new StreamWriter(result, true, Encoding.GetEncoding(output));
                do
                {
                    line = Console.ReadLine();
                    sw.WriteLine(line);
                }
                while (line != "");
                sw.Close();
                Console.WriteLine("Запись завершена успешно");
                Console.WriteLine("Для продолжения нажмите любую клавишу");
                Console.ReadKey(true);
                currentDirectory = result;
                return currentDirectory;
            }
            catch
            {
                Console.WriteLine("Запись не была завершена, убедитесь, что входные данные верны");
                Console.WriteLine("Для продолжения нажмите любую клавишу");
                Console.ReadKey();
                return currentDirectory;
            }
        }
        static string EleventhCommand(string currentDirectory)
        {
            // Данный метод выводит содержимое нескольких текстовых файлов в консоль.
            string line;
            Console.Clear();
            // Заполняем список адресами файлов, если адрес пустой, то прекращаем ввод.
            List<string> allLines = new List<string>();
            do
            {
                Console.WriteLine("Введите полный путь к файлу");
                line = Console.ReadLine();
                allLines.Add(line);
            }
            while (line != "");
            // Для каждого адреса выводим содержимое соответсвующего файла.
            for (int i = 0; i < allLines.Count - 1; i++)
            {
                try
                {
                    StreamReader sr = new StreamReader(allLines[i]);
                    line = sr.ReadLine();
                    while (line != null)
                    {
                        Console.WriteLine(line);
                        line = sr.ReadLine();
                    }
                    sr.Close();
                }
                catch
                {
                    Console.WriteLine("Файл не найден или поврежден");
                    Console.WriteLine("Для продолжения нажмите любую клавишу.");
                    Console.ReadKey(true);
                    currentDirectory = "";
                    return currentDirectory;
                }
            }       
            Console.WriteLine();
            Console.WriteLine("Для продолжения нажмите любую клавишу");
            Console.ReadKey(true);
            Console.Clear();
            return currentDirectory;
        }
    }

}
