using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Addressbok
{
    class Person
    {
        public string name;
        public string address;
        public string phone;
        public string email;

        public Person(string inputName, string inputAddress, string inputPhone, string inputEmail)
        {
            name = inputName;
            address = inputAddress;
            phone = inputPhone;
            email = inputEmail;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3}", name, address, phone, email);
        }

        public string SaveFields()
        {
            return String.Format("{0},{1},{2},{3}{4}", name, address, phone, email, Environment.NewLine);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> addressBook = new List<Person>();
            string path = @"c:/users/frage/address.txt";
            string[] lines = System.IO.File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] i = line.Split(',');
                addressBook.Add(new Person(i[0], i[1], i[2], i[3]));
            }
            string command = "";

            while (command != "quit")


            {
                command = Console.ReadLine();
                if (command == "new")
                {
                    Console.WriteLine("Skriv in namn");
                    string n = Console.ReadLine();
                    Console.WriteLine("Skriv in adress");
                    string a = Console.ReadLine();
                    Console.WriteLine("Skriv in telefonnummer");
                    string p = Console.ReadLine();
                    Console.WriteLine("Skriv in email");
                    string e = Console.ReadLine();

                    addressBook.Add(new Person(n, a, p, e));

                }

                else if (command == "list")
                {
                    for (int i = 0; i < addressBook.Count(); i++)
                    {
                        Console.WriteLine(addressBook[i].ToString());
                    }
                }

                else if (command == "remove")
                {
                    Console.WriteLine("Skriv in namnet p[ personen du vill ta bort");
                    string personToRemove = Console.ReadLine();
                    if (addressBook.Remove(addressBook.Find(x => x.name.Equals(personToRemove))))
                    {
                        Console.WriteLine("Togs bort");
                    }
                    else
                    {
                        Console.WriteLine("{0} hittades ej", personToRemove);
                    }
                }
                else if (command == "change")
                {
                    Console.WriteLine("Skriv in namnet p[ personen du vill 'ndra p[");
                    string nameToFind = Console.ReadLine();


                    Person pointer = addressBook.Find(x => x.name.Equals(nameToFind));
                    Console.WriteLine("Personen heter: " + pointer.name + " Tryck enter om du vill beh[lla det, annars skriv in det nya");
                    string change = Console.ReadLine();
                    if (change != "")
                    {
                        pointer.name = change;
                    }
                    Console.WriteLine("Personen bor p[: " + pointer.address + " Tryck enter om du vill beh[lla det, annars skriv in det nya");
                    change = Console.ReadLine();
                    if (change != "")
                    {
                        pointer.address = change;
                    }
                    Console.WriteLine("Personen har telefonnummer: " + pointer.phone + " Tryck enter om du vill beh[lla det, annars skriv in det nya");
                    change = Console.ReadLine();
                    if (change != "")
                    {
                        pointer.phone = change;
                    }
                    Console.WriteLine("Personen har email: " + pointer.email + " Tryck enter om du vill beh[lla det, annars skriv in det nya");
                    change = Console.ReadLine();
                    if (change != "")
                    {
                        pointer.email = change;
                    }



                }
            }

            Save(addressBook,path);

        }

        static void Save(List<Person> addr,string path)
        {
            
            System.IO.File.Delete(path);
            
            for (int i = 0; i < addr.Count(); i++)
            {


                System.IO.File.AppendAllText(path, addr[i].SaveFields());
                
       

            }
        }
    }
}
