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
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt " +
                    "ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris " +
                    "nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse" +
                    " cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa" +
                    " qui officia deserunt mollit anim id est laborum.",
                    CreatedDate = DateTime.Now,
                    Status = true
                }
            };
        }
    }
}
