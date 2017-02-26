using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace StandardRoom
{
 public   class Hotel : Suite, Superior, Moderate, Junior_Suite, Standard
    {
        Customer c = new Customer();

        public String ReserveRoom(String room,int Floor)
        {
         Boolean check=   c.ReserveRoom(room,Floor);
            if (check==true)
            {
                return " Your Room is Reserved ";
            }
            else
            {

                return " You have Entered invalid Type or FloorNo ";
            }
                
    
        }
        public string ShowFreeRoom(String room )
        {
            String s = "";
            if (room.Equals("Standard"))
            s= c.StandardRoomReservation();

            if (room.Equals("Moderate"))
                s = c.ModerateRoomReservation();

            if (room.Equals("Suite"))
                s = c.SuiteRoomReservation();

            if (room.Equals("Junior Suite"))
                s = c.Junior_SuiteRoomReservation();

            if (room.Equals("Superior"))
                s = c.SuperiorRoomReservation();


            return s;
            
        }

        /*public Boolean ReserveRoom(String r,int floor)
        {
           Boolean str= c.ReserveRoom(r,floor);
            return str;
        }
        */
        public int WriteHotelRooms(String room)
        {
            int floorno = 1;
            int roomno = 1;
            int roomlimit=0;
            if (room.Equals("Standard"))
            {
                floorno = 1;
                roomno = 1;
                roomlimit = 10;
            }
            else if (room.Equals("Moderate"))
            {
                floorno = 1;
                roomno = 11;
                roomlimit = 20;

            }
            else if (room.Equals("Superior"))
            {
                floorno = 1;
                roomno = 21;
                roomlimit = 30;

            }
            else if (room.Equals("Junior Suite"))
            {
                floorno = 1;
                roomno = 31;
                roomlimit = 40;

            }
            else if (room.Equals("Suite"))
            {
                floorno = 1;
                roomno = 41;
                roomlimit = 50;

            }
            else
                return 0;
            String r = room + ".xml";
            Console.WriteLine(r);

            for (;floorno<=5;floorno++)
            {
                for(;roomno<= roomlimit; roomno++)
                {
//                    Console.WriteLine("yes");

                    if (File.Exists(r) == false)
            {
  //                      Console.WriteLine("yesss");

                        XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.Indent = true;
                xmlWriterSettings.NewLineOnAttributes = true;
                using (XmlWriter xmlWriter = XmlWriter.Create(r, xmlWriterSettings))
                {
//                            Console.WriteLine("ysss");

                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("Hotel");

                    xmlWriter.WriteStartElement("Customer");
                    xmlWriter.WriteElementString("Name", "");
                    //xmlWriter.WriteElementString("Age", "");
                    //xmlWriter.WriteElementString("Gender", "");
                    xmlWriter.WriteElementString("IDCardNo", "");
                    //xmlWriter.WriteElementString("BalanceRs", "");
                    //xmlWriter.WriteElementString("DaysReserve", "");
                    xmlWriter.WriteElementString("FloorNo", floorno.ToString());
                    //xmlWriter.WriteElementString("RoomType", "Standard");
                    xmlWriter.WriteElementString("Roomno", roomno.ToString());
                   // xmlWriter.WriteElementString("CheckInTime", "");
                   // xmlWriter.WriteElementString("CheckOutTime", "");
                   // xmlWriter.WriteElementString("TimeRemaining", "");
                    xmlWriter.WriteElementString("Status", "notreserve");

                            xmlWriter.WriteEndElement();

                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                    xmlWriter.Flush();
                    xmlWriter.Close();
                }
            }
            else
            {
                XDocument xDocument = XDocument.Load(r);
                XElement root = xDocument.Element("Hotel");
                IEnumerable<XElement> rows = root.Descendants("Customer");
                XElement firstRow = rows.First();
                firstRow.AddBeforeSelf(
                   new XElement("Customer",
                   new XElement("Name", ""),
                   //new XElement("Age", ""),
                   //new XElement("Gender", ""),
                   new XElement("IDCardNo", ""),
                   //new XElement("BalanceRs", ""),
                   //new XElement("DaysReserve", ""),
              
                   new XElement("FloorNo", floorno.ToString()),
                   //new XElement("RoomType", "Standard"),
                   new XElement("Roomno", roomno.ToString()),
                   //new XElement("CheckInTime", ""),
                   //new XElement("CheckOutTime", ""),
                   //new XElement("TimeRemaining", ""),
                   new XElement("Status", "notreserve")));

                        

                        xDocument.Save(r);
            }

                }
                roomlimit = roomlimit + 10;

            }
            return 0;
        }
       

        public string Junior_Suite_ReservedCustomer(int Floor)
        {

            Boolean check = c.ReserveRoom("Junior Suite",Floor);
            if (check == true)
            {
                return " Your Room is Reserved ";
            }
            else
            {

                return " You have Entered invalid Type or FloorNo ";
            }
        //    throw new NotImplementedException();
        }

        public string Junior_Suite_roominfo(String name,int id)
        {
            c.Customer_roominfo(name,id );
            return "";
        }

     

        public string Moderate_ReservedCustomer(int Floor)
        {

            Boolean check = c.ReserveRoom("Moderat", Floor);
            if (check == true)
            {
                return " Your Room is Reserved ";
            }
            else
            {

                return " You have Entered invalid Type or FloorNo ";
            }
        }

        public string Moderate_roominfo(String name,int id)
        {
            c.Customer_roominfo(name,id);
          
            return "";
        }

      

        public string StandardRoom_ReservedCustomer(int Floor)
        {

            Boolean check = c.ReserveRoom("Standard", Floor);
            if (check == true)
            {
                return " Your Room is Reserved ";
            }
            else
            {

                return " You have Entered invalid Type or FloorNo ";
            }
        }

        public string StandardRoom_roominfo(String name,int id)
        {

            c.Customer_roominfo(name, id);
            return "";
            //   throw new NotImplementedException();
        }

      

        public string Suite_ReservedCustomer(int Floor)
        {

            Boolean check = c.ReserveRoom("Suite", Floor);
            if (check == true)
            {
                return " Your Room is Reserved ";
            }
            else
            {

                return " You have Entered invalid Type or FloorNo ";
            }
        }

        public string Suite_roominfo(String name, int id)
        {

            c.Customer_roominfo(name, id);
            return "";
        }

   

        public string Superior_ReservedCustomer( int Floor)
        {

            Boolean check = c.ReserveRoom("Superior",Floor);
            if (check == true)
            {
                return " Your Room is Reserved ";
            }
            else
            {

                return " You have Entered invalid Type or FloorNo ";
            }
        }

        public string Superior_roominfo(String name, int id)
        {

            c.Customer_roominfo(name, id);
            return "";
        }

        public Boolean GenerateReport()
        {
            c.CustomerReport();
            return true;
        }
      
    }
}
