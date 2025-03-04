using System.Collections.Generic;

namespace appmvc.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string MName { get; set; }
        public ICollection<ContactInfo> Infos { get; set; }
        public Contact()
        {
            Infos = new List<ContactInfo>();
        }
    }
}
