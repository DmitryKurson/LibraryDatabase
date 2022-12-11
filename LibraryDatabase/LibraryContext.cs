using LibraryDatabase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

public class LibraryContext : DbContext
{
	public LibraryContext()
	{
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=LibraryDatabase.db");

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsetting.json")
            .Build();
        optionsBuilder.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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

        modelBuilder.Entity<BookIssueInHall>()
            .HasOne(r => r.book_issue_)
            .WithOne(r => r.book_issue_in_hall_);

        modelBuilder.Entity<OnlineIssue>()
            .HasMany(e => e.book_issue_)
            .WithOne(e => e.online_book_issue);

        modelBuilder.Entity<Reader>()
            .HasOne(t => t.online_issue_)
            .WithOne(t => t.reader_);

        modelBuilder.Entity<Worker>()
            .HasMany(y => y.book_issue_)
            .WithOne(y => y.worker_);

        modelBuilder.Entity<WorkInHall>()
            .HasMany(u => u.worker_)
            .WithOne(u => u.work_in_hall_);

        modelBuilder.Entity<Readerhall>()
            .HasMany(i => i.book_issue_in_hall_)
            .WithOne(i => i.reader_hall_);

        modelBuilder.Entity<Readerhall>()
            .HasOne(o => o.work_in_hall_)
            .WithMany(o => o.reader_hall_);
    }

}
