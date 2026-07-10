using System.Text;
using ToDoList.Entity;
using ToDoList.Service;

namespace ToDoList
{
    public class Program
    {
        static Data data = new Data();
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
                    case 6:
                        ConsoleHelper.ClearScreen();
                        break;
                    case 7:
                        Exit.ExitMenu();
                        break;
                    default:
                        ConsoleHelper.WriteColored(" ❗ Invalid Operations", ConsoleColor.Red);
                        break;
                }
                ConsoleHelper.WaitingScreen();
            }
            while (isWork == true);
        }
    }
}