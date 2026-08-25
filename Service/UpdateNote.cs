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
                // Aşağıdaki satırı ekleyerek o anki bitiş tarihini de gösteriyoruz:
                ConsoleHelper.WriteColored($" Current Deadline: {note.Deadline:yyyy-MM-dd}");
                ConsoleHelper.WriteColored($" Current Status  : {(note.Status ? "Done" : "Not Done")}", note.Status ? ConsoleColor.Green : ConsoleColor.Red);
                ConsoleHelper.WriteColored(new string('-', 40));
                ConsoleHelper.WriteColored(" 1. Update Title", ConsoleColor.White);
                ConsoleHelper.WriteColored(" 2. Update Content", ConsoleColor.White);
                ConsoleHelper.WriteColored(" 3. Toggle Status (Done / Not Done)", ConsoleColor.White);
                ConsoleHelper.WriteColored(" 4. Update Deadline", ConsoleColor.White); // 👈 Yeni Seçenek
                ConsoleHelper.WriteColored(" 5. Back to Main Menu", ConsoleColor.Red);     // 👈 4'tü, 5 yaptık

                byte choice = ConsoleHelper.GetInput<byte>("\n 👉 Please enter an action you want to perform: ");
                ConsoleHelper.ClearScreen();

                switch (choice)
                {
                    case 1:
                        string newTitle = ConsoleHelper.GetInput<string>(" 👉 Enter new Title: ");
                        note.Title = newTitle;
                        PersistenceService.Save(data);
                        Message.ShowMessage("✅ Title updated successfully!", ConsoleColor.Green);
                        break;
                    case 2:
                        string newContent = ConsoleHelper.GetInput<string>(" 👉 Enter new Content: ");
                        note.Content = newContent;
                        PersistenceService.Save(data);
                        Message.ShowMessage("✅ Content updated successfully!", ConsoleColor.Green);
                        break;
                    case 3:
                        note.Status = !note.Status;
                        PersistenceService.Save(data);
                        Message.ShowMessage($"✅ Status toggled successfully! New status: {(note.Status ? "Done" : "Not Done")}", ConsoleColor.Green);
                        break;
                    case 4: // 👈 YENİ CASE
                        DateTime newDeadline = ConsoleHelper.GetInput<DateTime>(" 👉 Enter new Deadline (yyyy-MM-dd): ");
                        note.Deadline = newDeadline;
                        PersistenceService.Save(data);
                        Message.ShowMessage("✅ Deadline updated successfully!", ConsoleColor.Green);
                        break;
                    case 5: // 👈 Geri dönüş seçeneği 5 oldu
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