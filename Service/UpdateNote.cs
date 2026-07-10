using ToDoList.Entity;

namespace ToDoList.Service
{
    public class UpdateNote
    {
        public static void Update(Data data, int id)
        {
            var note = data.Notes.FirstOrDefault(x => x.NoteID == id);

            if (note == null)
            {
                Message.ShowMessage($"⚠️ Note with ID {id} was not found.", ConsoleColor.Red);
                return;
            }

            bool isUpdating = true;
            do
            {
                ConsoleHelper.ClearScreen();
                ConsoleHelper.WriteColored($" 📓 Update Note (ID: {note.NoteID})", ConsoleColor.Cyan);
                ConsoleHelper.WriteColored($" Current Title   : {note.Title}");
                ConsoleHelper.WriteColored($" Current Status  : {(note.Status ? "Done" : "Not Done")}", note.Status ? ConsoleColor.Green : ConsoleColor.Red);
                ConsoleHelper.WriteColored(new string('-', 40));
                ConsoleHelper.WriteColored(" 1. Update Title", ConsoleColor.White);
                ConsoleHelper.WriteColored(" 2. Update Content", ConsoleColor.White);
                ConsoleHelper.WriteColored(" 3. Toggle Status (Done / Not Done)", ConsoleColor.White);
                ConsoleHelper.WriteColored(" 4. Back to Main Menu", ConsoleColor.Red);

                byte choice = ConsoleHelper.GetInput<byte>("\n 👉 Please enter an action you want to perform: ");
                ConsoleHelper.ClearScreen();

                switch (choice)
                {
                    case 1:
                        string newTitle = ConsoleHelper.GetInput<string>(" 👉 Enter new Title: ");
                        note.Title = newTitle;
                        Message.ShowMessage("✅ Title updated successfully!", ConsoleColor.Green);
                        break;
                    case 2:
                        string newContent = ConsoleHelper.GetInput<string>(" 👉 Enter new Content: ");
                        note.Content = newContent;
                        Message.ShowMessage("✅ Content updated successfully!", ConsoleColor.Green);
                        break;
                    case 3:
                        note.Status = !note.Status;
                        Message.ShowMessage($"✅ Status toggled successfully! New status: {(note.Status ? "Done" : "Not Done")}", ConsoleColor.Green);
                        break;
                    case 4:
                        isUpdating = false;
                        break;
                    default:
                        ConsoleHelper.WriteColored(" ❗ Invalid Operations", ConsoleColor.Red);
                        break;
                }

                if (isUpdating)
                {
                    ConsoleHelper.WaitingScreen();
                }
            } while (isUpdating);
        }
    }
}
