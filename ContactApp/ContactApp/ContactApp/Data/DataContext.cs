using ContactApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactApp.Data
{
    //Konteks bazy danych
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        //Zbiór encji z bazy danych
        public DbSet<Contact> Contacts { get; set; }

    }
}
