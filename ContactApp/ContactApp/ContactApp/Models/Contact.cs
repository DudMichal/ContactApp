using System.ComponentModel.DataAnnotations;

namespace ContactApp.Models
{
    //Definicja klasy Contact
    public class Contact
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public ContactCategory Category { get; set; }

        public string Subcategory { get; set; }

        public string Phone { get; set; }

        public DateTime BirthDate { get; set; }
    }
    //określenie możliwych kategori kontaktu
    public enum ContactCategory
    {
        Business,
        Personal,
        Other
    }
}
