using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StandardRoom;
//using System.Windows.Forms;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Windows;
namespace StandardRoom
{
    class Customer
    {
        public String Name { get; set; }
        public int Age { get; set; }
        public String Gender { get; set; }
        public int ID { get; set; }
        public double Balance { get; set; }
        public int Reserver_Days { get; set; }
        public int FloorNo { get; set; }
        public String RoomType { get; set; }
        public int RoomNo { get; set; }
        public String CheckIn { get; set; }
        public String CheckOut { get; set; }
        public String TimeRemainig { get; set; }

        public String Status { get; set; }
        public Double Paid { get; set; }
        public Customer()
        {
            Name = "";
            Age = 0;
            Gender = "";
            ID = 0;
            Balance = 0.0;
            Reserver_Days = 0;
            FloorNo = 0;
            RoomNo = 0;
            RoomType = "";
            CheckIn = "";
            CheckOut = "";
            TimeRemainig = "";

            Status = "";
        }
        
        public String Customer_daysreserve(String name, int id)
        {

            XmlTextReader reader = new XmlTextReader("Customer.xml");
            XmlNodeType typenode;

            Boolean namecheck = false;
            Boolean idcheck = false;
            String daysleft = "";

            while (reader.Read())
            {
                typenode = reader.NodeType;
                if (typenode == XmlNodeType.Element)
                {
                    if (reader.Name.Equals("Name"))
                    {
                        namecheck = false;
                        reader.Read();

                        if (reader.Value.Equals(name))
                        {
                            namecheck = true;
                        }
                    }
                    if (reader.Name.Equals("IDCardNo"))
                    {
                        namecheck = false;
                        reader.Read();
                        if (reader.Value.Equals(id.ToString()))
                        {
                            idcheck = true;
                        }
                    }

                    if (reader.Name.Equals("DaysReserve") && idcheck == true && namecheck == true)
                    {
                        namecheck = false;
                        reader.Read();

                        daysleft = reader.Value.ToString();
                        reader.Close();

                        return daysleft;
                    }
                }

            }
            reader.Close();

            return "0";
        }
        public String Customer_Roomtype(String name, int id)
        {

            XmlTextReader reader = new XmlTextReader("Customer.xml");
            XmlNodeType typenode;

            Boolean namecheck = false;
            Boolean idcheck = false;
            String daysleft = "";

            while (reader.Read())
            {
                typenode = reader.NodeType;
                if (typenode == XmlNodeType.Element)
                {
                    if (reader.Name.Equals("Name"))
                    {
                        namecheck = false;
                        reader.Read();

                        if (reader.Value.Equals(name))
                        {
                            namecheck = true;
                        }
                    }
                    if (reader.Name.Equals("IDCardNo"))
                    {
                        namecheck = false;
                        reader.Read();
                        if (reader.Value.Equals(id.ToString()))
                        {
                            idcheck = true;
                        }
                    }

                    if (reader.Name.Equals("RoomType") && idcheck == true && namecheck == true)
                    {
                        namecheck = false;
                        reader.Read();
                       
                        daysleft = reader.Value.ToString();
                        reader.Close();

                        return daysleft;
                    }
                }

            }
            reader.Close();

            return "0";
            

        }
        public String Customer_LastPayment(String name,int id)
        {

            XmlTextReader reader = new XmlTextReader("Customer.xml");
            XmlNodeType typenode;

            Boolean namecheck = false;
            Boolean idcheck = false;
            String daysleft = "";

            while (reader.Read())
            {
                typenode = reader.NodeType;
                if (typenode == XmlNodeType.Element)
                {
                    if (reader.Name.Equals("Name"))
                    {
                        namecheck = false;
                        idcheck = false;
                        reader.Read();
                      //      Console.Write("Name " + reader.Value);
                        if (reader.Value.Equals(name))
                        {
                            namecheck = true;
                        }

                    }
                    if (reader.Name.Equals("IDCardNo"))
                    {
                        //namecheck = false;
                        reader.Read();
                        //   Console.Write("Name " + reader.Value);
                        if (reader.Value.Equals(id.ToString()))
                        {
                           idcheck = true;
                        }
                    }

                    if (reader.Name.Equals("TimeRemaining") && idcheck==true && namecheck==true)
                    {
                        namecheck = false;
                        reader.Read();
                         //Console.Write("time " + reader.Value);
                        daysleft = reader.Value.ToString();
                        reader.Close();

                        return daysleft;
                    }
                }

            }
           // Console.WriteLine("yo");
            reader.Close();

            return "0";

        }

        public Boolean UpdateCustomer(String name, int id)
        {
            XmlTextReader reader = new XmlTextReader("Customer.xml");
            XmlNodeType typenode;

            Boolean namecheck = false;
            Boolean idcheck = false;

            while (reader.Read())
            {
                typenode = reader.NodeType;
                if (typenode == XmlNodeType.Element)
                {
                    if (reader.Name.Equals("Name"))
                    {
                        namecheck = false;
                        reader.Read();
                        //    Console.Write("Name " + reader.Value);
                        if (reader.Value.Equals(name))
                        {
                            namecheck = true;
                        }
                    }
                    if (reader.Name.Equals("IDCardNo"))
                    {
                        idcheck = false;
                        reader.Read();
                        if (reader.Value.Equals(id.ToString()))
                        {
                            idcheck = true;
                        }

                    }
                    if (reader.Name.Equals("BalanceRs"))
                    {
                        reader.Read();
                        if (reader.Value.Equals("0") && idcheck == true && namecheck == true)
                        {
                            reader.Close();
                            return true;
                        }
                        else if (idcheck == true && namecheck == true)
                        {
                            string money = reader.Value.ToString();
                            // Console.WriteLine("ho");
                            reader.Close();
                            Boolean checkcus = ReleaseCustomer_Payment(name, id, money);

                            if (checkcus == true)
                            {
                                reader.Close();

                                return true;

                            }
                            else
                            {
                                reader.Close();

                                return false;
                            }
                        }
                    }
                }


            }
            reader.Close();

            return false;
        }

        public Boolean ReleaseCustomer_Payment(String name,int id,string pay)
        {

//            XmlTextReader reader = new XmlTextReader("Customer.xml");
           // XmlNodeType typenode;

            String totaldays = Customer_daysreserve(Name, ID);

            String daysrrem = Customer_LastPayment(Name, ID);
            DateTime remdate = Convert.ToDateTime(daysrrem);

            // String checkin = Customer_CheckinTime(Name,ID);
            //   DateTime checkindate = Convert.ToDateTime(checkin);

            DateTime nowdatee = DateTime.Now;
            if (nowdatee.Date > remdate.Date)
            {
                Console.WriteLine(" Sir Your Staying Days In The Room Are More Than Reserve Days ");

                Console.WriteLine(" You Have To Pay 5% Fine On Each Day More Than Reserve Days ");

                int finedays = int.Parse((nowdatee.Date - remdate.Date).TotalDays.ToString());
                String typeroom = Customer_Roomtype(Name, ID);
                int bal = 0;
                if (typeroom.Equals("Standard"))
                {
                    bal = finedays * 300;
                }
                else if (typeroom.Equals("Moderate"))
                {

                    bal = finedays * 500;
                }
                else if (typeroom.Equals("Superior"))
                {
                    bal = finedays * 1000;
                }
                else if (typeroom.Equals("Junior Suite"))
                {
                    bal = finedays * 2000;
                }
                else
                {
                    bal = finedays * 5000;
                }


                int payment = int.Parse(pay.ToString());

                Console.WriteLine("Your Remaining Payment is " + payment);
                Console.WriteLine(" You have to Pay the Remaining Balance of Room To Hire Next Room");
                int mon;
                mon = int.Parse(Console.ReadLine());
                // int remaing = int.Parse(reader.Value);
                if (mon >= payment)
                {

                    Console.WriteLine("heres your change sir " + (mon - payment));
                    // reader.Close();

                    double moneey = CustomerTotalPaid(name,id);
                    moneey = moneey + payment;
                    //Console.WriteLine("Check it");
                    Console.WriteLine(moneey);
                    var doc = XDocument.Load("Customer.xml");
                    var node = doc.Descendants("Customer").FirstOrDefault(cd => cd.Element("IDCardNo").Value == id.ToString());
                    node.SetElementValue("BalanceRs", "0");
                    node.SetElementValue("Paid", moneey);
                    node.SetElementValue("CheckOutTime", DateTime.Now.ToString());
                    node.SetElementValue("Status", "notreserve");

                    doc.Save("Customer.xml");

                   // reader.Close();
                    //doc.Close();

                    return true;
                }
                else
                {
                    Console.WriteLine(" Your Cheque is less than your Room Expense, Enter Again ");
                    mon = int.Parse(Console.ReadLine());
                    if (mon >= payment)
                    {
                        Console.WriteLine("heres your change sir " + (mon - payment));
                        //   reader.Close();
                        double moneey = CustomerTotalPaid(name, id);
                        moneey = moneey + payment;

                        var doc = XDocument.Load("Customer.xml");
                        var node = doc.Descendants("Customer").FirstOrDefault(cd => cd.Element("IDCardNo").Value == id.ToString());
                        node.SetElementValue("BalanceRs", "0");
                        node.SetElementValue("Paid", moneey);
                        node.SetElementValue("CheckOutTime", DateTime.Now.ToString());
                        node.SetElementValue("Status", "notreserve");

                        doc.Save("Customer.xml");
                       // reader.Close();

                        return true;
                    }
                }

            }


            else
            {
            
                Console.WriteLine("Your Remaining Payment is " + pay);
                Console.WriteLine(" You have to Pay the Remaining Balance of Room To Hire Next Room");
                int mon;
                mon = int.Parse(Console.ReadLine());
                int remaing = int.Parse(pay);
                if (mon >= remaing)
                {
                    double moneey = CustomerTotalPaid(name, id);
                    moneey = moneey + remaing;

                    Console.WriteLine("heres your change sir " + (mon - remaing));
                  //  reader.Close();

                    var doc = XDocument.Load("Customer.xml");
                    var node = doc.Descendants("Customer").FirstOrDefault(cd => cd.Element("IDCardNo").Value == id.ToString());
                    node.SetElementValue("BalanceRs", "0");
                    node.SetElementValue("Paid", moneey);
                    node.SetElementValue("CheckOutTime", DateTime.Now.ToString());
                    node.SetElementValue("Status", "notreserve");
                  //  reader.Close();
                    doc.Save("Customer.xml");
                    

                    return true;
                }
                else
                {
                    Console.WriteLine(" Your Cheque is less than your Room Expense, Enter Again ");
                    mon = int.Parse(Console.ReadLine());
                    if (mon >= remaing)
                    {
                        Console.WriteLine("heres your change sir " + (mon - remaing));
                    //    reader.Close();

                        var doc = XDocument.Load("Customer.xml");
                        var node = doc.Descendants("Customer").FirstOrDefault(cd => cd.Element("IDCardNo").Value == id.ToString());
                        node.SetElementValue("BalanceRs", "0");
                        node.SetElementValue("Paid", mon - remaing);
                        node.SetElementValue("CheckOutTime", DateTime.Now.ToString());
                        node.SetElementValue("Status", "notreserve");

                        doc.Save("Customer.xml");
                      //  reader.Close();

                        return true;
                    }
                }
            }
            return false;
        }

        public Boolean DeleteCustomerRoom(string type,string name,int id)
        {
            
            var doc = XDocument.Load(type);
            var node = doc.Descendants("Customer").FirstOrDefault(cd => cd.Element("IDCardNo").Value == id.ToString());
            //  node.SetElementValue("BalanceRs", "0");
            // node.SetElementValue("Paid", mon - remaing);
            // node.SetElementValue("CheckOutTime", DateTime.Now.ToString());
            // node.SetElementValue("CheckOutTime", DateTime.Now.ToString());
            if (node!=null)
            node.SetElementValue("Status", "notreserve");

            doc.Save(type);

            return true;
        }
        public double CustomerTotalPaid(String name,int id)
        {

            XmlTextReader reader = new XmlTextReader("Customer.xml");
            XmlNodeType typenode;

            Boolean namecheck = false;
            Boolean idcheck = false;
            while (reader.Read())
            {
                typenode = reader.NodeType;
                if (typenode == XmlNodeType.Element)
                {
                //    Console.WriteLine(reader.Value);
                    if (reader.Name.Equals("Name"))
                    {
                        namecheck = false;
                        reader.Read();
                        //                         Console.Write("Name " + name.ToLower());

                        string firstname = reader.Value.ToLower();
                        if (firstname.Equals(name.ToString().ToLower()))
                        {
                  //                                      Console.Write("Name " + reader.Value);

                            namecheck = true;
                        }
                    }
                    if (reader.Name.Equals("IDCardNo"))
                    {
                        idcheck = false;
                        reader.Read();
                        if (reader.Value.Equals(id.ToString()))
                        {
                      //                               Console.Write(" Id " + reader.Value);
                    //        Console.WriteLine(namecheck);
                            idcheck = true;
                        }

                    }

            
                    if (reader.Name.Equals("Paid"))
                    {
                        reader.Read();
                      //  Console.WriteLine("Yess");
                        if (namecheck == true && idcheck == true)
                        {
                            
                            Console.WriteLine(" Customer Paid Money " + reader.Value.ToString());
                            double moneey = int.Parse(reader.Value.ToString());
                            reader.Close();
                            return moneey;
                        }
                    }

            

                }
            }


            return 0.0;
        }

        
        public String DeleteReservedRoom(String name,int id)
        {
            XmlTextReader reader = new XmlTextReader("Customer.xml");
            XmlNodeType typenode;

            Boolean namecheck = false;
            Boolean idcheck = false;
            while (reader.Read())
            {
                typenode = reader.NodeType;
                if (typenode == XmlNodeType.Element)
                {
                    if (reader.Name.Equals("Name"))
                    {
                        namecheck = false;
                        reader.Read();
                        // Console.Write("Name " + reader.Value);

                        if (reader.Value.Equals(Name.ToString()))
                        {
                            //   Console.Write("Name " + reader.Value);

                            namecheck = true;
                        }
                    }
                    if (reader.Name.Equals("IDCardNo"))
                    {
                        idcheck = false;
                        reader.Read();
                        if (reader.Value.Equals(ID.ToString()))
                        {
                            // Console.Write(" Id " + reader.Value);

                            idcheck = true;
                        }

                    }
                    if (reader.Name.Equals("RoomType"))
                    {
                        if (idcheck==true && namecheck==true)
                        {
                            reader.Read();
                            String r = reader.Value.ToString() + ".xml";
                            reader.Close();

                            return r;
                        }
                    }

                }
            }
            reader.Close();
            return "";
                }
        public String AddCustomerInfo(int floor, int room, String type)
        {
            Console.WriteLine(" If You Already Have Account ** Press 1 ");
            Console.WriteLine(" If You Don't have Your Account ** Press 2 ");
            int num;
            num = Int32.Parse(Console.ReadLine());
            
            if (num == 1)
            {
                Console.WriteLine("Enter Your Name : ");
                Name = Console.ReadLine();
                Console.WriteLine("Enter Password:");
                ID = int.Parse(Console.ReadLine());


                String r = DeleteReservedRoom(Name,ID);
                DeleteCustomerRoom(r,Name,ID);

                XmlTextReader reader = new XmlTextReader("Customer.xml");
                XmlNodeType typenode;

                Boolean namecheck = false;
                Boolean idcheck = false;
                while (reader.Read())
                {
                    typenode = reader.NodeType;
                    if (typenode == XmlNodeType.Element)
                    {
                        if (reader.Name.Equals("Name"))
                        {
                            namecheck = false;
                            reader.Read();
                            // Console.Write("Name " + reader.Value);

                            if (reader.Value.Equals(Name.ToString()))
                            {
                                //   Console.Write("Name " + reader.Value);

                                namecheck = true;
                            }
                        }
                        if (reader.Name.Equals("IDCardNo"))
                        {
                            idcheck = false;
                            reader.Read();
                            if (reader.Value.Equals(ID.ToString()))
                            {
                                // Console.Write(" Id " + reader.Value);

                                idcheck = true;
                            }

                        }

                        if (reader.Name.Equals("Status"))
                        {

                            reader.Read();
                      //   Console.WriteLine("  Status: " + reader.Value+" "+namecheck+" "+idcheck);

                            if ((reader.Value.Equals("reserve")) && namecheck == true && idcheck == true)
                            {
                                // idcheck = false;
                                // namecheck = false;
                                reader.Close();
                                Boolean x = UpdateCustomer(Name, ID);
                                reader.Close();

                                if (x == true)
                                {

                                    Console.WriteLine("Enter Gender");
                                    Gender = Console.ReadLine();
                                    Console.Write(" Enter Totel Days To Stay:");

                                    Reserver_Days = int.Parse(Console.ReadLine());
                                    // Console.Write(" Enter FloorNo:");

                                    FloorNo = floor;
                                    RoomNo = room;
                                    RoomType = type;
                                    DateTime toda = DateTime.Now;
                                    CheckIn = toda.ToString();
                                    //Console.WriteLine(toda);
                                    CheckOut = "";
                                    Status = "reserve";
                                    DateTime newdate = toda.AddDays(Reserver_Days);
                                    TimeRemainig = newdate.ToString();
                                    if (type.Equals("Standard"))
                                    {
                                        Balance = Reserver_Days * 300;
                                    }
                                    else if (type.Equals("Moderate"))
                                    {

                                        Balance = Reserver_Days * 500;
                                    }
                                    else if (type.Equals("Superior"))
                                    {
                                        Balance = Reserver_Days * 1000;
                                    }
                                    else if (type.Equals("Junior Suite"))
                                    {
                                        Balance = Reserver_Days * 2000;
                                    }
                                    else
                                    {
                                        Balance = Reserver_Days * 5000;
                                    }


                                    reader.Close();
                                    return "Customer Added";

                                }

                                else
                                    return "Customer Added";

                            }

                            if (reader.Value.Equals("notreserve") && namecheck == true && idcheck == true)
                            {
                                Console.WriteLine("Enter Gender");
                                Gender = Console.ReadLine();
                                Console.Write(" Enter Totel Days To Stay:");

                                Reserver_Days = int.Parse(Console.ReadLine());
                                // Console.Write(" Enter FloorNo:");

                                FloorNo = floor;
                                RoomNo = room;
                                RoomType = type;
                                DateTime toda = DateTime.Now;
                                CheckIn = toda.ToString();
                                //Console.WriteLine(toda);
                                CheckOut = "";
                                Status = "reserve";
                                DateTime newdate = toda.AddDays(Reserver_Days);
                                TimeRemainig = newdate.ToString();
                                if (type.Equals("Standard"))
                                {
                                    Balance = Reserver_Days * 300;
                                }
                                else if (type.Equals("Moderate"))
                                {

                                    Balance = Reserver_Days * 500;
                                }
                                else if (type.Equals("Superior"))
                                {
                                    Balance = Reserver_Days * 1000;
                                }
                                else if (type.Equals("Junior Suite"))
                                {
                                    Balance = Reserver_Days * 2000;
                                }
                                else
                                {
                                    Balance = Reserver_Days * 5000;
                                }


                                reader.Close();
                                return "Customer Added";


//                                return "Customer Added";
                            }

                            idcheck = false;
                            namecheck = false;
                        }
                       // reader.Close();
                    }
                }
                reader.Close();
                return "Customer not Added";
            }
            else
            {

               

                Boolean checkcustomer = true;

                Console.Write(" Enter Name:");
                Name = Console.ReadLine();

                Console.Write(" Enter ID:");
                ID = Int32.Parse(Console.ReadLine());
                Console.WriteLine(" Wait For 2s To Check IF Username and Password are not Taken");
                Console.WriteLine();
                String r = DeleteReservedRoom(Name, ID);
                DeleteCustomerRoom(r, Name, ID);

                checkcustomer = check_customer();


                while (checkcustomer) {
                 Console.WriteLine("UserName Or PassWord Already taken Enter Again");

                Console.Write(" Enter Name:");
                Name = Console.ReadLine();

                Console.Write(" Enter ID:");
                ID = Int32.Parse(Console.ReadLine());

                checkcustomer = check_customer();
                    
                }

                DeleteCustomerRoom(type, Name, ID);

                Console.Write(" Enter Age:");
                Age = Int32.Parse(Console.ReadLine());
                Console.Write(" Enter Gender:");

                Gender = Console.ReadLine();
                Console.Write(" Enter Totel Days To Stay:");

                Reserver_Days = Int32.Parse(Console.ReadLine());
                // Console.Write(" Enter FloorNo:");
                
                FloorNo = floor;
                RoomNo = room;
                RoomType = type;
                DateTime toda = DateTime.Now;
         

                CheckIn = toda.ToString();
                
                //Console.WriteLine(toda);
                CheckOut = "";
                Status = "reserve";
                DateTime newdate = toda.AddDays(Reserver_Days);
                TimeRemainig = newdate.ToString();
                if (type.Equals("Standard"))
                {
                    Balance = Reserver_Days * 300;
                }
                else if (type.Equals("Moderate"))
                {

                    Balance = Reserver_Days * 500;
                }
                else if (type.Equals("Superior"))
                {
                    Balance = Reserver_Days * 1000;
                }
                else if (type.Equals("Junior Suite"))
                {
                    Balance = Reserver_Days * 2000;
                }
                else
                {
                    Balance = Reserver_Days * 5000;
                }

              
                return "Customer Newly Added";

            }


            // return "Customer not Added";


        }

        public Boolean check_customer()
        {

            XmlTextReader reader = new XmlTextReader("Customer.xml");
            XmlNodeType typenode;

            Boolean namecheck = false;
            while (reader.Read())
            {
                typenode = reader.NodeType;
                if (typenode == XmlNodeType.Element)
                {
                    if (reader.Name.Equals("Name"))
                    {
                        namecheck = false;
                        reader.Read();
                        // Console.Write("Name " + reader.Value);

                        if (reader.Value.Equals(Name.ToString()))
                        {
                            //   Console.Write("Name " + reader.Value);

                            namecheck = true;
                        }
                    }
                    if (reader.Name.Equals("IDCardNo"))
                    {
                        reader.Read();
                        if (reader.Value.Equals(ID.ToString()) || namecheck==true)
                        {
                            reader.Close();
                            return true;
                        }

                    }

                    
                }
            }
            reader.Close();
                            return false;
        }
        public int find_room(String r, int floor)
        {

            XmlTextReader reader = new XmlTextReader(r);
            XmlNodeType type;
            Boolean check = false;
            int room = 0;

            while (reader.Read())
            {
                type = reader.NodeType;
                if (type == XmlNodeType.Element)
                {
                    if (reader.Name == "FloorNo")
                    {
                        reader.Read();
                        //   Console.WriteLine(reader.Value);
                        if (reader.Value.Equals(floor.ToString()))
                        {
                            check = true;
                        }

                    }
                    if (reader.Name == "Roomno" && check == true)
                    {
                        reader.Read();
                        // Console.WriteLine(reader.Value);

                        room = int.Parse(reader.Value);
                    }

                    if (reader.Name == "Status" && check == true)
                    {
                        reader.Read();
                        if (reader.Value.Equals("notreserve"))
                        {

                            reader.Close();
                            return room;
                        }


                    }

                }


            }
            return 0;
        }

        public Boolean register_room(String r)
        {
            if (File.Exists("Customer.xml") == false)
            {
                  Console.WriteLine(TimeRemainig);
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.Indent = true;
                xmlWriterSettings.NewLineOnAttributes = true;
                using (XmlWriter xmlWriter = XmlWriter.Create("Customer.xml", xmlWriterSettings))
                {
                    Double mon=CustomerTotalPaid(Name,ID);
                    Paid = mon + Paid;
                    Console.WriteLine(Paid);
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("Hotel");

                    xmlWriter.WriteStartElement("Customer");
                    xmlWriter.WriteElementString("Name", Name);
                    xmlWriter.WriteElementString("Age", Age.ToString());
                    xmlWriter.WriteElementString("Gender", Gender);
                    xmlWriter.WriteElementString("IDCardNo", ID.ToString());
                    xmlWriter.WriteElementString("BalanceRs", Balance.ToString());
                    xmlWriter.WriteElementString("Paid", Paid.ToString());
                    xmlWriter.WriteElementString("DaysReserve", Reserver_Days.ToString());
                    xmlWriter.WriteElementString("FloorNo", FloorNo.ToString());
                    xmlWriter.WriteElementString("RoomType", RoomType.ToString());
                    xmlWriter.WriteElementString("Roomno", RoomNo.ToString());
                    xmlWriter.WriteElementString("CheckInTime", CheckIn.ToString());
                    xmlWriter.WriteElementString("CheckOutTime", CheckOut.ToString());
                    xmlWriter.WriteElementString("TimeRemaining", TimeRemainig.ToString());
                    xmlWriter.WriteElementString("Status", Status.ToString());

                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                    xmlWriter.Flush();
                    xmlWriter.Close();
                }
                return true;
            }
            else
            {

                XDocument xDocument = XDocument.Load("Customer.xml");
                XElement root = xDocument.Element("Hotel");
                IEnumerable<XElement> rows = root.Descendants("Customer");
                XElement firstRow = rows.First();
                firstRow.AddBeforeSelf(
                           new XElement("Customer",
                           new XElement("Name", Name),
                           new XElement("Age", Age.ToString()),
                           new XElement("Gender", Gender.ToString()),
                           new XElement("IDCardNo", ID.ToString()),
                           new XElement("BalanceRs", Balance.ToString()),
                           new XElement("Paid", Paid.ToString()),

                           new XElement("DaysReserve", Reserver_Days.ToString()),

                           new XElement("FloorNo", FloorNo.ToString()),
                           new XElement("RoomType", RoomType.ToString()),
                           new XElement("Roomno", RoomNo.ToString()),
                           new XElement("CheckInTime", CheckIn.ToString()),
                           new XElement("CheckOutTime", CheckOut.ToString()),
                           new XElement("TimeRemaining", TimeRemainig.ToString()),
                           new XElement("Status", Status.ToString())));
                

                xDocument.Save("Customer.xml");
            
                return true;
            }

          


        }

        public Boolean Customer_Reserver(String r,int room)
        {
            var doc = XDocument.Load(r);
            var node = doc.Descendants("Customer").FirstOrDefault(cd => cd.Element("Roomno").Value==room.ToString());
            node.SetElementValue("Name", Name.ToString());
            node.SetElementValue("IDCardNo", ID.ToString());
            node.SetElementValue("Status", Status.ToString());


            doc.Save(r);
            return true;
            
        }

        public Boolean ReserveRoom(String room, int FloorNo)
        {
            String r = room + ".xml";
         
            int romreserve = find_room(r, FloorNo);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
            if (romreserve > 0)
            {
                String customer = AddCustomerInfo(FloorNo, romreserve, room);
                if (customer.Equals("Customer Added") || customer.Equals("Customer Newly Added"))
                {
                    String Choice;
                    Console.WriteLine(" Are You Sure, You Want To Register The Room  y/n");
                    Choice = Console.ReadLine();
                    if (Choice.Equals("Y") || Choice.Equals("y"))
                    {
                        Console.WriteLine("Your Balance :" + Balance);
                        Console.WriteLine("Pay Full or 60% of Balance To get Register Your Room ");
                        Double money = int.Parse(Console.ReadLine());
                        Paid = money;
                        if (money >= Balance || money >= Balance * (0.6))
                        {
                            Balance = Balance - money;
                            if (Balance <= 0)
                            {
                                Console.WriteLine("Sir here is Your Change " + -1 * (Balance));
                                Paid = money + Balance;
                            }
                            else
                            {
                                Console.WriteLine(" Your Remaining Balance is: " + Balance);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Your Amount is Less, Enter Again");
                            money = int.Parse(Console.ReadLine());
                            if (money >= Balance || money >= Balance * (0.6))
                            {
                                Balance = Balance - money;
                                if (Balance < 0)
                                {
                                    Console.WriteLine("Sir here is Your Change " + -1 * (Balance));
                                    Balance = 0;
                                }
                                else
                                {
                                    Console.WriteLine(" Your Remaining Payment is: " + Balance);
                                }
                            }
                        }
                        Boolean msg;
                        if (customer.Equals("Customer Newly Added"))
                            msg = register_room(room);
                        else
                        msg = Alreadyregister_room(room);

                        msg = Customer_Reserver(r,romreserve);

                        return msg;


                    }
                    
                }

                /* var doc = XDocument.Load(r);
                 var node = doc.Descendants("Customer").FirstOrDefault(cd => cd.Element("FloorNo").Value == FloorNo.ToString());
                 node.SetElementValue("Name", "UmerFarooq");
                 doc.Save("Standard.xml");*/

                //   return true;
            }

            return false;
        }

        public Boolean Alreadyregister_room(String room)
        {
            Double mon = CustomerTotalPaid(Name,ID);
            Paid = Paid + mon;
            var doc = XDocument.Load("Customer.xml");
            var node = doc.Descendants("Customer").FirstOrDefault(cd => cd.Element("IDCardNo").Value == ID.ToString());
            node.SetElementValue("Name", Name);
            node.SetElementValue("IDCardNo", ID);
            node.SetElementValue("Gender", Gender);
            node.SetElementValue("BalanceRs", Balance.ToString());
            node.SetElementValue("Paid", Paid.ToString());

            node.SetElementValue("DaysReserve", Reserver_Days.ToString());

            node.SetElementValue("FloorNo", FloorNo.ToString());
            node.SetElementValue("RoomType", RoomType.ToString());
            node.SetElementValue("Roomno", RoomNo.ToString());
            node.SetElementValue("CheckInTime", CheckIn.ToString());
            node.SetElementValue("CheckOutTime", CheckOut.ToString());
            node.SetElementValue("TimeRemaining", TimeRemainig.ToString());
            node.SetElementValue("Status", Status.ToString());



            doc.Save("Customer.xml"); 



            return true;
        }
        private void ReadHotelRooms(String name)
        {
            XmlTextReader reader = new XmlTextReader("Standard.xml");
            XmlNodeType type;
            while (reader.Read())
            {
                type = reader.NodeType;
                if (type == XmlNodeType.Element)
                {
                    if (reader.Name == "FloorNo")
                    {
                        reader.Read();
                        Console.Write("Floor No: " + reader.Value);
                    }
                    if (reader.Name == "Roomno")
                    {
                        reader.Read();
                        Console.Write("  Room No: " + reader.Value);
                    }
                    if (reader.Name == "Status")
                    {
                        reader.Read();
                        Console.WriteLine("  Status: " + reader.Value);
                    }

                }
            }



            //       Console.ReadKey();
        }
        
        public Boolean Customer_roominfo(String name,int id)
        {
        

            XmlTextReader reader = new XmlTextReader("Customer.xml");
            XmlNodeType typenode;

            Boolean namecheck = false;
            Boolean idcheck = false;
            while (reader.Read())
            {
                typenode = reader.NodeType;
                if (typenode == XmlNodeType.Element)
                {
                    if (reader.Name.Equals("Name"))
                    {
                        namecheck = false;
                        reader.Read();
//                         Console.Write("Name " + name.ToLower());

                        if (reader.Value.ToLower().Equals(name.ToString().ToLower()))
                        {
  //                             Console.Write("Name " + reader.Value);

                            namecheck = true;
                        }
                    }
                    if (reader.Name.Equals("IDCardNo"))
                    {
                        idcheck = false;
                        reader.Read();
                        if (reader.Value.Equals(id.ToString()))
                        {
    //                         Console.Write(" Id " + reader.Value);

                            idcheck = true;
                        }

                    }

                    if (reader.Name.Equals("BalanceRs"))
                    {
                        reader.Read();
                        if (namecheck == true && idcheck == true)
                        {
                            Console.WriteLine(" Customer Due Money "+reader.Value.ToString());
                        }
                    }

                    if (reader.Name.Equals("Paid"))
                    {
                        reader.Read();
                        if (namecheck == true && idcheck == true)
                        {
                            Console.WriteLine(" Customer Paid Money " + reader.Value.ToString());
                        }
                    }

                    if (reader.Name.Equals("DaysReserve"))
                    {
                        reader.Read();
                        if (namecheck == true && idcheck == true)
                        {
                            Console.WriteLine(" Customer Dayes Reserve For Room " + reader.Value.ToString());
                        }
                    }

                    if (reader.Name.Equals("FloorNo"))
                    {
                        reader.Read();
                        if (namecheck == true && idcheck == true)
                        {
                            Console.WriteLine(" Customer FloorNo " + reader.Value.ToString());
                        }
                    }

                    if (reader.Name.Equals("RoomType"))
                    {
                        reader.Read();
                        if (namecheck == true && idcheck == true)
                        {
                            Console.WriteLine(" Customer RoomType " + reader.Value.ToString());
                        }
                    }

                    if (reader.Name.Equals("Roomno"))
                    {
                        reader.Read();
                        if (namecheck == true && idcheck == true)
                        {
                            Console.WriteLine(" Customer Roomno " + reader.Value.ToString());
                        }
                    }

                    if (reader.Name.Equals("CheckInTime"))
                    {
                        reader.Read();
                        if (namecheck == true && idcheck == true)
                        {
                            Console.WriteLine(" Customer CheckInTime " + reader.Value.ToString());
                        }
                    }

                    if (reader.Name.Equals("CheckOutTime"))
                    {
                        reader.Read();
                        if (namecheck == true && idcheck == true)
                        {
                            Console.WriteLine(" Customer CheckOutTime " + reader.Value.ToString());
                        }
                    }

                    if (reader.Name.Equals("TimeRemaining"))
                    {
                        reader.Read();
                        if (namecheck == true && idcheck == true)
                        {
                            Console.WriteLine(" Customer TimeRemaining " + reader.Value.ToString());
                        }
                    }

                    if (reader.Name.Equals("Status"))
                    {

                        reader.Read();
                       // Console.WriteLine("  Status: " + reader.Value + " " + namecheck + " " + idcheck);

                        if (namecheck == true && idcheck == true)
                        {
                            Console.WriteLine(" Customer Status " + reader.Value.ToString());

                        }
                    }


                }
            }

                return true;
        }

        public Boolean CustomerReport()
        {
            String name = "";
            String id = "";
            String balance = "";
            String paid = "";
            String reserve = "";
            String florno = "";
            String romtype = "";
            String romno = "";
            String intime = "";
            String outtime = "";
            String remtime = "";
            Double Totalpaid = 0.0;

            XmlTextReader reader = new XmlTextReader("Customer.xml");
            XmlNodeType typenode;
            Boolean check = false;
          //  Boolean namecheck = false;
           // Boolean idcheck = false;
            while (reader.Read())
            {
                typenode = reader.NodeType;
                if (typenode == XmlNodeType.Element)
                {
                    if (reader.Name.Equals("Name"))
                    {
                        
             //           namecheck = false;
                        reader.Read();
                        //                         Console.Write("Name " + name.ToLower());
                        name = reader.Value.ToString();



                     //   if (reader.Value.ToLower().Equals(name.ToString().ToLower()))
                      //  {
                        //Console.Write("Name " + reader.Value);

                          //  namecheck = true;
                        //}
                    }
                    if (reader.Name.Equals("IDCardNo"))
                    {
               //         idcheck = false;
                        reader.Read();
                    //    if (reader.Value.Equals(id.ToString()))
                      //  {
                      //  Console.Write(" Id " + reader.Value);
                        id = reader.Value.ToString();

                        //    idcheck = true;
                        // }

                    }

                    if (reader.Name.Equals("BalanceRs"))
                    {
                        reader.Read();
                        //   if (namecheck == true && idcheck == true)
                        // {
                        //     Console.WriteLine(" Customer Due Money " + reader.Value.ToString());
                        balance = reader.Value.ToString();

                        //}
                    }

                    if (reader.Name.Equals("Paid"))
                    {
                        reader.Read();
                        // if (namecheck == true && idcheck == true)
                        // {
                        //  Console.WriteLine(" Customer Total Paid Money " + reader.Value.ToString());
                        paid = reader.Value.ToString();

                        //}
                    }

                    if (reader.Name.Equals("DaysReserve"))
                    {
                        reader.Read();
                        // if (namecheck == true && idcheck == true)
                        // {
                        //   Console.WriteLine(" Customer Dayes Reserve For Room " + reader.Value.ToString());
                        reserve = reader.Value.ToString();

                        // }
                    }

                    if (reader.Name.Equals("FloorNo"))
                    {
                        reader.Read();
                        //  if (namecheck == true && idcheck == true)
                        //  {
                        florno = reader.Value.ToString();

                        //    Console.WriteLine(" Customer FloorNo " + reader.Value.ToString());
                        //  }
                    }

                    if (reader.Name.Equals("RoomType"))
                    {
                        reader.Read();
                        //   if (namecheck == true && idcheck == true)
                        //  {
                        romtype = reader.Value.ToString();

                        //      Console.WriteLine(" Customer RoomType " + reader.Value.ToString());
                        //}
                    }

                    if (reader.Name.Equals("Roomno"))
                    {
                        reader.Read();
                        // if (namecheck == true && idcheck == true)
                        //{
                        romno = reader.Value.ToString();

                        //    Console.WriteLine(" Customer Roomno " + reader.Value.ToString());
                        //}
                    }

                    if (reader.Name.Equals("CheckInTime"))
                    {
                        reader.Read();
                        //if (namecheck == true && idcheck == true)
                        //{
                        DateTime thisDay = DateTime.Today;
                        // Display the date in the default (general) format.
                        
                        //Console.WriteLine();
                        // Display the date in a variety of formats.
                       // Console.WriteLine(thisDay.ToString("d"));
                        
                        intime = reader.Value.ToString();
                        DateTime oDate = Convert.ToDateTime(intime);
                        if (oDate.ToString("d").Equals(thisDay.ToString("d")))
                        {
                            check = true;
                            Totalpaid = Totalpaid + int.Parse(paid);
                          
                        }
                        //   Console.WriteLine(" Customer CheckInTime " + reader.Value.ToString());
                        //}
                        else

                            check = false;
                    }

                    if (reader.Name.Equals("CheckOutTime"))
                    {
                        reader.Read();
                        //if (namecheck == true && idcheck == true)
                        //{
                        //  Console.WriteLine(" Customer CheckOutTime " + reader.Value.ToString());
                        //}
                        outtime = reader.Value.ToString();
                    }

                    if (reader.Name.Equals("TimeRemaining"))
                    {
                        reader.Read();
                        // if (namecheck == true && idcheck == true)
                        //{
                        //    Console.WriteLine(" Customer TimeRemaining " + reader.Value.ToString());
                        //}
                        remtime = reader.Value.ToString();
                    }

                    if (reader.Name.Equals("Status"))
                    {

                        reader.Read();
                        // Console.WriteLine("  Status: " + reader.Value + " " + namecheck + " " + idcheck);

                     //   if (namecheck == true && idcheck == true)
                       // {
                       if (check==true)
                        {
                          
                            Console.WriteLine(" **** *****           *****               ****                  *****");

                            Console.WriteLine(" Customer Name "+name);
                            Console.WriteLine(" Customer ID "+id);
                            Console.WriteLine(" Customer Remaining Payment "+balance);
                            Console.WriteLine(" Customer Total Paid " + paid);

                            Console.WriteLine(" Customer Reserve Days " + reserve);
                            Console.WriteLine(" Customer FloorNo " + FloorNo);
                            Console.WriteLine(" Customer RoomType " + romtype);
                            Console.WriteLine(" Customer Roomno " + romno);
                            Console.WriteLine(" Customer CheckIn Time " + intime);
                            Console.WriteLine(" Customer CheckOut Time " + outtime);
                            Console.WriteLine(" Customer Remianing Time " + remtime);
                            Console.WriteLine(" Customer Status " + reader.Value.ToString());

                            Console.WriteLine(" **** *****           *****               ****                  *****");
                            Console.WriteLine();
                            check = false;
                        }

                    }


                }
            }
            Console.WriteLine("Total Todays Profit is " + Totalpaid);

            return true;

      
        }
        public String StandardRoomReservation()
        {
            //Console.WriteLine("Which Room Do You Want ?") ;
            Console.WriteLine(" Standand :  It has basic, standard amenities and furnishings. ");
            Console.WriteLine("Price is by default Rs.300 / 24 Hours .");
            Console.WriteLine("This Hotel contains total of 50 rooms of this type, 10 on each floor");
            Console.WriteLine("Total Standard Rooms Free are ");
            ReadHotelRooms("Standard");

            return "Room Reserved";
        }

        public String ModerateRoomReservation()
        {
            //Console.WriteLine("Which Room Do You Want ?") ;
            Console.WriteLine("It may refer to the room view as well as the size and type of furnishings offered ");
            Console.WriteLine("Price is by default Rs. 500 / 24 Hours and can be changed. ");
            Console.WriteLine("This Hotel contains total of 50 rooms of this type, 10 on each floor");
            Console.WriteLine("Total Moderate Rooms Free are ");
            ReadHotelRooms("Moderate");

            return "Room Reserved";
        }

        public String SuiteRoomReservation()
        {
            Console.WriteLine("A Suite is usually two or more rooms clearly defined; a bedroom and a living or sitting room, with a door that closes between them.");
            Console.WriteLine("Price is by default Rs. 5000 / 24 Hours and can be changed. ");
            Console.WriteLine("This Hotel contains total of 50 rooms of this type, 10 on each floor");
            Console.WriteLine("Total Suite Rooms Free are ");
            ReadHotelRooms("Suite");

            return "Room Reserved";
        }

        public String Junior_SuiteRoomReservation()
        {
            Console.WriteLine("A Junior Suite is usually two or more rooms clearly defined; a bedroom and a living or sitting room, with a door that closes between them.");
            Console.WriteLine("Price is by default Rs. 2000 / 24 Hours and can be changed. ");
            Console.WriteLine("This Hotel contains total of 50 rooms of this type, 10 on each floor");
            Console.WriteLine("Total Junior Suite Rooms Free are ");
            ReadHotelRooms("Junior Suite");

            return "Room Reserved";
        }

        public String SuperiorRoomReservation()
        {
            Console.WriteLine("It's supposed to meansuperior to a standard room in both size and furnishings, but it often refers to just the view");
            Console.WriteLine("Price is by default Rs. 1000 / 24 Hours and can be changed. ");
            Console.WriteLine("This Hotel contains total of 50 rooms of this type, 10 on each floor");
            Console.WriteLine("Total Superior Rooms Free are ");
            ReadHotelRooms("Superior");

            return "Room Reserved";
        }
        public String CheckIn_Customer()
        {

            return "";
        }

        public void read()
        {
            XmlTextReader reader = new XmlTextReader("Customer.xml");
            XmlNodeType typenode;

            while (reader.Read())
            {
                typenode = reader.NodeType;
                if (typenode == XmlNodeType.Element)
                {
                    if (reader.Name.Equals("Name"))
                    {
                        reader.Read();
                        Console.Write("Name " + reader.Value);

                        if (reader.Value.Equals(Name.ToString()))
                        {
                               Console.Write("Name " + reader.Value);

                           
                        }
                    }
                    if (reader.Name.Equals("IDCardNo"))
                    {
                        reader.Read();
                        if (reader.Value.Equals(ID.ToString()))
                        {
                            Console.Write(" Id " + reader.Value);

                        }

                    }


                }

            }

        }
    }

}
