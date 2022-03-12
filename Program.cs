using System;

namespace TelefonRehberi
{
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            ContactManager contactManager = new ContactManager();

            contactManager.Start();
            int select = Convert.ToInt32(Console.ReadLine());
            while (contactManager.CheckNumber(select))
            {
                if (select == 1)
                {
                    contactManager.AddPhone();
                }
                else if (select == 2)
                {
                    contactManager.PhoneRemove();
                }
                else if (select == 3)
                {
                    contactManager.UpdatePhone();
                }
                else if (select == 4)
                {
                    contactManager.ListNumber();
                }
                else if (select == 5)
                {
                    contactManager.SearchPhone();
                }
                else if (select == 6)
                {
                    Console.WriteLine("Güle güle!");
                    break;
                }
                else
                {
                    Console.WriteLine(" Yanlış Seçim");
                    break;
                }
                contactManager.Start();
                select = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine(" Rehber: ");
            contactManager.ListNumber();
            Console.WriteLine(" Rehberden çıkıyorsunuz!");
            Console.ReadKey();
        }
    }
}
