using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardRoom
{
    public interface Standard
    {
        String StandardRoom_roominfo(String name, int id);
        String StandardRoom_ReservedCustomer(int id);
        // String StandardRoom_CheckCustomer();
    }
}