namespace ToDoList.Service
{
    public class Message
    {
        public static void ShowMessage(string message, ConsoleColor color)
        {
            ConsoleHelper.ClearScreen();
            ConsoleHelper.WriteColored(message, color);
        }
    }
}
