using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi
{
    public class ContactManager
    {
        public List<Contact> _contact = new List<Contact>();

        public ContactManager(List<Contact> contact)
        {
            _contact = contact;
        }

        public ContactManager()
        {
        }

        public void Start()
        {
            //Açılış
            Console.WriteLine(" Telefon rehberine hoş geldiniz!");
            Console.WriteLine(" Lütfen yapmak istediğiniz işlemi seçiniz: \n ****************************************** ");
            Console.WriteLine(" (1) Yeni Numara Kaydetmek");
            Console.WriteLine(" (2) Varolan Numarayı Silmek");
            Console.WriteLine(" (3) Varolan Numarayı Güncelleme");
            Console.WriteLine(" (4) Rehberi Listele");
            Console.WriteLine(" (5) Rehberde Arama Yapma");
            Console.WriteLine(" (6) Rehberden Çıkma");
        }
        //Kullanıcının yapmak istediği eylem
        public bool CheckNumber(int number)
        {
            if (number >= 1 && number <= 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Rehbere telefon ekleme
        public void AddPhone()
        {

            Console.WriteLine(" Numara Ekle \n ******************************************");
            Console.WriteLine(" Lütfen ismini giriniz: ");
            string firstName = Console.ReadLine();
            Console.WriteLine(" Lütfen soyisim giriniz: ");
            string lastName = Console.ReadLine();
            Console.WriteLine(" Lütfen telefon numarası giriniz: ");
            string phoneNo = Console.ReadLine();
            _contact.Add(new Contact(firstName, lastName, phoneNo));

            Console.WriteLine(" Kayıt başarılı!");
        }
        //Rehberden kayıt silme
        public void PhoneRemove()
        {
            Console.WriteLine(" Kayıt Silme \n ******************************************");
            try
            {
                Console.WriteLine(" Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:");
                string name = Console.ReadLine();
                int control = 0;
                foreach (var item in _contact)
                {
                    if (item.FirstName.ToLower() == name.ToLower() || item.LastName.ToLower() == name)
                    {
                        Console.WriteLine(" {0} kişiyi silmek istediğinize emin misiniz? (y/n)", name);
                        char select = Convert.ToChar(Console.ReadLine());
                        if (select == 'y')
                        {
                            int delete = _contact.IndexOf(item);
                            _contact.RemoveAt(delete);
                            control++;
                            Console.WriteLine(" Silme işlemi başarılı!");
                        }
                        else if (select == 'n')
                        {
                            Console.WriteLine(" Silme işlemi başarısız!");
                            control++;
                            break;
                        }
                        else
                        {
                            Console.WriteLine(" Lütfen geçerli bir değer giriniz!!!!");
                            control++;
                            return;
                        }
                    }

                    if (control == 0)
                    {
                        Console.WriteLine(" Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                        Console.WriteLine(" * Silmeyi sonlandırmak için: (1)");
                        Console.WriteLine(" * Yeniden denemek için: (2)");
                        int check = Convert.ToInt32(Console.ReadLine());
                    }
                }
            }
            catch (SystemException e)
            {
                Console.WriteLine(" Yanlış bilgi girdiniz lütfen kontrol ediniz!", e);
                throw;
            }
        }
        //Numara güncelleme
        public void UpdatePhone()
        {
            Console.WriteLine(" Kayıt Güncelleme \n  ******************************************");
            try
            {
                Console.WriteLine(" Lütfen güncellemek istediğiniz kişini adını ya da soyadını giriniz: ");
                string name = Console.ReadLine();
                int count = _contact.Count();
                int update = 0;
                for (var i = 0; i < count; i++)
                {
                    if (_contact[i].FirstName.ToLower() == name.ToLower() || _contact[i].LastName.ToLower() == name.ToLower())
                    {
                        string fullName = _contact[i].FirstName + _contact[i].LastName;
                        Console.WriteLine(
                            " {0} adlı kişi bulundu. Telefon numarası: {1}",
                            fullName,
                            _contact[i].PhoneNo);
                        Console.WriteLine(" Lütfen yeni telefon numarasını yazınız: ");
                        string newNo = Console.ReadLine();
                        _contact[i].PhoneNo = newNo;
                        Console.WriteLine(" Telefon başarıyla güncellendi!");
                        update++;
                        break;
                    }
                }

                if (update == 0)
                {
                    Console.WriteLine(" Güncelleme işlemi başarısız!!");
                }
            }
            catch (SystemException e)
            {
                Console.WriteLine(" Yanlış bilgi girdiniz lütfen kontrol ediniz!", e);
                throw;
            }

        }
        //Rehberi sıralama
        public void ListNumber()
        {
            Console.WriteLine(" Rehber \n ******************************************");
            try
            {
                foreach (var item in _contact)
                {
                    Console.WriteLine(" İsim: {0}", item.FirstName);
                    Console.WriteLine(" Soyisim: {0}", item.LastName);
                    Console.WriteLine(" Telefon Numarası: {0}", item.PhoneNo);
                }
            }
            catch (SystemException e)
            {
                Console.WriteLine(" Yanlış bilgi girdiniz lütfen kontrol ediniz!", e);
                throw;
            }

        }
        //Rehberde kayıtlı telefonları bulma
        public void SearchPhone()
        {
            Console.WriteLine(" Arama yapmak istediğiniz tipi seçiniz. \n ******************************************");
            try
            {
                Console.WriteLine(" İsim veya soyisime göre arama yapmak için: (1) ");
                Console.WriteLine(" Telefon numarasına göre arama yapmak için: (2)");
                int select = Convert.ToInt32(Console.ReadLine());
                if (select == 1)
                {
                    Console.WriteLine("Aramak istediğiniz kişini adını ya da soyadınız giriniz: ");
                    string name = Console.ReadLine();
                    foreach (var item in _contact)
                    {
                        if (item.FirstName.ToLower() == name.ToLower() || item.LastName.ToLower() == name.ToLower())
                        {
                            Console.WriteLine("İsim: {0}", item.FirstName);
                            Console.WriteLine("Soyisim: {0}", item.LastName);
                            Console.WriteLine("Telefon Numarası: {0}", item.PhoneNo);
                            Console.WriteLine("____________");
                        }
                        else
                        {
                            Console.WriteLine("Hatalı seçim!!");
                        }
                    }

                    Console.WriteLine("Arama işlemi tamamlandı.");
                }
                else if (select == 2)
                {
                    Console.WriteLine("Aramak istediğiniz telefon numarasını giriniz: ");
                    string no = Console.ReadLine();
                    foreach (var item in _contact)
                    {
                        if (item.PhoneNo == no)
                        {
                            Console.WriteLine("İsim: {0}", item.FirstName);
                            Console.WriteLine("Soyisim: {0}", item.LastName);
                            Console.WriteLine("Telefon Numarası: {0}", item.PhoneNo);
                            Console.WriteLine("____________");
                        }
                        else
                        {
                            Console.WriteLine("Hatalı seçim!!");
                        }
                    }
                    Console.WriteLine("Aram işlemi tamamlandı");
                }
            }
            catch (SystemException e)
            {
                Console.WriteLine(" Yanlış bilgi girdiniz lütfen kontrol ediniz!", e);
                throw;
            }
        }
    }
}


