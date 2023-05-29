
using Library.Data;
using Library.Models;
using System.Drawing.Text;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryLab4.Data
{
    public class BlahData
    {
       
        
        public static void DummyInsert(IApplicationBuilder appBuilder)
        {
            using (var servicescope = appBuilder.ApplicationServices.CreateScope())
            {
                var context = servicescope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                if (!context.Customers.Any())
                {
                    var customers = new Customer[]
                    {
                    new Customer {FirstName = "Aldor", LastName ="Bescher", Email = "aldor@gmail.com", Address = "Sundsvalls Gatan 3", City = "Sundsvall", PhoneNumber ="0704445648"},
                    new Customer {FirstName = "Emma",  LastName = "Hjalmarsson Wahlström", Email = "emma@gmail.com", Address = "Nybyvägen 38", City = "Vännäs", PhoneNumber ="0704568915"},
                    new Customer {FirstName = "Madde", LastName ="Lundström", Email = "madde@gmail.com", Address = "Huddikvägen 4", City = "Hudiksvall", PhoneNumber ="0704445648"},
                    new Customer {FirstName = "Malin", LastName ="Eriksson", Email = "emma@gmail.com", Address = "Duvedstoppen 18", City = "Duved", PhoneNumber ="0704445648"},
                    new Customer {FirstName = "Ellinor", LastName ="Vonck", Email = "ellinor@gmail.com", Address = "Hudiksvallsgatan 5", City = "Hudiksvall", PhoneNumber ="0704445648"},
                    new Customer {FirstName = "Oskar", LastName ="Ullsten", Email = "oskar@gmail.com", Address = "Köpmanholmsvägen 30", City = "Örnsköldsvik", PhoneNumber ="0704445648"},
                    };

                    context.Customers.AddRange(customers);
                    context.SaveChanges();
                }

                if (!context.Books.Any())
                {
                    var books = new Book[]
                    {
                    new Book { Title = "Där kräftorna sjunger", Author = "Delia Owens", Genre = "Roman", Published = DateTime.Parse("2020-04-29") },
                    new Book { Title = "Med döden som gäst", Author = "Carin Hjulström", Genre = "Deckare", Published = DateTime.Parse("2023-05-15")},
                    new Book { Title = "Andra Kvinnors liv", Author = "JoJo Moyes", Genre = "Roman", Published = DateTime.Parse("2023-04-12")},
                    new Book { Title = "Den tysta fågeln", Author = "Mohlin Nyström", Genre = "Deckare", Published = DateTime.Parse("2023-04-20")},
                    new Book { Title = "Au revoir Agneta", Author = "Emma Hamberg", Genre = "Feelgood, Roman", Published = DateTime.Parse("2023-03-16")}
                    };

                    context.Books.AddRange(books);
                    context.SaveChanges();
                }
            }
        }
    }
}
