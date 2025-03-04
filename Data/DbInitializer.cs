using appmvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace appmvc.Data
{
    public class DbInitializer
    {
        public static void Initialize(PhoneBookContext context)
        {
            context.Database.EnsureCreated();

            if (context.Contacts.Any())
            {
                return;
            }

            ContactInfo i1 = new ContactInfo() { Phone = "+375 (29) 876-48-87", Note = "Банк" };
            ContactInfo i2 = new ContactInfo() { Phone = "+375 (44) 138-18-54", Note = "Начальник" };
            ContactInfo i3 = new ContactInfo() { Phone = "+375 (44) 252-85-43", Note = "Автомастерская" };
            ContactInfo i4 = new ContactInfo() { Phone = "+375 (33) 428-42-71", Note = "Тренер фитнес-зала" };
            ContactInfo i5 = new ContactInfo() { Phone = "+375 (29) 140-61-65", Note = "Охрана" };
            ContactInfo i6 = new ContactInfo() { Phone = "+375 (44) 574-29-82", Note = "5 элемент" };
            ContactInfo i7 = new ContactInfo() { Phone = "+375 (29) 681-68-47", Note = "Палыч с рыбалки" };
            ContactInfo i8 = new ContactInfo() { Phone = "+375 (29) 815-41-93", Note = "Подружка Машка" };
            ContactInfo i9 = new ContactInfo() { Phone = "+375 (33) 145-88-17", Note = "Бассейн" };
            ContactInfo i10 = new ContactInfo() { Phone = "+375 (29) 768-18-83", Note = "Кинолог" };
            context.ContactInfos.AddRange(new List<ContactInfo> { i1, i2, i3, i4, i5, i6, i7, i8, i9, i10 });
            context.SaveChanges();


            Contact c1 = new Contact() { FName = "Максим", LName = "Жаров", MName = "Андреевич", Infos = new List<ContactInfo> { i10, i5 } };
            Contact c2 = new Contact() { FName = "Петр", LName = "Иванов", MName = "Степанович", Infos = new List<ContactInfo> { i7 } };
            Contact c3 = new Contact() { FName = "Дарья", LName = "Абрамович", MName = "Васильевна", Infos = new List<ContactInfo> { i4, i2, i6, i3 } };
            Contact c4 = new Contact() { FName = "Ольга", LName = "Демьянович", MName = "Сергеевна", Infos = new List<ContactInfo> { i8 } };
            Contact c5 = new Contact() { FName = "Антон", LName = "Мартынов", MName = "Львович", Infos = new List<ContactInfo> { i9, i1 } };
            context.Contacts.AddRange(new List<Contact> { c1, c2, c3, c4, c5 });
            context.SaveChanges();
        }
    }
}
