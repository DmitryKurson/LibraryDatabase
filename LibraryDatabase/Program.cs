// See https://aka.ms/new-console-template for more information
using LibraryDatabase.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
//"C:\\Users\\Dmitry\\source\\repos\\LibraryDatabase\\LibraryDatabase"
LibraryContext db = new LibraryContext();
    db.Database.Migrate();
Author lesya_ukrainka = new Author { authorID = 2, surname_name_lastname = "Lesya Kosach Petrivna", nationality = "ukrainian", literature_direction = "realism" };
Author vasil_symonenko = new Author { authorID = 3, surname_name_lastname = "Vasil Symonenko Andriyovich", nationality = "ukrainian", literature_direction = "sentimentalism" };

//db.Author.Add(lesya_ukrainka);
db.Author.Add(vasil_symonenko);
db.Author.Remove(vasil_symonenko);
//db.SaveChanges();

OriginalBook kobzar = new OriginalBook { count_of_pages = 115 };                 // t. shev
OriginalBook lisova_pisnya = new OriginalBook { count_of_pages = 636};           // l. ukrainka
OriginalBook zbirnyk_virshiv_ta_kazok = new OriginalBook {count_of_pages = 201}; // l. ukrainka
OriginalBook hiba_revut_voliy = new OriginalBook { count_of_pages = 384 };  // p. myirniy
OriginalBook poviya = new OriginalBook { count_of_pages = 502 };            // p. myirniy
OriginalBook holodna_volya = new OriginalBook { count_of_pages = 202 };     // p. myirniy
Author panas_myrniy = new Author { authorID = 4 };
//Reader some_reader = new Reader { surname_name_lastname = "Ivan Goncharenko" };

db.books.AddRange(kobzar, lisova_pisnya,zbirnyk_virshiv_ta_kazok, hiba_revut_voliy, poviya, holodna_volya);
db.Author.Add(panas_myrniy);
//db.reader1.Add(some_reader);
//db.SaveChanges();


using (LibraryContext context = new LibraryContext())
{
    /*
    // UNION
    var result_union = context.Author.Select(x => new { x.authorID, x.surname_name_lastname }).Union(context.Author2.Select(x => new { x.authorID, x.surname_name_lastname }));
    
    // EXCEPT
    var result_except = context.Author.Except(context.Author2);
    
    // INTERSECT
    var result_intersect = context.Author.Intersect(context.Author2);

    // JOIN
    //var result_join = context.Author.Join(context.has_been_written,
    //    a => a.has_been_written_,
    //    c => c.author,
    //    (p, c) => new { AuthorID = p.authorID, ad = c.original_book });


    //var result_join = from a in context.Author
    //                  join hbw in context.has_been_written on a.has_been_written_ equals hbw.author
    //                  select new { AuthorID = a.authorID, HBWID = hbw.book_code };

    // DISTINCT
    var result_distinct = context.Author.Distinct();

    // GROUP BY
    var companies = from person in context.Author
                    group person by person.literature_direction;

    var new_original_books = db.books               // Додавання оригіналів за допомогою Eager loading 
        .Include(u => u.books)
        .ToList();

    var new_author = db.Author.FirstOrDefault();    // Додавання авторів за допомогою Explicit loading
    db.Author.Load();

    var new_reader = db.reader.ToList();            // Додавання читачів за допомогою Lazy loading


    */

    ///Усіх авторів, які написали більше 3ьох книжок, що містять 200 сторінок
    //var result =  from a in context.Author
    //                join hbw in context.has_been_written on a.has_been_written_ equals hbw.author
    //                join b in context.books on hbw.book_code equals b.code
    //                where b.count_of_pages > 200
    //                group a by a.authorID into g
    //                where g.Count() > 3
    //                select g.Key;

    //var result = context.Author
    //    .Join(context.has_been_written, a => a.has_been_written_, hbw => hbw.author, (a, hbw) => new { a, hbw })
    //    .Join(context.books, ahbw => ahbw.hbw.book_code, b => b.code, (ahbw, b) => new { ahbw, b })
    //    .Where(x => x.b.count_of_pages > 200)
    //    .GroupBy(x => x.ahbw.a.authorID)
    //    .Where(x => x.Count() > 3)
    //    .Select(x => x.Key);

    //db.has_been_written.Add(new HasBeenWritten { author_code = 1, book_code = 1 });
    //db.has_been_written.Add(new HasBeenWritten { author_code = 1, book_code = 1 });
    //db.has_been_written.Add(new HasBeenWritten { author_code = 1, book_code = 1 });
    //db.has_been_written.Add(new HasBeenWritten { author_code = 1, book_code = 1 });

    var result = context.Author
        .Where(x => x.has_been_written_
        .Where(y => y.original_book.count_of_pages > 200).Count() > 3)
        .ToList();
    //.Select(x => x.authorID);
    ;
}
