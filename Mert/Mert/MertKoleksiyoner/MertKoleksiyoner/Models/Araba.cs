using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MertKoleksiyoner.Models
{
    public class Araba
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string carName { get; set; }
        public string carModel { get; set; }
        public string carColor { get; set; }
        public string carYear { get; set; }
        public string carCompany { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}