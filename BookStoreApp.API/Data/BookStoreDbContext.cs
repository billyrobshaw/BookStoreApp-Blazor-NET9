using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.API.Data;

public partial class BookStoreDbContext : IdentityDbContext<ApiUser>
{
    public BookStoreDbContext()
    {
    }

    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; } = null!;

    public virtual DbSet<Book> Books { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Author>(entity =>
        {
            entity.Property(e => e.Bio).HasMaxLength(250);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<Book>(entity =>
        {

            entity.HasIndex(e => e.Isbn, "UQ__Books__447D36EADBBBABB3").IsUnique();

            entity.Property(e => e.Image).HasMaxLength(50);
            entity.Property(e => e.Isbn)
                .HasMaxLength(50)
                .HasColumnName("ISBN");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Summary).HasMaxLength(250);
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.Authorid)
                .HasConstraintName("FK_Books_ToTable");
        });

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                //User role
                Name = "User",
                NormalizedName = "USER",
                Id = "a793dd77-e0e2-4e9b-925b-4e3aa605c5dc",
                ConcurrencyStamp = "f528ce09-e248-4fa0-b262-01ddbc65179d"
            },
            new IdentityRole
            {
                //Admin role
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                Id = "c191496a-d737-4d87-ae5d-51b520aae1c9",
                ConcurrencyStamp = "8c837381-b6fd-4ee6-86af-a038137bb6de"
            }
        );

        var hasher = new PasswordHasher<ApiUser>();

        var admin = modelBuilder.Entity<ApiUser>().HasData(
            new ApiUser
            {
                //Admin User
                Id = "9c964337-0cf3-4e74-87ca-0e815e8d8d5e",
                Email = "admin@bookstore.com",
                NormalizedEmail = "ADMIN@BOOKSTORE.COM",
                UserName = "admin@bookstore.com",
                NormalizedUserName = "ADMIN@BOOKSTORE.COM",
                FirstName = "System",
                LastName = "Admin",
                PasswordHash = hasher.HashPassword(null, "P@ssw0rd1")
            },
            new ApiUser
            {
                //Normal User
                Id = "40738840-7318-48f4-ad53-10c8d10351b5",
                Email = "user@bookstore.com",
                NormalizedEmail = "USER@BOOKSTORE.COM",
                UserName = "user@bookstore.com",
                NormalizedUserName = "USER@BOOKSTORE.COM",
                FirstName = "System",
                LastName = "User",
                PasswordHash = hasher.HashPassword(null, "P@ssw0rd1")
            }
            
        );
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                //User
                RoleId = "a793dd77-e0e2-4e9b-925b-4e3aa605c5dc",
                UserId = "40738840-7318-48f4-ad53-10c8d10351b5"
            },
            new IdentityUserRole<string>
            {
                //Admin
                RoleId = "c191496a-d737-4d87-ae5d-51b520aae1c9",
                UserId = "9c964337-0cf3-4e74-87ca-0e815e8d8d5e",
            }
        );



        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
