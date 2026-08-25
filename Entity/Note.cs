namespace ToDoList.Entity
{
    public class Note
    {
        public int NoteID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
        public DateTime Deadline { get; set; } = DateTime.Now.AddDays(7);
    }
}
