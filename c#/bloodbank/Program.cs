using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace BloodBank
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DBlogin dBlogin = new DBlogin();
            DBdonor dBdonor = new DBdonor();
            DBuser dbuser = new DBuser();
            User user = new User();
            Login login = new Login();
            Donor donor = new Donor();


            Console.WriteLine("WELCOME TO BLOOD BANK");
            Console.WriteLine("HAI BLOOD BANK ADMIN !!\n ");



            Console.WriteLine("PLEASE LOGIN USING YOUR USERNAME AND PASSWORD");
            Console.WriteLine("USERNAME");
            string? username = Console.ReadLine();
            Console.WriteLine("\n");
            Console.WriteLine("PASSWORD");
            string? password = Console.ReadLine();
            Console.WriteLine("\n");
            dBlogin.loginCheck(username, password);

            int val;
            do
            {

                Console.WriteLine(" CHOOSE 1 - FOR USER DATA ACCESS\n");
                Console.WriteLine("CHOOSE 2 - FOR DONORS DATA ACCESS\n");
                val = int.Parse(Console.ReadLine());

                switch (val)
                {
                    case 1:
                        int ud;

                        Console.WriteLine("USERS DATA ACCESS");
                        Console.WriteLine("CHOOSE ANY OF THE BELOW OPTION\n");
                        Console.WriteLine(" 1.---VIEW THE USER RECORDS---\n");
                        Console.WriteLine(" 2.---INSERT USER RECORD ---\n");
                        Console.WriteLine(" 3.---UPDATE USER RECORD---\n");
                        Console.WriteLine(" 4.---DELETE USER RECORD ---\n");
                        Console.WriteLine(" 5.---SEARCH USER RECORD BY KEYWORDS---\n");

                        ud = int.Parse(Console.ReadLine());
                        switch (ud)
                        {
                            case 1:
                                Console.WriteLine("THE USER RECORDS ARE");
                                DataTable user_records = dbuser.Select();
                                Console.WriteLine();

                                foreach (DataColumn c in user_records.Columns)
                                {
                                    Console.Write($"\"{c.ColumnName}\",");
                                }
                                Console.WriteLine("      ");

                                foreach (DataRow dr in user_records.Rows)
                                {
                                    for (int i = 0; i < dr.ItemArray.Length; i++)
                                    {
                                        Console.Write($"\"{dr.ItemArray[i]}\"       ");
                                    }
                                    Console.WriteLine("      ");
                                }
                                break;
                            case 2:
                                Console.WriteLine("TO INSERT AN USER RECORD FILL THE FOLLOWING DETAILS\n");
                                Console.WriteLine("--ENTER USER NAME  :");
                                string? user_name = Console.ReadLine();
                                Console.WriteLine("\n");

                                Console.WriteLine("--ENTER  EMAIL :");
                                string? email = Console.ReadLine();
                                Console.WriteLine("\n");


                                Console.WriteLine("--ENTER PHONE NUMBER :");
                                string? phone = Console.ReadLine();
                                Console.WriteLine("\n");


                                Console.WriteLine("--ENTER PASSWORD  :");
                                string? pass_word = Console.ReadLine();
                                Console.WriteLine("\n");


                                Console.WriteLine("--ENTER FULL NAME  :");
                                string? fullname = Console.ReadLine();
                                Console.WriteLine("\n");

                                Console.WriteLine("--ENTER ADDRESS  :");
                                string? address = Console.ReadLine();
                                Console.WriteLine("\n");

                                DateTime addeddate = DateTime.Now;

                                //string formattedDateTime = addeddate.ToString("dddd, dd MMMM yyyy HH:mm:ss");

                                bool ins = dbuser.Insert(user_name, email, phone, pass_word, fullname, address, addeddate);

                                if (ins) { Console.WriteLine("INSERTED SUCCESSFULLY"); }
                                else { Console.WriteLine("NOT INSERTED"); }

                                break;
                            case 3:
                                Console.WriteLine("TO UPDATE USER RECORDS BASED ON USER ID");
                                Console.WriteLine("ENTER USER ID");
                                int uid = int.Parse(Console.ReadLine());
                                Console.WriteLine("\n");

                                Console.WriteLine("--ENTER USER NAME  :");
                                string? uname = Console.ReadLine();
                                Console.WriteLine("\n");

                                Console.WriteLine("--ENTER  EMAIL :");
                                string? emailid = Console.ReadLine();
                                Console.WriteLine("\n");


                                Console.WriteLine("--ENTER PHONE NUMBER :");
                                string? pho = Console.ReadLine();
                                Console.WriteLine("\n");


                                Console.WriteLine("--ENTER PASSWORD  :");
                                string? pawd = Console.ReadLine();
                                Console.WriteLine("\n");


                                Console.WriteLine("--ENTER FULL NAME  :");
                                string? fulname = Console.ReadLine();
                                Console.WriteLine("\n");

                                Console.WriteLine("--ENTER ADDRESS  :");
                                string? adress = Console.ReadLine();
                                Console.WriteLine("\n");

                                DateTime date = DateTime.Now;

                                //string formattedDateTime = addeddate.ToString("dddd, dd MMMM yyyy HH:mm:ss");

                                bool upda = dbuser.Update(uname, emailid, pho, pawd, fulname, adress, date, uid);

                                if (upda) { Console.WriteLine("UPDATED SUCCESSFULLY"); }
                                else { Console.WriteLine("NOT UPDATED"); }

                                break;
                            case 4:

                                Console.WriteLine("TO DELETE USER RECORDS BASED ON USER ID");
                                Console.WriteLine("ENTER USER ID");
                                int did = int.Parse(Console.ReadLine());
                                Console.WriteLine("\n");

                                bool dda = dbuser.Delete(did);

                                if (dda) { Console.WriteLine("DELETED SUCCESSFULLY"); }
                                else { Console.WriteLine("NOT DELETED"); }
                                break;
                            case 5:
                                Console.WriteLine("SEARCH USER RECORD BASED ON KEYWORDS IN  USER ID/NAME /ADDRESS/");
                                Console.WriteLine("ENTER THE KEYWORD");
                                string? key = Console.ReadLine();
                                Console.WriteLine("\n");

                                DataTable dts = dbuser.Search(key);

                                foreach (DataColumn c in dts.Columns)
                                {
                                    Console.Write($"\"{c.ColumnName}\",");
                                }
                                Console.WriteLine("      ");

                                foreach (DataRow dr in dts.Rows)
                                {
                                    for (int i = 0; i < dr.ItemArray.Length; i++)
                                    {
                                        Console.Write($"\"{dr.ItemArray[i]}\"       ");
                                    }
                                    Console.WriteLine("      ");
                                }
                                break;
                            default:
                                break;


                        }



                        break;
                    case 2:
                        {
                            Console.WriteLine("DONORS DATA ACCESS");
                            Console.WriteLine("CHOOSE ANY OF THE BELOW OPTION\n");
                            Console.WriteLine(" 1.---VIEW THE DONOR RECORDS---\n");
                            Console.WriteLine(" 2.---INSERT DONOR RECORD ---\n");
                            Console.WriteLine(" 3.---UPDATE DONOR RECORD---\n");
                            Console.WriteLine(" 4.---DELETE DONOR RECORD ---\n");
                            Console.WriteLine(" 5.---SEARCH DONOR RECORD BY KEYWORDS---\n");
                            Console.WriteLine(" 6.---COUNT DONORS BY BLOOD GROUP---\n");

                            int dd = int.Parse(Console.ReadLine());
                            switch (dd)
                            {
                                case 1:
                                    Console.WriteLine("THE DONOR RECORDS ARE");
                                    DataTable data_records = dBdonor.Select();
                                    Console.WriteLine();

                                    foreach (DataColumn c in data_records.Columns)
                                    {
                                        Console.Write($"\"{c.ColumnName}\",");
                                    }
                                    Console.WriteLine("      ");

                                    foreach (DataRow dr in data_records.Rows)
                                    {
                                        for (int i = 0; i < dr.ItemArray.Length; i++)
                                        {
                                            Console.Write($"\"{dr.ItemArray[i]}\"       ");
                                        }
                                        Console.WriteLine("      ");
                                    }
                                    break;
                                case 2:
                                    Console.WriteLine("TO INSERT AN DONOR RECORD FILL THE FOLLOWING DETAILS\n");
                                    Console.WriteLine("--ENTER DONOR FIRST NAME  :");
                                    string? fname = Console.ReadLine();
                                    Console.WriteLine("\n");

                                    Console.WriteLine("--ENTER DONOR LAST NAME  :");
                                    string? lname = Console.ReadLine();
                                    Console.WriteLine("\n");

                                    Console.WriteLine("--ENTER  EMAIL :");
                                    string? email = Console.ReadLine();
                                    Console.WriteLine("\n");


                                    Console.WriteLine("--ENTER PHONE NUMBER :");
                                    string? contact = Console.ReadLine();
                                    Console.WriteLine("\n");


                                    Console.WriteLine("--ENTER GENDER  :");
                                    string? gender = Console.ReadLine();
                                    Console.WriteLine("\n");



                                    Console.WriteLine("--ENTER ADDRESS  :");
                                    string? address = Console.ReadLine();
                                    Console.WriteLine("\n");

                                    Console.WriteLine("--ENTER BLOOD GROUP :");
                                    string? bloodgroup = Console.ReadLine();
                                    Console.WriteLine("\n");

                                    DateTime added_date = DateTime.Now;

                                    //string? added_by = username;

                                    Console.WriteLine("--ENTER USER ID:");
                                    int added_by =int.Parse( Console.ReadLine());
                                    Console.WriteLine("\n");




                                    //string formattedDateTime = addeddate.ToString("dddd, dd MMMM yyyy HH:mm:ss");

                                    bool ins = dBdonor.Insert(fname,lname,email,contact,gender,address,bloodgroup,added_date,added_by);
                                        

                                    if (ins) { Console.WriteLine("INSERTED SUCCESSFULLY"); }
                                    else { Console.WriteLine("NOT INSERTED"); }

                                    break;
                                case 3:
                                    Console.WriteLine("TO UPDATE DONOR RECORDS BASED ON USER ID");
                                    Console.WriteLine("ENTER DONOR ID");
                                    int did = int.Parse(Console.ReadLine());
                                    Console.WriteLine("\n");


                                    Console.WriteLine("--ENTER DONOR FIRST NAME  :");
                                    string? fnam = Console.ReadLine();
                                    Console.WriteLine("\n");

                                    Console.WriteLine("--ENTER DONOR LAST NAME  :");
                                    string? lnam = Console.ReadLine();
                                    Console.WriteLine("\n");

                                    Console.WriteLine("--ENTER  EMAIL :");
                                    string? emai = Console.ReadLine();
                                    Console.WriteLine("\n");


                                    Console.WriteLine("--ENTER PHONE NUMBER :");
                                    string? contac = Console.ReadLine();
                                    Console.WriteLine("\n");


                                    Console.WriteLine("--ENTER GENDER  :");
                                    string? gend = Console.ReadLine();
                                    Console.WriteLine("\n");



                                    Console.WriteLine("--ENTER ADDRESS  :");
                                    string? addre = Console.ReadLine();
                                    Console.WriteLine("\n");

                                    Console.WriteLine("--ENTER BLOOD GROUP :");
                                    string? blood = Console.ReadLine();
                                    Console.WriteLine("\n");

                                    DateTime date = DateTime.Now;

                                    //  string? add_by = username;
                                    Console.WriteLine("ENTER USER ID");
                                    int add_by=int.Parse(Console.ReadLine());

                                    //string formattedDateTime = addeddate.ToString("dddd, dd MMMM yyyy HH:mm:ss");

                                    bool upda = dBdonor.Update(fnam,lnam,emai,contac,gend,addre,blood,date,add_by,did);

                                    if (upda) { Console.WriteLine("UPDATED SUCCESSFULLY"); }
                                    else { Console.WriteLine("NOT UPDATED"); }

                                    break;
                                case 4:

                                    Console.WriteLine("TO DELETE DONOR RECORDS BASED ON USER ID");
                                    Console.WriteLine("ENTER DONOR ID");
                                    int di= int.Parse(Console.ReadLine());
                                    Console.WriteLine("\n");

                                    bool dda = dbuser.Delete(di);

                                    if (dda) { Console.WriteLine("DELETED SUCCESSFULLY"); }
                                    else { Console.WriteLine("NOT DELETED"); }
                                    break;
                                case 5:
                                    Console.WriteLine("SEARCH DONOR RECORD BASED ON KEYWORDS IN  USER ID/NAME /ADDRESS/");
                                    Console.WriteLine("ENTER THE KEYWORD");
                                    string? key = Console.ReadLine();
                                    Console.WriteLine("\n");

                                    DataTable dts = dbuser.Search(key);

                                    foreach (DataColumn c in dts.Columns)
                                    {
                                        Console.Write($"\"{c.ColumnName}\",");
                                    }
                                    Console.WriteLine("      ");

                                    foreach (DataRow dr in dts.Rows)
                                    {
                                        for (int i = 0; i < dr.ItemArray.Length; i++)
                                        {
                                            Console.Write($"\"{dr.ItemArray[i]}\"       ");
                                        }
                                        Console.WriteLine("      ");
                                    }
                                    break;
                                case 6:
                                    Console.WriteLine("TO COUNT DONORS FOR SPECIFIC BLOOD GROUP");
                                    Console.WriteLine("ENTER BLOOD GROUP TO SEARCH THEIR DONORS");
                                    string bgroup= Console.ReadLine();
                                    string count = dBdonor.countDonors(bgroup);
                                    Console.WriteLine("COUNT OF "+ bgroup +" IS"+ count);


                                    break;
                                default:
                                    break;


                            }




















                            break;
                        }
                    default:
                        Console.WriteLine("ENTER EITHER 1 OR 2");


                        break;
                }
                Console.Write("Press any key to continue . . .");
                Console.ReadKey();
                Console.Clear();
            } while (val != 0);


        }
    
    }
}
