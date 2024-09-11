double Error_Occured()
{
    Console.Write("Error occured! Press any key to try again...");
    Console.ReadKey();
    Console.Clear();

    return calc(0, " ", 0);
}

int user_choice()
{
    Console.WriteLine("Choose operation:\n[1]. +\n[2]. -\n[3]. *\n[4]. /\n[5]. %\n[6]. 1/x\n[7]. sqrt(x)\n[8]. x^2\n[9]. M+\n[10]. M-\n[11]. MR\n[12]. MC\n[13]. =\n[14]. Clear\n[15]. Exit program");
    string? input = Console.ReadLine();
    int choice = 0;
    bool isInt = int.TryParse(input, out choice);

    if (!isInt)
    {
        return 0;
    }

    return choice;
}

double get_result(string operation, double num_1, double num_2)
{
    double result = 0; 

    switch (operation)
    {
        case "1":
            result = num_1 + num_2;

            Console.WriteLine(Convert.ToString(num_1) + " + " + Convert.ToString(num_2) + " = " + Convert.ToString(result));

            break;

        case "2":
            result = num_1 - num_2;

            Console.WriteLine(Convert.ToString(num_1) + " - " + Convert.ToString(num_2) + " = " + Convert.ToString(result));

            break;

        case "3":
            result = num_1 * num_2;

            Console.WriteLine(Convert.ToString(num_1) + " * " + Convert.ToString(num_2) + " = " + Convert.ToString(result));

            break;

        case "4":
            if (num_2 == 0)
            {
                return Error_Occured();
            }

            result = num_1 / num_2;

            Console.WriteLine(Convert.ToString(num_1) + " / " + Convert.ToString(num_2) + " = " + Convert.ToString(result));

            break;

        case "5":
            result = num_2 / num_1;

            Console.WriteLine(Convert.ToString(num_2) + "% from " + Convert.ToString(num_1) + " = " + Convert.ToString(result));

            break;


        case "6":
            if (num_2 == 0)
            {
                return Error_Occured();
            }

            result = 1.0 / num_2;

            Console.WriteLine("1 / " + Convert.ToString(num_2) + " = " + Convert.ToString(result));

            break;

        case "7":
            if (num_2 < 0)
            {
                return Error_Occured();
            }

            result = Math.Sqrt(num_2);

            Console.WriteLine("sqrt(" + Convert.ToString(num_2) + ") = " + Convert.ToString(result));

            break;

        case "8":
            result = Math.Pow(num_2, 2);

            Console.WriteLine(Convert.ToString(num_2) + "^2  = " + Convert.ToString(result));

            break;
    }

    return result;
}

double memory_(string operation, double num_1, double calc_memory)
{
    switch (operation)
    {
        case "9":
            calc_memory += num_1;
            goto default;

        case "10":
            calc_memory -= num_1;
            goto default;

        case "11":
            num_1 = calc_memory;
            Console.WriteLine(num_1);
            goto default;

        case "12":
            calc_memory = 0;
            goto default;

        case "14":
            return calc(0, " ", calc_memory);

        default:
            return calc_memory;
    }
}

double calc(double num_1, string operation, double calc_memory)
{
    if (operation == " ")
    {
        Console.Write("Enter a number: ");
        string? input = Console.ReadLine();
        bool isDouble = Double.TryParse(input, out num_1);

        if (!isDouble)
        {
            return Error_Occured();
        }

        int choice = user_choice();

        if (choice == 0)
        {
            return Error_Occured();
        }

        string str_choice = Convert.ToString(choice);

        if (str_choice == "5")
        {
            Console.WriteLine(Convert.ToString(num_1) + "% from 100 = " + Convert.ToString(num_1 / 100.0));
            num_1 /= 100.0;
            choice = user_choice();
            str_choice = Convert.ToString(choice);
        }

        return calc(num_1, str_choice, calc_memory);
    }

    else if ("1234".Contains(operation))
    {
        Console.Write("Enter a number: ");
        string? input = Console.ReadLine();
        double num_2 = 0;
        bool isDouble = Double.TryParse(input, out num_2);

        if (!isDouble || (num_2 == 0 && operation == "4"))
        {
            return Error_Occured();
        }

        int choice = user_choice();

        if (choice == 0)
        {
            return Error_Occured(); 
        }

        double result = 0;

        string str_choice = Convert.ToString(choice);

        if ("5678".Contains(str_choice))
        {
            num_2 = get_result(str_choice, num_1, num_2);
        }

        result = get_result(operation, num_1, num_2);

        if ("910111214".Contains(str_choice))
        {
            calc_memory = memory_(str_choice, result, calc_memory);
        }

        choice = user_choice();
        str_choice = Convert.ToString(choice);
        return calc(result, str_choice, calc_memory);
    }

    else if ("5678".Contains(operation)) 
    {
        int choice;
        string str_choice;

        if (operation == "5")
        {
            Console.WriteLine(Convert.ToString(num_1) + "% from 100 = " + Convert.ToString(num_1 / 100.0));
            num_1 /= 100.0;
            choice = user_choice();
            str_choice = Convert.ToString(choice);
        }

        double result = get_result(operation, 0, num_1);
        choice = user_choice();
        str_choice = Convert.ToString(choice);

        return calc(result, str_choice, calc_memory);
    }

    else if ("91011121314".Contains(operation))
    {
        calc_memory = memory_(operation, num_1, calc_memory);

        int choice = user_choice();
        string str_choice = Convert.ToString(choice);

        return calc(num_1, str_choice, calc_memory);
    }

    else
    {
        Console.Write("Program is stopped! Press any key to exit...");
        Console.ReadKey();
        Console.Clear();

        return 0;
    }
}

calc(0, " ", 0);