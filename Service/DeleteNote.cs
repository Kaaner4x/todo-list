using ToDoList.Entity;

namespace ToDoList.Service
{
    public class DeleteNote
    {
        public static bool Delete(Data data, int id)
        {
            var note = data.Notes.FirstOrDefault(x => x.NoteID == id);
            if (note == null)
            {
                return false;
            }
            return data.Notes.Remove(note);
        }
    }
}
