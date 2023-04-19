static class Program
{
    static void Main()
    {
        DisplayQuestionnaireToConsole(Questionnaire());
    }

    static public (string, string, int, int, string[], string[]) Questionnaire()
    {
        (string name, string lastName, int age, int petCount, string[] petNames, string[] favoriteColors) form;

        Console.Write("Напишите ваше имя: ");
        form.name = CheckCorrectName(Console.ReadLine());
        Console.Write("Напишите вашу фамилию: ");
        form.lastName = CheckCorrectName(Console.ReadLine());
        Console.Write("Напишите ваш возраст: ");
        form.age = CheckStringForInt(Console.ReadLine(), 0);

        string petAnswer;
        do
        {
            Console.WriteLine("у вас есть питомец?(Да/Нет): ");
            petAnswer = Console.ReadLine();
            if (petAnswer == "Да")
            {
                Console.WriteLine("Сколько у вас питомцев?");
                form.petCount = CheckStringForInt(Console.ReadLine(), 0);
                break;
            }
            else if (petAnswer == "Нет")
            {
                form.petCount = 0;
                break;
            }
        }
        while (true);
        if (form.petCount > 0)
        {
            form.petNames = new string[form.petCount];
            for (int i = 0; i < form.petNames.Length; i++)
            {
                Console.WriteLine("Напишите имена ваших питомцев");
                form.petNames[i] = CheckCorrectName(Console.ReadLine());
            }
        }
        else
        {
            form.petNames = new string[1];
        }

        Console.WriteLine("Напишите количество ваших любимых цветов");
        int colorCount = CheckStringForInt(Console.ReadLine());
        form.favoriteColors = new string[colorCount];
        for (int i = 0; i < form.favoriteColors.Length; i++)
        {
            Console.WriteLine("Напишите ваши любимые цвета");
            form.favoriteColors[i] = Console.ReadLine();
        }
        return (form.name, form.lastName, form.age, form.petCount, form.petNames, form.favoriteColors);
    }

    static public void DisplayQuestionnaireToConsole((string, string, int, int, string[], string[]) tuple)
    {
        Console.WriteLine($"Ваше имя: {tuple.Item1} ");
        Console.WriteLine($"Ваша фамилия: {tuple.Item2} ");
        Console.WriteLine($"Ваш возраст: {tuple.Item3} ");
        if (tuple.Item4 > 0)
        {
            Console.WriteLine("Имена ваших питомцев");
            for (int i = 0; i < tuple.Item5.Length; i++)
            {
                Console.WriteLine(tuple.Item5[i]);
            }
        }
        Console.WriteLine("Ваши любимые цвета");
        for (int i = 0; i < tuple.Item6.Length; i++)
        {
            Console.WriteLine(tuple.Item6[i]);
        }
    }
    /// <summary>
    /// Возвращает строку лишь в случае если она состоит из букв и не равна Null или пуста, иначе просит повторить ввод
    /// </summary>
    /// <param input="input"></param>
    /// <returns></returns>
    public static string CheckCorrectName(string input)
    {

        while (!input.All(char.IsLetter) | string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Введите строку содержащую только буквы:");
            input = Console.ReadLine();
        }
        return input;
    }
    /// <summary>
    /// Проверяет является ли введенная строка значением типа Int, если да - возвращает его, если нет - просит повторить ввод
    /// </summary>
    /// <param input="input"></param>
    /// <returns></returns>
    public static int CheckStringForInt(string input)
    {
        if (int.TryParse(input, out int number))
        {
            return number;
        }
        else
        {
            Console.WriteLine("Пожалуйста, введите число: ");
            string newInput = Console.ReadLine();
            return CheckStringForInt(newInput);
        }
    }
    /// <summary>
    /// Проверяет является ли введенная строка значением типа Int и больше ли оно параметра value, если да - возвращает его, если нет - просит повторить ввод
    /// </summary>
    /// <param input="input"></param>
    /// <param value="value"></param>
    /// <returns></returns>
    public static int CheckStringForInt(string input, int value)
    {
        int number;
        if (int.TryParse(input, out number))
        {
            if (number > value)
            {
                return number;
            }
            else
            {
                Console.WriteLine($"Введите число больше {value}: ");
                string newInput = Console.ReadLine();
                return CheckStringForInt(newInput);
            }
        }
        else
        {
            Console.WriteLine("Введите число: ");
            string newInput = Console.ReadLine();
            return CheckStringForInt(newInput);
        }
    }
}