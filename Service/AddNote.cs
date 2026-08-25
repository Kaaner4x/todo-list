using ToDoList.Entity;

namespace ToDoList.Service
{
    public class AddNote
    {
        public static void Add(Data data)
        {
            string title = ConsoleHelper.GetInput<string>(" 👉 Enter a title: ");
            ConsoleHelper.ClearScreen();
            string content = ConsoleHelper.GetInput<string>(" 👉 Enter content: ");

            Note note = new Note()
            {
                NoteID = data.GetNextId(),
                Title = title,
                Content = content,
                CreatedDate = DateTime.Now,
                Status = false
            };

            data.Notes.Add(note);
            PersistenceService.Save(data);
        }
    }
}
