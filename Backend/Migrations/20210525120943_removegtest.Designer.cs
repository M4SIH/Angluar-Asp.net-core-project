﻿// <auto-generated />
using Backend.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Backend.Migrations
{
    [DbContext(typeof(CliDB))]
    [Migration("20210525120943_removegtest")]
    partial class removegtest
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Backend.Database.Account", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("Username");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Backend.Database.Manager", b =>
                {
                    b.Property<string>("AccountUsername")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountUsername");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("Backend.Database.User", b =>
                {
                    b.Property<string>("AccountUsername")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountUsername");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Backend.Database.Writer", b =>
                {
                    b.Property<string>("AccountUsername")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Level")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountUsername");

                    b.ToTable("Writers");
                });

            modelBuilder.Entity("Backend.Database.Manager", b =>
                {
                    b.HasOne("Backend.Database.Account", "Account")
                        .WithOne("Manager")
                        .HasForeignKey("Backend.Database.Manager", "AccountUsername")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Backend.Database.User", b =>
                {
                    b.HasOne("Backend.Database.Account", "Account")
                        .WithOne("User")
                        .HasForeignKey("Backend.Database.User", "AccountUsername")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Backend.Database.Writer", b =>
                {
                    b.HasOne("Backend.Database.Account", "Account")
                        .WithOne("Writer")
                        .HasForeignKey("Backend.Database.Writer", "AccountUsername")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Backend.Database.Account", b =>
                {
                    b.Navigation("Manager");

                    b.Navigation("User");

                    b.Navigation("Writer");
                });
#pragma warning restore 612, 618
        }
    }
}
