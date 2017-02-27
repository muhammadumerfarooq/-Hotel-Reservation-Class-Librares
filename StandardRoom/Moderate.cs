using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardRoom
{
    public interface Moderate
    {
        String Moderate_roominfo(String name, int id);
        String Moderate_ReservedCustomer(int id);
        /// String Moderate_CheckCustomer();
    }
}