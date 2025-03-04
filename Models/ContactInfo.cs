namespace appmvc.Models
{
    public class ContactInfo
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }
        public int? ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
