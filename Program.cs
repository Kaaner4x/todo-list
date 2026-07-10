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
                        int addId = ConsoleHelper.GetInput<int>("\n 👉 Please enter a note id you want to review: ");
                        ConsoleHelper.ClearScreen();
                        Review.ReviewNote(_data, addId);
                        break;

                    case 3:
                        AddNote.Add(_data);
                        Message.ShowMessage("✅ Your transaction has been completed successfully", ConsoleColor.Green);
                        break;

                    case 4:
                        View.ViewNotes(_data);
                        int updateId = ConsoleHelper.GetInput<int>("\n 👉 Please enter a note id you want to update: ");
                        ConsoleHelper.ClearScreen();
                        UpdateNote.Update(_data, updateId);
                        break;

                    case 5:
                        View.ViewNotes(_data);
                        int deleteId = ConsoleHelper.GetInput<int>("\n 👉 Please enter a note id you want to delete: ");
                        ConsoleHelper.ClearScreen();
                        
                        var noteToDelete = _data.Notes.FirstOrDefault(x => x.NoteID == deleteId);
                        if (noteToDelete == null)
                        {
                            Message.ShowMessage($"⚠️ Note with ID {deleteId} was not found.", ConsoleColor.Red);
                        }
                        else
                        {
                            ConsoleHelper.WriteColored("🗑️ You are about to delete the following note:\n", ConsoleColor.Yellow);
                            ConsoleHelper.WriteColored($" Note ID      : {noteToDelete.NoteID}");
                            ConsoleHelper.WriteColored($" Title        : {noteToDelete.Title}");
                            ConsoleHelper.WriteColored($" Content      : {noteToDelete.Content}");
                            ConsoleHelper.WriteColored($" Created Date : {noteToDelete.CreatedDate}");
                            ConsoleHelper.WriteColored(new string('-', 40));
                            
                            string confirm = ConsoleHelper.GetInput<string>("\n⚠️ Are you sure you want to delete this note? (y/n): ");
                            if (confirm.Trim().ToLower() == "y")
                            {
                                DeleteNote.Delete(_data, deleteId);
                                Message.ShowMessage("✅ Your transaction has been completed successfully", ConsoleColor.Green);
                            }
                            else
                            {
                                Message.ShowMessage("❌ Deletion cancelled.", ConsoleColor.Yellow);
                            }
                        }
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