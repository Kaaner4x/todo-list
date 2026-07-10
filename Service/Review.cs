using ToDoList.Entity;

namespace ToDoList.Service
{
    public class Review
    {
        public static void ReviewNote(Data data, int id)
        {
            var note = data.Notes.FirstOrDefault(x => x.NoteID == id);

            if (note == null)
            {
                Console.WriteLine($"Note with ID {id} was not found.");
                return;
            }

            Console.WriteLine(note.Content);
        }
    }
}