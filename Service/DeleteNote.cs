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
            bool isDeleted  =  data.Notes.Remove(note);
            if (isDeleted)
            {
                PersistenceService.Save(data);
            }
            return isDeleted;
        }
        
    }
    
}
