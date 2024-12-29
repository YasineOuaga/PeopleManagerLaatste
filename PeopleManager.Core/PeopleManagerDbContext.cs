﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PeopleManager.Model;

namespace PeopleManager.Core
{
    public class PeopleManagerDbContext(DbContextOptions<PeopleManagerDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<Organization> Organizations => Set<Organization>();
        public DbSet<Person> People => Set<Person>();

        public void Seed()
        {
            var userName = "bavo.ketels@vives.be";
            var passwordHash = "AQAAAAIAAYagAAAAEFyTKZSPY/QSMMUHwj2ZQHI4C5xDOq4eI8B78IEbp3V2IHOJG9RpEwINQ03nljI4Ww=="; //Test123$

            var identityUser = new IdentityUser
            {
                UserName = userName,
                NormalizedUserName = userName.ToUpperInvariant(),
                PasswordHash = passwordHash
            };
            Users.Add(identityUser);
            SaveChanges(); //To get the User Id

            var vivesOrganization = new Organization
            {
                Name = "Vives University College",
                OwnerUserId = identityUser.Id
            };
            Organizations.Add(vivesOrganization);

            var youthOrganisation = new Organization
            {
                Name = "Young Blood Youth Group",
                OwnerUserId = identityUser.Id
            };
            Organizations.Add(youthOrganisation);

            var people = new List<Person>
            {
                new Person { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Organization = youthOrganisation},
                new Person { FirstName = "Jane", LastName = "Doe" },
                new Person { FirstName = "Emily", LastName = "Smith", Email = "emily.smith@example.com", Organization = vivesOrganization },
                new Person { FirstName = "Michael", LastName = "Brown" },
                new Person { FirstName = "Jessica", LastName = "Johnson" },
                new Person { FirstName = "William", LastName = "Davis", Email = "william.davis@example.com", Organization = youthOrganisation },
                new Person { FirstName = "Olivia", LastName = "Miller" },
                new Person { FirstName = "Henry", LastName = "Wilson", Email = "henry.wilson@example.com" },
                new Person { FirstName = "Ava", LastName = "Moore" },
                new Person { FirstName = "Sophia", LastName = "Taylor" },
                new Person { FirstName = "James", LastName = "Anderson", Email = "james.anderson@example.com", Organization = vivesOrganization },
                new Person { FirstName = "Isabella", LastName = "Thomas" },
                new Person { FirstName = "Alexander", LastName = "Jackson" },
                new Person { FirstName = "Mia", LastName = "White", Email = "mia.white@example.com", Organization = youthOrganisation },
                new Person { FirstName = "Charlotte", LastName = "Harris" },
                new Person { FirstName = "Benjamin", LastName = "Martin", Email = "benjamin.martin@example.com", Organization = vivesOrganization },
                new Person { FirstName = "Amelia", LastName = "Thompson" },
                new Person { FirstName = "Ethan", LastName = "Garcia", Organization = vivesOrganization },
                new Person { FirstName = "Harper", LastName = "Martinez", Organization = vivesOrganization },
                new Person { FirstName = "Lucas", LastName = "Robinson", Email = "lucas.robinson@example.com", Organization = youthOrganisation }
            };

            People.AddRange(people);

            SaveChanges();
        }
    }
}
