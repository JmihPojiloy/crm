
namespace Notes.Domain
{
    public class Note
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }
        public string Status { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
