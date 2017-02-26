using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardRoom
{
    public interface Superior
    {
        String Superior_roominfo(String name, int id);
         String Superior_ReservedCustomer(int id);
      //  String Superior_CheckCustomer();
    }
}
