namespace ToDoList.Entity
{
    public class Data
    {
        private static Random _random = new Random();

        public List<Note> Notes { get; set; }

        public Data()
        {
            Notes = new List<Note>
            {
                new Note()
                {
                    NoteID = _random.Next(1000),
                    Title = "Example",
                    Content = "This is an example note.",
                    CreatedDate = DateTime.Now,
                    Status = true
                }
            };
        }
    }
}
