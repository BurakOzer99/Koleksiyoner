using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MertKoleksiyoner.Models.MultiModel
{
    public class MultiModel
    {
        public List<User> Users { get; set; }

        public List<Role> Roles { get; set; }

        public User User { get; set; }

        public List<Araba> Arabas { get; set; }
    }
}