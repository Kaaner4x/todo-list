using System.Text;
using ToDoList.Entity;
using ToDoList.Service;

namespace ToDoList
{
    public class Program
    {
        static Data _data = new Data();

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            bool isWork = true;

            do
            {
                ConsoleHelper.ClearScreen();
                Menu.Menu.MainMenu();
                byte act = ConsoleHelper.GetInput<byte>("\n 👉 Please enter an action you want to perform: ");
                ConsoleHelper.ClearScreen();

                switch (act)
                {
                    case 1:
                        View.ViewNotes(_data);
                        break;

                    case 2:
                        View.ViewNotes(_data);
                        int id = ConsoleHelper.GetInput<int>("\n 👉 Please enter a note id you want to review: ");
                        ConsoleHelper.ClearScreen();
                        Review.ReviewNote(_data, id);
                        break;

                    case 6:
                        ConsoleHelper.ClearScreen();
                        break;

                    case 7:
                        isWork = Exit.ExitMenu();
                        break;

                    default:
                        ConsoleHelper.WriteColored(" ❗ Invalid Operations", ConsoleColor.Red);
                        break;
                }

                if (isWork)
                {
                    ConsoleHelper.WaitingScreen();
                }
            }
            while (isWork);
        }
    }
}