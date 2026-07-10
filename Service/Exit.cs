namespace ToDoList.Service
{
    public class Exit
    {
        public static bool ExitMenu()
        {
            string decision = ConsoleHelper.GetInput<string>("Are you sure you want to exit (y/n): ");

            if (!string.IsNullOrEmpty(decision) && decision.Trim().ToLower() == "y")
            {
                return false;
            }
            return true;
        }
    }
}
