using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardRoom
{
    public interface Suite
    {
        String Suite_roominfo(String name, int id);
        String Suite_ReservedCustomer(int id);
        // String Suite_CheckCustomer();
    }
}