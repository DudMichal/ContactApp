using ContactApp.Models;
using ContactApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;



namespace ContactApp
{

    // stworzenie seedera do wypełnienia przykładowymi danymi
    public class Seeder
    {
        private readonly DataContext _context;

        public Seeder(DataContext context)
        {
            _context = context;
        }

        public void SeedDataContext()
        {
            if (_context.Contacts.Any())
            {
                return; 
            }

            _context.Contacts.AddRange(
                new Contact
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    Password = "Password123",
                    Category = ContactCategory.Business,
                    Subcategory = "Manager",
                    Phone = "123-456-7890",
                    BirthDate = new DateTime(1985, 5, 15)
                },
                new Contact
                {
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane.smith@example.com",
                    Password = "Password123",
                    Category = ContactCategory.Personal,
                    Subcategory = "Friend",
                    Phone = "098-765-4321",
                    BirthDate = new DateTime(1990, 8, 25)
                },
                new Contact
                {
                    FirstName = "Robert",
                    LastName = "Brown",
                    Email = "robert.brown@example.com",
                    Password = "Password123",
                    Category = ContactCategory.Other,
                    Subcategory = "Acquaintance",
                    Phone = "555-555-5555",
                    BirthDate = new DateTime(1978, 11, 5)
                }
            );

            _context.SaveChanges();
        }
    }
}
