//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;

//namespace Library.Models;

//public partial class LibraryLyContext : DbContext
//{
//    public LibraryLyContext()
//    {
//    }

//    public LibraryLyContext(DbContextOptions<LibraryLyContext> options)
//        : base(options)
//    {
//    }

//    public virtual DbSet<Authorization> Authorizations { get; set; }

//    public virtual DbSet<Book> Books { get; set; }

//    public virtual DbSet<Chapter> Chapters { get; set; }

//    public virtual DbSet<Ticket> Tickets { get; set; }

//    public virtual DbSet<User> Users { get; set; }

//    public virtual DbSet<Writer> Writers { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=PK452-7\\SQLEXPRESS;DataBase=LIbraryLY;Trusted_Connection=true;TrustServerCertificate=true");

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<Authorization>(entity =>
//        {
//            entity.HasKey(e => e.Login);

//            entity.ToTable("authorization");

//            entity.Property(e => e.Login)
//                .HasMaxLength(50)
//                .HasColumnName("login");
//            entity.Property(e => e.Password)
//                .HasMaxLength(50)
//                .HasColumnName("password");
//        });

//        modelBuilder.Entity<Book>(entity =>
//        {
//            entity.HasKey(e => e.IdBook);

//            entity.ToTable("book");

//            entity.Property(e => e.IdBook).HasColumnName("Id_Book");
//            entity.Property(e => e.DataPost)
//                .HasColumnName("Data_Post");
//            entity.Property(e => e.IdChapter).HasColumnName("Id_chapter");
//            entity.Property(e => e.IdUser).HasColumnName("Id_user");
//            entity.Property(e => e.IdWriter).HasColumnName("Id_Writer");
//            entity.Property(e => e.Name)
//                .HasMaxLength(50)
//                .HasColumnName("name");
//            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

//            entity.HasOne(d => d.IdChapterNavigation).WithMany(p => p.Books)
//                .HasForeignKey(d => d.IdChapter)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_book_chapter");

//            entity.HasOne(d => d.IdWriterNavigation).WithMany(p => p.Books)
//                .HasForeignKey(d => d.IdWriter)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_book_writer");
//        });

//        modelBuilder.Entity<Chapter>(entity =>
//        {
//            entity.ToTable("chapter");

//            entity.Property(e => e.Id).HasColumnName("id");
//            entity.Property(e => e.Name).HasColumnName("name");
//        });

//        modelBuilder.Entity<Ticket>(entity =>
//        {
//            entity.HasKey(e => e.IdTicket);

//            entity.ToTable("ticket");

//            entity.Property(e => e.IdTicket).HasColumnName("Id_ticket");
//            entity.Property(e => e.DataGet)
//                .HasMaxLength(50)
//                .HasColumnName("Data_Get");
//            entity.Property(e => e.DataPost)
//                .HasMaxLength(50)
//                .HasColumnName("Data_post");
//            entity.Property(e => e.IdBook).HasColumnName("Id_Book");
//            entity.Property(e => e.IdUser).HasColumnName("Id_user");
//            entity.Property(e => e.TicketNum).HasColumnName("ticket_num");

//            entity.HasOne(d => d.IdBookNavigation).WithMany(p => p.Tickets)
//                .HasForeignKey(d => d.IdBook)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_ticket_book");

//            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Tickets)
//                .HasForeignKey(d => d.IdUser)
//                .HasConstraintName("FK_ticket_user");
//        });

//        modelBuilder.Entity<User>(entity =>
//        {
//            entity.HasKey(e => e.IdUser);

//            entity.ToTable("user");

//            entity.Property(e => e.IdUser).HasColumnName("Id_user");
//            entity.Property(e => e.Adres)
//                .HasMaxLength(50)
//                .HasColumnName("adres");
//            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
//            entity.Property(e => e.Fio)
//                .HasMaxLength(50)
//                .HasColumnName("fio");
//            entity.Property(e => e.Login)
//                .HasMaxLength(50)
//                .HasColumnName("login");
//            entity.Property(e => e.Password)
//                .HasMaxLength(50)
//                .HasColumnName("password");
//            entity.Property(e => e.Phone)
//                .HasMaxLength(12)
//                .HasColumnName("phone");
//            entity.Property(e => e.Role).HasColumnName("role");
//            entity.Property(e => e.Roly)
//                .HasMaxLength(50)
//                .HasColumnName("roly");

//            entity.HasOne(d => d.LoginNavigation).WithMany(p => p.Users)
//                .HasForeignKey(d => d.Login)
//                .HasConstraintName("FK_user_authorization");
//        });

//        modelBuilder.Entity<Writer>(entity =>
//        {
//            entity.ToTable("writer");

//            entity.Property(e => e.Id).HasColumnName("id");
//            entity.Property(e => e.Name).HasColumnName("name");
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//}
