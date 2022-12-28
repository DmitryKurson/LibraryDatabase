using System;
using Microsoft.EntityFrameworkCore
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDatabase
{
    class AsyncToDatabase
    {
        private DbContextOptions options;
        public AsyncToDatabase(DbContextOptions options)
        {
            this.options = options;
        }

        public async Task AsyncAdd()
        {
            using (LibraryContext context = new LibraryContext(options))
            {
                for (int i = 0; i < 10; i++)
                {
                    await context.Author.AddAsync(new Entities.Author { surname_name_lastname = "some_author" + i});
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task AsyncRead()
        {
            using (LibraryContext context = new LibraryContext(options))
            {
                var list = await context.Author.ToListAsync();
                foreach (var item in list)
                {
                    Console.WriteLine(item.surname_name_lastname);
                }               
            }
        }
    }
}
