using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.AppData
{
    class Connect
    {
        public static DatabaseEntities c;
        public static DatabaseEntities context
        {
            get
            {
                if (c == null)
                    c = new DatabaseEntities();
                return c;
            }
        }

    }
}
