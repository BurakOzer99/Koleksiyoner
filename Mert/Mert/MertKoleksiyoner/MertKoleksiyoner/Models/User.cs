using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MertKoleksiyoner.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }

        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }


    }
}