using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Xml.Linq;
using tehnohem_api.Model;
using tehnohem_api.Model.Enums;
using tehnohem_api.Model.HelperClass;
using tehnohem_api.Model.Invoice;

namespace tehnohem_api.DB
{
    public class PostgresqlContext : DbContext
    {
        public PostgresqlContext(DbContextOptions<PostgresqlContext> options) : base(options) { }

        public DbSet<Company> companies { get; set; }
        public DbSet<Invoice> invoices { get; set; }
        public DbSet<Payment> payments{ get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Raw> raws { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();

            //==========COMPANY==================
            modelBuilder.Entity<Company>()
                .HasMany(c => c.DeliveryPlaces)
                .WithOne(c => c.HeadCompany)
                .HasForeignKey(c => c.HeadCompanyID)
                .IsRequired(false);

            modelBuilder.Entity<Company>().Property(c => c.ID).ValueGeneratedOnAdd();

            //==========RAW======================
            modelBuilder.Entity<Raw>().Property(c => c.ID).ValueGeneratedOnAdd();

            //==========PRODUCT==================
            modelBuilder.Entity<Product>().HasKey(c => c.ID);
            modelBuilder.Entity<Product>().Property(c => c.ID).ValueGeneratedOnAdd();

            //==========INVOICE==================
            modelBuilder.Entity<Invoice>().Property(i => i.ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<Invoice>()
                .HasOne<Company>(i => i.Supplier)
                .WithMany(c => c.Invoices_Supplier)
                .HasForeignKey(i => i.SupplierID)
                .IsRequired(false);

            modelBuilder.Entity<Invoice>()
                .HasOne<Company>(i => i.Customer)
                .WithMany(c => c.Invoices_Customer)
                .HasForeignKey(i => i.CustomerID)
                .IsRequired(false);

            modelBuilder.Entity<Invoice>()
                .HasMany(i => i.InvoiceItems)
                .WithOne(ii => ii.Invoice)
                .HasForeignKey(ii => ii.InvoiceID)
                .IsRequired(true);

            //==========INVOICE ITEM==================
            modelBuilder.Entity<InvoiceItem>().Property(ii => ii.ID).ValueGeneratedOnAdd();

            //modelBuilder.Entity<Invoice>()
            //    .HasOne(i => i.DatePeriod)
            //    .WithOne(dp => dp.Invoice)
            //    .IsRequired(false);

            //==========PAYMENT =======================
            modelBuilder.Entity<Payment>()
                .HasOne<Company>(i => i.Payer)
                .WithMany(c => c.Payments_Payer)
                .HasForeignKey(i => i.PayerID)
                .IsRequired(false);

            modelBuilder.Entity<Payment>()
                .HasOne<Company>(i => i.Receiver)
                .WithMany(c => c.Payments_Receiver)
                .HasForeignKey(i => i.ReceiverID)
                .IsRequired(false);

            modelBuilder.Entity<Payment>()
                .HasMany(i => i.PaymentItems)
                .WithOne(ii => ii.Payment)
                .HasForeignKey(ii => ii.PaymentID)
                .IsRequired(true);

            //==========PAYMENT ITEM==================
            modelBuilder.Entity<PaymentItem>().Property(ii => ii.ID).ValueGeneratedOnAdd();


            modelBuilder.Entity<DatePeriod>().HasNoKey();
           

            modelBuilder.Entity<Company>()
                .HasData(new Company()
                {
                    ID = "1",
                    Name = "Zvornicanka d.o.o",
                    Address = "Svetog Save 18, Zvornik",
                    JIB = "123456789",
                    IB = "123456",
                    companyType = CompanyType.CUSTOMER,

                },
                new Company()
                {

                    ID = "2",
                    Name = "M&V d.o.o",
                    Address = "Kralja PEtra 11, Orahovac",
                    JIB = "123456789",
                    IB = "123456",
                    companyType = CompanyType.CUSTOMER,


                },
                new Company()
                {

                    ID = "3",
                    Name = "Tisal d.o.o",
                    Address = "Nebeska, Busovaca",
                    JIB = "123456789",
                    IB = "123456",
                    companyType = CompanyType.SUPPLIER,


                },
                new Company()
                {

                    ID = "4",
                    Name = "Tuzla Plast d.o.o",
                    Address = "Zakasta 10, Tuzla",
                    JIB = "123456789",
                    IB = "123456",
                    companyType = CompanyType.SUPPLIER,


                },
                new Company()
                {

                    ID = "5",
                    Name = "Eco d.o.o",
                    Address = "Mire Mitica 20, Ugljevik",
                    JIB = "123456789",
                    IB = "123456",
                    companyType = CompanyType.CUSTOMER,


                },
                new Company()
                {

                    ID = "6",
                    Name = "Miroslav Dronjak",
                    Address = "Grobnice, Zvornik",
                    JIB = "123456789",
                    IB = "123456",
                    companyType = CompanyType.THIRD_PARTY,


                },
                new Company()
                {

                    ID = "7",
                    Name = "Elektrodistribucija",
                    Address = "Limenacka 32, Sarajevo",
                    JIB = "123456789",
                    IB = "123456",
                    companyType = CompanyType.THIRD_PARTY,


                });

            modelBuilder.Entity<Raw>().HasData(
                new Raw { 
                    ID = 1,
                    Name = "Sircetna kiselina",
                    CurrentAmount = 25,
                    RawType= RawType.RAW,
                    SinglePrice= 0.95f,
                    TotalValue= 23.75f
                },
                new Raw
                {
                    ID = 2,
                    Name = "Luzina",
                    CurrentAmount = 22,
                    RawType = RawType.RAW,
                    SinglePrice = 0.95f,
                    TotalValue = 21.75f
                },
                new Raw
                {
                    ID = 3,
                    Name = "Sirce 1/1",
                    CurrentAmount = 1000,
                    RawType = RawType.BOTTLE,
                    SinglePrice = 0.12f,
                    TotalValue = 120f
                },
                new Raw
                {
                    ID = 4,
                    Name = "Deter 5/1",
                    CurrentAmount = 500,
                    RawType = RawType.BOTTLE,
                    SinglePrice = 0.5f,
                    TotalValue = 250f
                },
                new Raw
                {
                    ID = 5,
                    Name = "Sirce 3/1",
                    CurrentAmount = 700,
                    RawType = RawType.RAW,
                    SinglePrice = 0.4f,
                    TotalValue = 300.65f
                },
                new Raw
                {
                    ID = 6,
                    Name = "Zuti f40",
                    CurrentAmount = 3000,
                    RawType = RawType.CAP,
                    SinglePrice = 0.1f,
                    TotalValue = 300f
                },
                new Raw
                {
                    ID = 7,
                    Name = "Plavi f40",
                    CurrentAmount = 2500,
                    RawType = RawType.CAP,
                    SinglePrice = 0.12f,
                    TotalValue = 260f
                },
                new Raw
                {
                    ID = 8,
                    Name = "Zeleni pipak",
                    CurrentAmount = 25,
                    RawType = RawType.CAP,
                    SinglePrice = 0.95f,
                    TotalValue = 23.75f
                },
                new Raw
                {
                    ID = 9,
                    Name = "Plava pumpica",
                    CurrentAmount = 7800,
                    RawType = RawType.RAW,
                    SinglePrice = 0.4f,
                    TotalValue = 3500f
                },
                new Raw
                {
                    ID = 10,
                    Name = "Sircetna kiselina 1/1",
                    CurrentAmount = 2500,
                    RawType = RawType.LABEL,
                    SinglePrice = 0.05f,
                    TotalValue = 200f
                },
                new Raw
                {
                    ID = 11,
                    Name = "Sircetna kiselina 3/1",
                    CurrentAmount = 2500,
                    RawType = RawType.LABEL,
                    SinglePrice = 0.05f,
                    TotalValue = 200f
                },
                new Raw
                {
                    ID = 12,
                    Name = "Tasko Maxi 0.25/1",
                    CurrentAmount = 2500,
                    RawType = RawType.LABEL,
                    SinglePrice = 0.05f,
                    TotalValue = 200f
                },
                new Raw
                {
                    ID = 13,
                    Name = "Sona kiselina1/1",
                    CurrentAmount = 2500,
                    RawType = RawType.LABEL,
                    SinglePrice = 0.05f,
                    TotalValue = 200f
                }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product { 
                    ID=1,
                    BarCode = "13246587",
                    Name = "Sirce",
                    Volume = "1/1",
                    CurrentAmount = 130,
                    SinglePrice = 0.93f,
                    TotalValue = 930.76f
                },
                new Product
                {
                    ID = 2,
                    BarCode = "1112223333",
                    Name = "Sirce",
                    Volume = "3/1",
                    CurrentAmount = 70,
                    SinglePrice = 2.93f,
                    TotalValue = 1830.76f
                },
                new Product
                {
                    ID = 3,
                    BarCode = "3333555999",
                    Name = "Rival Glass",
                    Volume = "0.75/1",
                    CurrentAmount = 570,
                    SinglePrice = 1.43f,
                    TotalValue = 1500.76f
                },
                new Product
                {
                    ID = 4,
                    BarCode = "98789321",
                    Name = "Tasko Maxi",
                    Volume = "5/1",
                    CurrentAmount = 986,
                    SinglePrice = 5.13f,
                    TotalValue = 2530.76f
                }

                );
        }


    }
}
