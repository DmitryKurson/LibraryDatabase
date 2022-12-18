// See https://aka.ms/new-console-template for more information
using LibraryDatabase.Entities;
using Microsoft.EntityFrameworkCore;
//"C:\\Users\\Dmitry\\source\\repos\\LibraryDatabase\\LibraryDatabase"
LibraryContext db = new LibraryContext();
db.Database.Migrate();
Author lesya_ukrainka = new Author { authorID = 2, surname_name_lastname = "Lesya Kosach Petrivna", nationality = "ukrainian", literature_direction = "realism" };
Author vasil_symonenko = new Author { authorID = 3, surname_name_lastname = "Vasil Symonenko Andriyovich", nationality = "ukrainian", literature_direction = "sentimentalism" };

db.Author.Add(lesya_ukrainka);
db.Author.Add(vasil_symonenko);
db.Author.Remove(vasil_symonenko);
db.SaveChanges();


