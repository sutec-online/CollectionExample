using System;
using System.Collections.Generic;
using System.Xml;

namespace Contacts
{
    class Program
    {
        private static SortedDictionary<string, SortedDictionary<string, string>> lists = new SortedDictionary<string, SortedDictionary<string, string>>();

        static void Main(string[] args)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load("contacts.xml");

            XmlNodeList contacts = xml.SelectNodes("/contacts/contact");
            foreach (XmlNode contact in contacts)
            {
                string name = contact.Attributes["name"].Value;
                string city = contact.Attributes["city"].Value;
                string phone = contact.Attributes["phone"].Value;

                if (!lists.ContainsKey(city))
                    lists.Add(city, new SortedDictionary<string, string>());
                lists[city].Add(name, phone);
            }

            foreach (KeyValuePair<string, SortedDictionary<string, string>> city in lists)
            {
                Console.WriteLine(city.Key + " : ");
                foreach (KeyValuePair<string, string> nameAndPhone in city.Value)
                {
                    Console.WriteLine("\t" + nameAndPhone.Key + ":" + nameAndPhone.Value);
                }
            }

            Console.ReadLine();
        }
    }
}
