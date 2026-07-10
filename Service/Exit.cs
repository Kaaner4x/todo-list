namespace ToDoList.Service
{
    public class Exit
    {
        public static void ExitMenu()
        {
            string decision = ConsoleHelper.GetInput<string>("Are you sure you want to exit (y/n): ");

            if (!string.IsNullOrEmpty(decision) && decision.Trim().ToLower() == "y")
            {
                Environment.Exit(0);
            }
        }
    }
}
