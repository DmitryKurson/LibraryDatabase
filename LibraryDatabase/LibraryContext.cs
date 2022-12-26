using LibraryDatabase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

public class LibraryContext : DbContext
{
    public DbSet<Author> Author => Set<Author>();
    public DbSet<Author> Author2;
    public DbSet<HasBeenWritten> has_been_written;
    public DbSet<OriginalBook> books;
    public DbSet<Reader> reader;
    //public DbSet<Author> Author { get; set; } = null!;
    public LibraryContext()
	{
        //Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlite("Data Source=LibraryDatabase.db");

        //IConfigurationRoot configuration = new ConfigurationBuilder()
        //    .SetBasePath(Directory.GetCurrentDirectory())
        //    .AddJsonFile("appsetting.json")
        //    .Build();
        //optionsBuilder.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>().HasData(new Author
        {
            authorID = 1,
            nationality = "ukrainian",
            literature_direction = "romantism",
            surname_name_lastname = "Taras Hrygorovich Shevchenko",
        });
        //var asd = modelBuilder.Entity<>
        modelBuilder.Entity<Author>()
            .HasMany(b => b.has_been_written_)
            .WithOne(b => b.author);

        modelBuilder.Entity<HasBeenWritten>()
            .HasOne(d => d.original_book)
            .WithMany(d => d.HasBeenWritten);

        modelBuilder.Entity<OriginalBook>()
            .HasMany(a => a.books)
            .WithOne(a => a.original_book_);

        modelBuilder.Entity<PublishingHouse>()
            .HasMany(c => c.book_)
            .WithOne(c => c.publishing_house_);

        modelBuilder.Entity<Book>()
            .HasMany(q => q.book_copyes_)
            .WithOne(q => q.book_);

        modelBuilder.Entity<BookCopy>()
            .HasMany(p => p.book_issue_)
            .WithOne(p => p.book_copy_);

        //modelBuilder.Entity<BookIssueInHall>()
        //    .HasOne(r => r.book_issue_)
        //    .WithOne(r => r.book_issue_in_hall_);

        modelBuilder.Entity<OnlineIssue>()
            .HasMany(e => e.book_issue_)
            .WithOne(e => e.online_book_issue);

        modelBuilder.Entity<Reader>()
            .HasOne(t => t.online_issue_)
            .WithOne(t => t.reader_)
            .HasForeignKey<OnlineIssue>(t => t.readers_ticket_code);

        modelBuilder.Entity<Worker>()
            .HasMany(y => y.book_issue_)
            .WithOne(y => y.worker_);

        modelBuilder.Entity<WorkInHall>()
            .HasMany(u => u.worker_)
            .WithOne(u => u.work_in_hall_);

        modelBuilder.Entity<BookIssue>()
            .HasMany(k => k.book_issue_in_hall_)
            .WithOne(k => k.book_issue_);

        modelBuilder.Entity<Readerhall>()
            .HasMany(i => i.book_issue_in_hall_)
            .WithOne(i => i.reader_hall_);

        modelBuilder.Entity<Readerhall>()
            .HasOne(o => o.work_in_hall_)
            .WithMany(o => o.reader_hall_);
    }

}
