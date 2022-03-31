﻿// <auto-generated />
using System;
using EasyFinance.Db.SqlServer.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EasyFinance.Db.SqlServer.EF.Migrations
{
    [DbContext(typeof(EasyFinanceDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EasyFinance.Domain.Accounts.BankAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BankAccounts");
                });

            modelBuilder.Entity("EasyFinance.Domain.Accounts.BankAccountTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<Guid?>("BankAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2(7)");

                    b.HasKey("Id");

                    b.HasIndex("BankAccountId");

                    b.ToTable("BankAccountTransactions");
                });

            modelBuilder.Entity("EasyFinance.Domain.Accounts.CreditCard", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CreditCards");
                });

            modelBuilder.Entity("EasyFinance.Domain.Accounts.CreditCardSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreditCardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("DefaultPaymentAmount")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("Limit")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("Threshold")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("Id");

                    b.HasIndex("CreditCardId")
                        .IsUnique();

                    b.ToTable("CreditCardSettings");
                });

            modelBuilder.Entity("EasyFinance.Domain.Accounts.CreditCardTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreditCardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TransactionAmount")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CreditCardId");

                    b.ToTable("CreditCardTransactions");
                });

            modelBuilder.Entity("EasyFinance.Domain.Accounts.BankAccountTransaction", b =>
                {
                    b.HasOne("EasyFinance.Domain.Accounts.BankAccount", null)
                        .WithMany("Transactions")
                        .HasForeignKey("BankAccountId");
                });

            modelBuilder.Entity("EasyFinance.Domain.Accounts.CreditCardSettings", b =>
                {
                    b.HasOne("EasyFinance.Domain.Accounts.CreditCard", null)
                        .WithOne("Settings")
                        .HasForeignKey("EasyFinance.Domain.Accounts.CreditCardSettings", "CreditCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EasyFinance.Domain.Accounts.CreditCardTransaction", b =>
                {
                    b.HasOne("EasyFinance.Domain.Accounts.CreditCard", null)
                        .WithMany("Transactions")
                        .HasForeignKey("CreditCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EasyFinance.Domain.Accounts.BankAccount", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("EasyFinance.Domain.Accounts.CreditCard", b =>
                {
                    b.Navigation("Settings")
                        .IsRequired();

                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
