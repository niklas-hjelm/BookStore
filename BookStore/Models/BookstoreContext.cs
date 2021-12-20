using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BookStore.Models
{
    public partial class BookstoreContext : DbContext
    {
        public BookstoreContext()
        {
        }

        public BookstoreContext(DbContextOptions<BookstoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<AuthorBook> AuthorBooks { get; set; }
        public virtual DbSet<AuthourView> AuthourViews { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderLine> OrderLines { get; set; }
        public virtual DbSet<OrderView> OrderViews { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Stockbalance> Stockbalances { get; set; }
        public virtual DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\;Database=Bookstore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Finnish_Swedish_CI_AS");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Author");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(70);
            });

            modelBuilder.Entity<AuthorBook>(entity =>
            {
                entity.HasKey(e => new { e.AuthorId, e.BookId })
                    .HasName("PK_AuthorBooks");

                entity.ToTable("Author_books");

                entity.Property(e => e.AuthorId).HasColumnName("Author_Id");

                entity.Property(e => e.BookId)
                    .HasMaxLength(13)
                    .HasColumnName("Book_Id");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.AuthorBooks)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Author_bo__Autho__5CD6CB2B");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.AuthorBooks)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Author_bo__Book___5DCAEF64");
            });

            modelBuilder.Entity<AuthourView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("AuthourView");

                entity.Property(e => e.Age).HasMaxLength(36);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(141);

                entity.Property(e => e.StockBalance)
                    .HasMaxLength(33)
                    .HasColumnName("Stock Balance");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Isbn13)
                    .HasName("PK__Books__E7B44C946A711678");

                entity.Property(e => e.Isbn13).HasMaxLength(13);

                entity.Property(e => e.AuthorId).HasColumnName("Author_ID");

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.Property(e => e.Releasedate).HasColumnType("date");

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Books__Author_ID__3A81B327");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId)
                    .ValueGeneratedNever()
                    .HasColumnName("Customer_id");

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(70);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("Order_id");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_id");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("Order_date");

                entity.Property(e => e.ShippingAdress)
                    .IsRequired()
                    .HasColumnName("Shipping_adress");

                entity.Property(e => e.ShippingCity)
                    .IsRequired()
                    .HasColumnName("Shipping_city");

                entity.Property(e => e.ShippingCountry)
                    .IsRequired()
                    .HasColumnName("Shipping_country");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__Customer__46E78A0C");
            });

            modelBuilder.Entity<OrderLine>(entity =>
            {
                entity.ToTable("Order_Line");

                entity.Property(e => e.OrderLineId)
                    .ValueGeneratedNever()
                    .HasColumnName("Order_line_id");

                entity.Property(e => e.Isbn)
                    .IsRequired()
                    .HasMaxLength(13)
                    .HasColumnName("ISBN");

                entity.Property(e => e.OrderId).HasColumnName("Order_id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order_Lin__Order__49C3F6B7");
            });

            modelBuilder.Entity<OrderView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("OrderView");

                entity.Property(e => e.City).IsRequired();

                entity.Property(e => e.Country).IsRequired();

                entity.Property(e => e.CustomerAdress)
                    .IsRequired()
                    .HasColumnName("Customer Adress");

                entity.Property(e => e.CustomerEmail)
                    .IsRequired()
                    .HasColumnName("Customer Email");

                entity.Property(e => e.CustomerId).HasColumnName("Customer ID");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(141)
                    .HasColumnName("Customer Name");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("Order date");

                entity.Property(e => e.OrderId).HasColumnName("Order Id");

                entity.Property(e => e.PurchasedBooks)
                    .HasMaxLength(33)
                    .HasColumnName("Purchased Books");
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK__Publishe__490D1AE168DC57AF");

                entity.ToTable("Publisher");

                entity.Property(e => e.BookId)
                    .HasMaxLength(13)
                    .HasColumnName("book_id");

                entity.Property(e => e.Publisher1)
                    .HasMaxLength(255)
                    .HasColumnName("Publisher");

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.HasOne(d => d.Book)
                    .WithOne(p => p.Publisher)
                    .HasForeignKey<Publisher>(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Publisher__book___4E88ABD4");
            });

            modelBuilder.Entity<Stockbalance>(entity =>
            {
                entity.HasKey(e => new { e.StoreId, e.Isbn })
                    .HasName("PK__Stockbal__A9D77BF457FC7EB2");

                entity.ToTable("Stockbalance");

                entity.Property(e => e.StoreId).HasColumnName("Store_id");

                entity.Property(e => e.Isbn).HasMaxLength(13);

                entity.HasOne(d => d.IsbnNavigation)
                    .WithMany(p => p.Stockbalances)
                    .HasForeignKey(d => d.Isbn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Stockbalan__Isbn__412EB0B6");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Stockbalances)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Stockbala__Store__4222D4EF");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");

                entity.Property(e => e.StoreId)
                    .ValueGeneratedNever()
                    .HasColumnName("Store_id");

                entity.Property(e => e.City).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PostalCode).HasColumnName("Postal_code");

                entity.Property(e => e.StreetName)
                    .IsRequired()
                    .HasMaxLength(120)
                    .HasColumnName("Street_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
