using ToDoList.Entity;

namespace ToDoList.Service
{
    public class View
    {
        public static void ViewNotes(Data data)
        {
            short number = 1;

            foreach (var item in data.Notes)
            {
                string statusText = item.Status ? "Done" : "Not Done";
                ConsoleColor statusColor = item.Status ? ConsoleColor.Green : ConsoleColor.Red;

                Console.WriteLine($"{number} -> Note ID      : {item.NoteID}\n" +
                                  $"{new string(' ', 5)}Title        : {item.Title}\n" +
                                  $"{new string(' ', 5)}Created Date : {item.CreatedDate}");

                Console.Write($"{new string(' ', 5)}Status       : ");
                Console.ForegroundColor = statusColor;
                Console.WriteLine(statusText);
                Console.ResetColor();

                Console.Write($"{new string(' ', 5)}Deadline   : {item.Deadline : yyyy-MM-dd}");

                if (!item.Status)
                {
                    TimeSpan remaining = item.Deadline.Date - DateTime.Today;
                    Console.Write($"{new string(' ', 5)}Remaining    : ");


                    if(remaining.Days < 0)
                    {
                        ConsoleHelper.WriteColored($"⚠️ Overdue by {Math.Abs(remaining.Days)} day(s)!", ConsoleColor.Red);
                    }
                    else if(remaining.Days == 0)
                    {
                        ConsoleHelper.WriteColored("⚠️ Due today!", ConsoleColor.Yellow);
                    }
                    else
                    {
                        ConsoleHelper.WriteColored($"{remaining.Days} day(s) left", ConsoleColor.Cyan);
                    }
                }

                Console.WriteLine("------------------------------------------");
                number++;
            }
        }
    }
}