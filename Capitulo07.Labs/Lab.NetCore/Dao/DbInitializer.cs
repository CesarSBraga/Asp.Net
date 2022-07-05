using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab.NetCore.Dao
{
    public class DbInitializer
    {
        public static void Initialize(EventosContext context)
        {
            context.Database.EnsureCreated();
        }

    }
}
