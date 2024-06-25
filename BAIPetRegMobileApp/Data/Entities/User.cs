using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAIPetRegMobileApp.Data.Entities
{
    public class User
    {
        // Unique identifier for the user
        public int Id { get; set; }

        // Username for login
        public string Username { get; set; }

        // Password for login (it is advisable to store hashed passwords)
        public string Password { get; set; }

        // User's email address
        public string Email { get; set; }

        // Additional fields (optional)
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Indicates if the user is an admin or has special roles (optional)
        public bool IsAdmin { get; set; }

        // Date when the user was created (optional)
        public DateTime CreatedAt { get; set; }

        // Date when the user last logged in (optional)
        public DateTime LastLogin { get; set; }
    }
}
