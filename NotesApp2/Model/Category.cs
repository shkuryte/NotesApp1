namespace NotesApp2.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<Note> Notes { get; set; }

        
    }
}
