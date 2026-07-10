namespace ToDoList.Menu
{
    public class Menu
    {
        public static void MainMenu()
        {
            var mainMenuItems = new (string text, ConsoleColor Color)[]
   {
            ( " 📓 Main Menu", ConsoleColor.White),
            ( $" {new string(' ',40)}",ConsoleColor.White),
            ( " 1. View all notes", ConsoleColor.White),
            ( " 2. Review the note", ConsoleColor.White),
            ( " 3. Add a note", ConsoleColor.White),
            ( " 4. Update a note", ConsoleColor.White),
            ( " 5. Delete a note", ConsoleColor.White),
            ( " 6. Clear the console", ConsoleColor.White),
            ( " 7. Exit", ConsoleColor.White),
        };

            foreach (var item in mainMenuItems)
            {
                Console.WriteLine(item.text, ConsoleColor.White);
            }

        }
    }
}
