using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MertKoleksiyoner.Models
{
    public class Role
    {
        public int Id { get; set; }

        public string roleName { get; set; }

        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }

        public List<User> Users { get; set; }

    }
}