using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Utilites.Models
{
    class Adress
    {
        public int AdressID { get; set; }
        public string AdressName { get; set; }
    }

    class AdressDB: DbContext
    {
        public AdressDB()
        {
                
        }

        public DbSet<Adress> Adresses { get; set; }
    }


}
