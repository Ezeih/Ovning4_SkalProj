using System;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /*
         * Frågor
         * 1.Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess 
grundläggande funktion Till example kan man lagra variable som namn,ålder,kön för varje person i person Lista 
SVAR: Stacken anvävder för att hantera funktioner och metoden. LIFO-princicipe
        heapen använder för att lagra objekten och den är inte organiserad. Till example man kan lagra objekt person och kan ha mer detaljer för varje objekt person.

        
        2. Vad är Value Types respektive Reference Types och vad skiljer dem åt?
           SVAR: Value type lagras direkt och kopiera när de tilldelas till annan variable.
                 Refrens type lagrar en referans och delar samma information 

        3. Följande metoder (se bild nedan) genererar olika svar. Den första returnerar 3, den 
andra returnerar 4, varför? 
        SVAR: första metoden använder value types och i den andra använd refrens type.  x och y pekar på samma objekt och ändringar påverkar båda variablerna. Det är därför den första metoden returnerar 3 och den andra metoden returnerar 4.
         */

        static Queue<string> ICAKo = new Queue<string>();
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        /// 
        static void Main()
        {


            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }



        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            Console.WriteLine("Välkommen till person listan");

            List<string> myList = new List<string>();

            while (true)
            {
                Console.WriteLine("Vänligen ange '+' för att lägga till en ny person, '-' för att ta bort en person, eller något annat för att gå till huvudmenyn:");

                string input = Console.ReadLine();
                char nav = input[0];

                if (nav == '+')
                {
                    Console.WriteLine("Vänligen ange personens namn:");
                    string value = Console.ReadLine();
                    myList.Add(value);
                    Console.WriteLine("Personen har lagts till i listan.");
                }
                else if (nav == '-')
                {
                    Console.WriteLine("Vänligen ange namnet på personen du vill ta bort:");
                    string value = Console.ReadLine();

                    if (myList.Contains(value))
                    {
                        myList.Remove(value);
                        Console.WriteLine("Personen har tagits bort från listan.");
                    }
                    else
                    {
                        Console.WriteLine("Personen finns inte i listan.");
                    }
                }

                else
                {

                    Console.WriteLine("Ogiltig inmatning, försök igen!");
                    ExamineList();
                }

                Console.WriteLine("Antal personer i listan: " + myList.Count);
                Console.WriteLine("Listans kapacitet: " + myList.Capacity);
                Console.WriteLine(myList);
            }
        }
        /*
         * Loop this method untill the user inputs something to exit to main menue.
         * Create a switch statement with cases '+' and '-'
         * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
         * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
         * In both cases, look at the count and capacity of the list
         * As a default case, tell them to use only + or -
         * Below you can see some inspirational code to begin working.
        */

        // List<string> theList = new List<string>();
        //  string input = Console.ReadLine();
        // char nav = input[0];
        // string value = input.substring(1);

        //switch(nav){...}


        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {

            while (true)
            {
                Console.WriteLine("Välj en handling:");
                Console.WriteLine("1. Ställa sig i kön");
                Console.WriteLine("2. Expediera nästa person");
                Console.WriteLine("3. Avsluta");

                int val = Convert.ToInt32(Console.ReadLine());

                switch (val)
                {
                    case 1:
                        Console.WriteLine("Vad är ditt namn?");
                        string namn = Console.ReadLine();
                        ICAKo.Enqueue(namn);
                        Console.WriteLine($"{namn} har lagts till i kön.");
                        Console.WriteLine();
                        break;
                    case 2:
                        if (ICAKo.Count > 0)
                        {
                            string person = ICAKo.Dequeue();
                            Console.WriteLine($"{person} har blivit expedierad och lämnar kön.");
                        }
                        else
                        {
                            Console.WriteLine("Kön är tom.");
                        }
                        Console.WriteLine();
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        Console.WriteLine();
                        break;
                }
            }
        }
        /*
         * Loop this method untill the user inputs something to exit to main menue.
         * Create a switch with cases to enqueue items or dequeue items
         * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
        */


        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            Stack<string> stack = new Stack<string>();

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Välj ett alternativ:");
                Console.WriteLine("1. Tryck på ett objekt");
                Console.WriteLine("2. Ta bort ett objekt");
                Console.WriteLine("3. Avsluta");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Skriv in ett objekt att trycka på:");
                        string item = Console.ReadLine();
                        stack.Push(item);
                        Console.WriteLine("Objektet har tryckts på stacken.");
                        Console.WriteLine("Nuvarande stack:");
                        foreach (string obj in stack)
                        {
                            Console.WriteLine(obj);
                        }
                        break;
                    case "2":
                        if (stack.Count > 0)
                        {
                            string poppedItem = stack.Pop();
                            Console.WriteLine($"Objektet '{poppedItem}' har tagits bort från stacken.");
                            Console.WriteLine("Nuvarande stack:");
                            foreach (string obj in stack)
                            {
                                Console.WriteLine(obj);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Stacken är tom. Det finns inga objekt att ta bort.");
                        }
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val. Vänligen försök igen.");
                        break;
                }
            }
        }
        /*
         * Loop this method until the user inputs something to exit to main menue.
         * Create a switch with cases to push or pop items
         * Make sure to look at the stack after pushing and and poping to see how it behaves
        */


        static void CheckParanthesis()
        {
            Console.WriteLine("Ange en sträng att kontrollera:");
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            foreach (char c in input)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == ']' || c == '}')
                {
                    if (stack.Count == 0)
                    {
                        Console.WriteLine("Strängen är bra.");
                        return;
                    }

                    char top = stack.Pop();
                    if ((c == ')' && top != '(') || (c == ']' && top != '[') || (c == '}' && top != '{'))
                    {
                        Console.WriteLine("Strängen är inte bra.");
                        return;
                    }
                }
            }

            if (stack.Count == 0)
            {
                Console.WriteLine("Strängen är bra.");
            }
            else
            {
                Console.WriteLine("Strängen är inte bra.");
            }
        }
        /*
         * Use this method to check if the paranthesis in a string is Correct or incorrect.
         * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
         * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
         */

    }

    }



