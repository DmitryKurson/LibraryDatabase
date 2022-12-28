﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryDatabase.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20221226190531_LNQCreate56")]
    partial class LNQCreate56
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true);

            modelBuilder.Entity("LibraryDatabase.Entities.Author", b =>
                {
                    b.Property<int>("authorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("literature_direction")
                        .HasColumnType("TEXT");

                    b.Property<string>("nationality")
                        .HasColumnType("TEXT");

                    b.Property<string>("surname_name_lastname")
                        .HasColumnType("TEXT");

                    b.HasKey("authorID");

                    b.ToTable("Author");

                    b.HasData(
                        new
                        {
                            authorID = 1,
                            literaturedirection = "romantism",
                            nationality = "ukrainian",
                            surnamenamelastname = "Taras Hrygorovich Shevchenko"
                        });
                });

            modelBuilder.Entity("LibraryDatabase.Entities.Book", b =>
                {
                    b.Property<int>("book_ID_in_database")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("code")
                        .HasColumnType("INTEGER");

                    b.Property<int>("count_of_copyes")
                        .HasColumnType("INTEGER");

                    b.Property<int>("count_of_pages")
                        .HasColumnType("INTEGER");

                    b.Property<int>("literary_direction")
                        .HasColumnType("INTEGER");

                    b.Property<int>("name")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("original_book_name")
                        .HasColumnType("INTEGER");

                    b.Property<int>("publishing_house")
                        .HasColumnType("INTEGER");

                    b.Property<string>("publishing_house_name")
                        .HasColumnType("TEXT");

                    b.Property<int>("year_of_writing")
                        .HasColumnType("INTEGER");

                    b.HasKey("book_ID_in_database");

                    b.HasIndex("original_book_name");

                    b.HasIndex("publishing_house_name");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("LibraryDatabase.Entities.BookCopy", b =>
                {
                    b.Property<int>("inventory_code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("book_ID_in_database")
                        .HasColumnType("INTEGER");

                    b.Property<int>("database_book_code")
                        .HasColumnType("INTEGER");

                    b.HasKey("inventory_code");

                    b.HasIndex("book_ID_in_database");

                    b.ToTable("BookCopy");
                });

            modelBuilder.Entity("LibraryDatabase.Entities.BookIssue", b =>
                {
                    b.Property<int>("issue_code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("book_copy_inventory_code")
                        .HasColumnType("INTEGER");

                    b.Property<int>("count_of_pledge")
                        .HasColumnType("INTEGER");

                    b.Property<int>("date_of_issue")
                        .HasColumnType("INTEGER");

                    b.Property<int>("date_of_returning_book")
                        .HasColumnType("INTEGER");

                    b.Property<int>("days_to_issue_expire")
                        .HasColumnType("INTEGER");

                    b.Property<int>("inventory_code")
                        .HasColumnType("INTEGER");

                    b.Property<int>("online_book_issueissue_code")
                        .HasColumnType("INTEGER");

                    b.Property<int>("worker")
                        .HasColumnType("INTEGER");

                    b.Property<int>("worker_passport_code_and_series")
                        .HasColumnType("INTEGER");

                    b.HasKey("issue_code");

                    b.HasIndex("book_copy_inventory_code");

                    b.HasIndex("online_book_issueissue_code");

                    b.HasIndex("worker_passport_code_and_series");

                    b.ToTable("BookIssue");
                });

            modelBuilder.Entity("LibraryDatabase.Entities.BookIssueInHall", b =>
                {
                    b.Property<int>("hall_code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("book_issue_issue_code")
                        .HasColumnType("INTEGER");

                    b.Property<int>("issue_code")
                        .HasColumnType("INTEGER");

                    b.Property<int>("reader_hall_hall_code")
                        .HasColumnType("INTEGER");

                    b.HasKey("hall_code");

                    b.HasIndex("book_issue_issue_code");

                    b.HasIndex("reader_hall_hall_code");

                    b.ToTable("BookIssueInHall");
                });

            modelBuilder.Entity("LibraryDatabase.Entities.HasBeenWritten", b =>
                {
                    b.Property<int>("author_code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("authorID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("book_code")
                        .HasColumnType("INTEGER");

                    b.Property<int>("original_bookname")
                        .HasColumnType("INTEGER");

                    b.HasKey("author_code");

                    b.HasIndex("authorID");

                    b.HasIndex("original_bookname");

                    b.ToTable("HasBeenWritten");
                });

            modelBuilder.Entity("LibraryDatabase.Entities.OnlineIssue", b =>
                {
                    b.Property<int>("issue_code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("readers_ticket_code")
                        .HasColumnType("INTEGER");

                    b.HasKey("issue_code");

                    b.HasIndex("readers_ticket_code")
                        .IsUnique();

                    b.ToTable("OnlineIssue");
                });

            modelBuilder.Entity("LibraryDatabase.Entities.OriginalBook", b =>
                {
                    b.Property<int>("name")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("code")
                        .HasColumnType("INTEGER");

                    b.Property<int>("count_of_pages")
                        .HasColumnType("INTEGER");

                    b.Property<int>("literature_direction")
                        .HasColumnType("INTEGER");

                    b.Property<int>("year_of_writing")
                        .HasColumnType("INTEGER");

                    b.HasKey("name");

                    b.ToTable("books");
                });

            modelBuilder.Entity("LibraryDatabase.Entities.PublishingHouse", b =>
                {
                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.Property<int>("count_of_printing_per_year")
                        .HasColumnType("INTEGER");

                    b.Property<int>("literature_direction")
                        .HasColumnType("INTEGER");

                    b.HasKey("name");

                    b.ToTable("PublishingHouse");
                });

            modelBuilder.Entity("LibraryDatabase.Entities.Reader", b =>
                {
                    b.Property<int>("reader_ticket_code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("data_of_birth")
                        .HasColumnType("INTEGER");

                    b.Property<int>("phone")
                        .HasColumnType("INTEGER");

                    b.Property<int>("place_of_living")
                        .HasColumnType("INTEGER");

                    b.Property<string>("surname_name_lastname")
                        .HasColumnType("TEXT");

                    b.HasKey("reader_ticket_code");

                    b.ToTable("reader1");
                });

            modelBuilder.Entity("LibraryDatabase.Entities.Readerhall", b =>
                {
                    b.Property<int>("hall_code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("count_of_shelves")
                        .HasColumnType("INTEGER");

                    b.Property<int>("count_of_tables")
                        .HasColumnType("INTEGER");

                    b.Property<int>("work_in_hall_passport_code_and_series")
                        .HasColumnType("INTEGER");

                    b.HasKey("hall_code");

                    b.HasIndex("work_in_hall_passport_code_and_series");

                    b.ToTable("Readerhall");
                });

            modelBuilder.Entity("LibraryDatabase.Entities.WorkInHall", b =>
                {
                    b.Property<int>("passport_code_and_series")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("date_of_work")
                        .HasColumnType("INTEGER");

                    b.Property<int>("hall_code")
                        .HasColumnType("INTEGER");

                    b.HasKey("passport_code_and_series");

                    b.ToTable("WorkInHall");
                });

            modelBuilder.Entity("LibraryDatabase.Entities.Worker", b =>
                {
                    b.Property<int>("passport_code_and_series")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("data_of_birth")
                        .HasColumnType("INTEGER");

                    b.Property<string>("surname_name_lastname")
                        .HasColumnType("TEXT");

                    b.Property<int>("work_in_hall_passport_code_and_series")
                        .HasColumnType("INTEGER");

                    b.HasKey("passport_code_and_series");

                    b.HasIndex("work_in_hall_passport_code_and_series");

                    b.ToTable("Worker");
                });

            modelBuilder.Entity("LibraryDatabase.Entities.Book", b =>
                {
                    b.HasOne("LibraryDatabase.Entities.OriginalBook", "original_book_")
                        .WithMany("books")
                        .HasForeignKey("original_book_name");

                    b.HasOne("LibraryDatabase.Entities.PublishingHouse", "publishing_house_")
                        .WithMany("book_")
                        .HasForeignKey("publishing_house_name");

                    b.Navigation("original_book_");

                    b.Navigation("publishing_house_");
                });

            modelBuilder.Entity("LibraryDatabase.Entities.BookCopy", b =>
                {
                    b.HasOne("LibraryDatabase.Entities.Book", "book_")
                        .WithMany("book_copyes_")
                        .HasForeignKey("book_ID_in_database")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("book_");
                });

            modelBuilder.Entity("LibraryDatabase.Entities.BookIssue", b =>
                {
                    b.HasOne("LibraryDatabase.Entities.BookCopy", "book_copy_")
                        .WithMany("book_issue_")
                        .HasForeignKey("book_copy_inventory_code")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryDatabase.Entities.OnlineIssue", "online_book_issue")
                        .WithMany("book_issue_")
                        .HasForeignKey("online_book_issueissue_code")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryDatabase.Entities.Worker", "worker_")
                        .WithMany("book_issue_")
                        .HasForeignKey("worker_passport_code_and_series")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("book_copy_");

                    b.Navigation("online_book_issue");

                    b.Navigation("worker_");
                });

            modelBuilder.Entity("LibraryDatabase.Entities.BookIssueInHall", b =>
                {
                    b.HasOne("LibraryDatabase.Entities.BookIssue", "book_issue_")
                        .WithMany("book_issue_in_hall_")
                        .HasForeignKey("book_issue_issue_code")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryDatabase.Entities.Readerhall", "reader_hall_")
                        .WithMany("book_issue_in_hall_")
                        .HasForeignKey("reader_hall_hall_code")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("book_issue_");

                    b.Navigation("reader_hall_");
                });

            modelBuilder.Entity("LibraryDatabase.Entities.HasBeenWritten", b =>
                {
                    b.HasOne("LibraryDatabase.Entities.Author", "author")
                        .WithMany("has_been_written_")
                        .HasForeignKey("authorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryDatabase.Entities.OriginalBook", "original_book")
                        .WithMany("HasBeenWritten")
                        .HasForeignKey("original_bookname")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("author");

                    b.Navigation("original_book");
                });

            modelBuilder.Entity("LibraryDatabase.Entities.OnlineIssue", b =>
                {
                    b.HasOne("LibraryDatabase.Entities.Reader", "reader_")
                        .WithOne("online_issue_")
                        .HasForeignKey("LibraryDatabase.Entities.OnlineIssue", "readers_ticket_code")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("reader_");
                });

            modelBuilder.Entity("LibraryDatabase.Entities.Readerhall", b =>
                {
                    b.HasOne("LibraryDatabase.Entities.WorkInHall", "work_in_hall_")
                        .WithMany("reader_hall_")
                        .HasForeignKey("work_in_hall_passport_code_and_series")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("work_in_hall_");
                });

            modelBuilder.Entity("LibraryDatabase.Entities.Worker", b =>
                {
                    b.HasOne("LibraryDatabase.Entities.WorkInHall", "work_in_hall_")
                        .WithMany("worker_")
                        .HasForeignKey("work_in_hall_passport_code_and_series")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("work_in_hall_");
                });

            modelBuilder.Entity("LibraryDatabase.Entities.Author", b =>
                {
                    b.Navigation("has_been_written_");
                });

            modelBuilder.Entity("LibraryDatabase.Entities.Book", b =>
                {
                    b.Navigation("book_copyes_");
                });

            modelBuilder.Entity("LibraryDatabase.Entities.BookCopy", b =>
                {
                    b.Navigation("book_issue_");
                });

            modelBuilder.Entity("LibraryDatabase.Entities.BookIssue", b =>
                {
                    b.Navigation("book_issue_in_hall_");
                });

            modelBuilder.Entity("LibraryDatabase.Entities.OnlineIssue", b =>
                {
                    b.Navigation("book_issue_");
                });

            modelBuilder.Entity("LibraryDatabase.Entities.OriginalBook", b =>
                {
                    b.Navigation("HasBeenWritten");

                    b.Navigation("books");
                });

            modelBuilder.Entity("LibraryDatabase.Entities.PublishingHouse", b =>
                {
                    b.Navigation("book_");
                });

            modelBuilder.Entity("LibraryDatabase.Entities.Reader", b =>
                {
                    b.Navigation("online_issue_")
                        .IsRequired();
                });

            modelBuilder.Entity("LibraryDatabase.Entities.Readerhall", b =>
                {
                    b.Navigation("book_issue_in_hall_");
                });

            modelBuilder.Entity("LibraryDatabase.Entities.WorkInHall", b =>
                {
                    b.Navigation("reader_hall_");

                    b.Navigation("worker_");
                });

            modelBuilder.Entity("LibraryDatabase.Entities.Worker", b =>
                {
                    b.Navigation("book_issue_");
                });
#pragma warning restore 612, 618
        }
    }
}
