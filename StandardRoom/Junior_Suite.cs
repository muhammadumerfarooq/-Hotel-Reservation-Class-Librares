﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardRoom
{
    public interface Junior_Suite
    {
        String Junior_Suite_roominfo(String room, int floor);
        String Junior_Suite_ReservedCustomer(int floor);
        //  String Junior_Suite_CheckCustomer();
    }
}