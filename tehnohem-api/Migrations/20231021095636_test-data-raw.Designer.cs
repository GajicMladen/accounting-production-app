﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using tehnohem_api.DB;

#nullable disable

namespace tehnohem_api.Migrations
{
    [DbContext(typeof(PostgresqlContext))]
    [Migration("20231021095636_test-data-raw")]
    partial class testdataraw
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseSerialColumns(modelBuilder);

            modelBuilder.Entity("tehnohem_api.Model.Company", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ContactPerson")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("HeadCompanyID")
                        .HasColumnType("text");

                    b.Property<string>("IB")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("JIB")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<int>("companyType")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("HeadCompanyID");

                    b.ToTable("Company");

                    b.HasData(
                        new
                        {
                            ID = "1",
                            Address = "Svetog Save 18, Zvornik",
                            IB = "123456",
                            JIB = "123456789",
                            Name = "Zvornicanka d.o.o",
                            companyType = 1
                        },
                        new
                        {
                            ID = "2",
                            Address = "Kralja PEtra 11, Orahovac",
                            IB = "123456",
                            JIB = "123456789",
                            Name = "M&V d.o.o",
                            companyType = 1
                        },
                        new
                        {
                            ID = "3",
                            Address = "Nebeska, Busovaca",
                            IB = "123456",
                            JIB = "123456789",
                            Name = "Tisal d.o.o",
                            companyType = 0
                        },
                        new
                        {
                            ID = "4",
                            Address = "Zakasta 10, Tuzla",
                            IB = "123456",
                            JIB = "123456789",
                            Name = "Tuzla Plast d.o.o",
                            companyType = 0
                        },
                        new
                        {
                            ID = "5",
                            Address = "Mire Mitica 20, Ugljevik",
                            IB = "123456",
                            JIB = "123456789",
                            Name = "Eco d.o.o",
                            companyType = 1
                        },
                        new
                        {
                            ID = "6",
                            Address = "Grobnice, Zvornik",
                            IB = "123456",
                            JIB = "123456789",
                            Name = "Miroslav Dronjak",
                            companyType = 3
                        },
                        new
                        {
                            ID = "7",
                            Address = "Limenacka 32, Sarajevo",
                            IB = "123456",
                            JIB = "123456789",
                            Name = "Elektrodistribucija",
                            companyType = 3
                        });
                });

            modelBuilder.Entity("tehnohem_api.Model.HelperClass.DatePeriod", b =>
                {
                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<string>("InvoiceID")
                        .HasColumnType("text");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.HasIndex("InvoiceID");

                    b.ToTable("DatePeriod");
                });

            modelBuilder.Entity("tehnohem_api.Model.Invoice", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text");

                    b.Property<string>("CustomerID")
                        .HasColumnType("text");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int>("InvoiceType")
                        .HasColumnType("integer");

                    b.Property<string>("SupplierID")
                        .HasColumnType("text");

                    b.Property<float>("TotalPrice")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("SupplierID");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("tehnohem_api.Model.InvoiceItem", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text");

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<string>("InvoiceID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("SinglePrice")
                        .HasColumnType("real");

                    b.Property<float>("TotalPrice")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.HasIndex("InvoiceID");

                    b.ToTable("InvoiceItem");
                });

            modelBuilder.Entity("tehnohem_api.Model.Product", b =>
                {
                    b.Property<string>("BarCode")
                        .HasColumnType("text");

                    b.Property<float>("CurrentAmount")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("SinglePrice")
                        .HasColumnType("real");

                    b.Property<float>("TotalPrice")
                        .HasColumnType("real");

                    b.Property<float>("Volume")
                        .HasColumnType("real");

                    b.HasKey("BarCode");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("tehnohem_api.Model.Raw", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("ID"));

                    b.Property<float?>("CurrentAmount")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RawType")
                        .HasColumnType("integer");

                    b.Property<float>("SinglePrice")
                        .HasColumnType("real");

                    b.Property<float?>("TotalPrice")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.ToTable("Raws");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CurrentAmount = 25f,
                            Name = "Sircetna kiselina",
                            RawType = 0,
                            SinglePrice = 0.95f,
                            TotalPrice = 23.75f
                        },
                        new
                        {
                            ID = 2,
                            CurrentAmount = 22f,
                            Name = "Luzina",
                            RawType = 0,
                            SinglePrice = 0.95f,
                            TotalPrice = 21.75f
                        },
                        new
                        {
                            ID = 3,
                            CurrentAmount = 1000f,
                            Name = "Sirce 1/1",
                            RawType = 1,
                            SinglePrice = 0.12f,
                            TotalPrice = 120f
                        },
                        new
                        {
                            ID = 4,
                            CurrentAmount = 500f,
                            Name = "Deter 5/1",
                            RawType = 1,
                            SinglePrice = 0.5f,
                            TotalPrice = 250f
                        },
                        new
                        {
                            ID = 5,
                            CurrentAmount = 700f,
                            Name = "Sirce 3/1",
                            RawType = 0,
                            SinglePrice = 0.4f,
                            TotalPrice = 300.65f
                        },
                        new
                        {
                            ID = 6,
                            CurrentAmount = 3000f,
                            Name = "Zuti f40",
                            RawType = 2,
                            SinglePrice = 0.1f,
                            TotalPrice = 300f
                        },
                        new
                        {
                            ID = 7,
                            CurrentAmount = 2500f,
                            Name = "Plavi f40",
                            RawType = 2,
                            SinglePrice = 0.12f,
                            TotalPrice = 260f
                        },
                        new
                        {
                            ID = 8,
                            CurrentAmount = 25f,
                            Name = "Zeleni pipak",
                            RawType = 2,
                            SinglePrice = 0.95f,
                            TotalPrice = 23.75f
                        },
                        new
                        {
                            ID = 9,
                            CurrentAmount = 7800f,
                            Name = "Plava pumpica",
                            RawType = 0,
                            SinglePrice = 0.4f,
                            TotalPrice = 3500f
                        },
                        new
                        {
                            ID = 10,
                            CurrentAmount = 2500f,
                            Name = "Sircetna kiselina 1/1",
                            RawType = 3,
                            SinglePrice = 0.05f,
                            TotalPrice = 200f
                        },
                        new
                        {
                            ID = 11,
                            CurrentAmount = 2500f,
                            Name = "Sircetna kiselina 3/1",
                            RawType = 3,
                            SinglePrice = 0.05f,
                            TotalPrice = 200f
                        },
                        new
                        {
                            ID = 12,
                            CurrentAmount = 2500f,
                            Name = "Tasko Maxi 0.25/1",
                            RawType = 3,
                            SinglePrice = 0.05f,
                            TotalPrice = 200f
                        },
                        new
                        {
                            ID = 13,
                            CurrentAmount = 2500f,
                            Name = "Sona kiselina1/1",
                            RawType = 3,
                            SinglePrice = 0.05f,
                            TotalPrice = 200f
                        });
                });

            modelBuilder.Entity("tehnohem_api.Model.Company", b =>
                {
                    b.HasOne("tehnohem_api.Model.Company", "HeadCompany")
                        .WithMany("DeliveryPlaces")
                        .HasForeignKey("HeadCompanyID");

                    b.Navigation("HeadCompany");
                });

            modelBuilder.Entity("tehnohem_api.Model.HelperClass.DatePeriod", b =>
                {
                    b.HasOne("tehnohem_api.Model.Invoice", "Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceID");

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("tehnohem_api.Model.Invoice", b =>
                {
                    b.HasOne("tehnohem_api.Model.Company", "Customer")
                        .WithMany("Invoices_Customer")
                        .HasForeignKey("CustomerID");

                    b.HasOne("tehnohem_api.Model.Company", "Supplier")
                        .WithMany("Invoices_Supplier")
                        .HasForeignKey("SupplierID");

                    b.Navigation("Customer");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("tehnohem_api.Model.InvoiceItem", b =>
                {
                    b.HasOne("tehnohem_api.Model.Invoice", "Invoice")
                        .WithMany("InvoiceItems")
                        .HasForeignKey("InvoiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("tehnohem_api.Model.Company", b =>
                {
                    b.Navigation("DeliveryPlaces");

                    b.Navigation("Invoices_Customer");

                    b.Navigation("Invoices_Supplier");
                });

            modelBuilder.Entity("tehnohem_api.Model.Invoice", b =>
                {
                    b.Navigation("InvoiceItems");
                });
#pragma warning restore 612, 618
        }
    }
}
