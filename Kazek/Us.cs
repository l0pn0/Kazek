using Kazek.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kazek
{
    internal class Us
    {
        public static Kazino339Entities4 db = new Kazino339Entities4();
        public static User LoggedUser;
        public DbSet<User> Users { get; set; }

    }
}
