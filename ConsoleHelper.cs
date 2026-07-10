namespace ToDoList
{
    class ConsoleHelper
    {
        public static T GetInput<T>(string message, ConsoleColor color = ConsoleColor.White)
        {
            while (true)
            {
                WriteColored(message, color, false);
                string? text = Console.ReadLine();

                if (text == null)
                {
                    WriteColored("\n ⚠️ Input stream closed. Exiting application.", ConsoleColor.Red);
                    Environment.Exit(0);
                }

                if (text.Trim().ToLower() == "clear")
                {
                    ClearScreen();
                    continue;
                }

                if (string.IsNullOrWhiteSpace(text))
                {
                    WriteColored("\n ⚠️ Input cannot be empty!", ConsoleColor.Red);
                    continue;
                }

                try
                {
                    if (typeof(T).IsEnum)
                    {
                        if (Enum.TryParse(typeof(T), text, out object? result))
                        {
                            return (T)result;
                        }
                        else
                        {
                            WriteColored($"\n ⚠️ Please enter a valid {typeof(T).Name} value!", ConsoleColor.Red);
                            continue;
                        }
                    }
                    else
                    {
                        return (T)Convert.ChangeType(text, typeof(T));
                    }
                }
                catch (FormatException)
                {
                    WriteColored($"\n ⚠️ Please enter a valid {typeof(T).Name} value!", ConsoleColor.Red);
                }
                catch (OverflowException)
                {
                    WriteColored($"\n ⚠️ The entered value is too large or too small for {typeof(T).Name}!", ConsoleColor.Red);
                }
                catch (Exception exc)
                {
                    WriteColored($"\n ⚠️ An unexpected error occurred: {exc.Message}", ConsoleColor.Red);
                }
            }
        }


        public static void WriteColored(string text, ConsoleColor color = ConsoleColor.White, bool newLine = true)
        {
            Console.ForegroundColor = color;
            if (newLine) Console.WriteLine(text);
            else Console.Write(text);
            Console.ResetColor();
        }

        public static void ClearScreen()
        {
            try
            {
                Console.Clear();
                Console.Write("\x1b[3J");
            }
            catch (IOException)
            {
                // Ignore when run in environments without an interactive console
            }
        }

        public static void WaitingScreen(ConsoleColor color = ConsoleColor.DarkYellow)
        {
            try
            {
                Console.CursorVisible = false;
            }
            catch (Exception) { }

            WriteColored("\n⏳ Press any key to continue ...", color);

            try
            {
                Console.ReadKey(intercept: true);
            }
            catch (Exception)
            {
                // Fallback if input is redirected: pause briefly
                Thread.Sleep(1000);
            }

            try
            {
                Console.CursorVisible = true;
            }
            catch (Exception) { }

            ClearScreen();
        }
    }
}
