using System;
using System.Collections.Generic;
using BookInfo.API.Entities;
using BookInfo.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookInfo.API.DbContexts;

public partial class PubsContext : DbContext
{
    public PubsContext()
    {
    }

    public PubsContext(DbContextOptions<PubsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<PubInfo> PubInfos { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<Roysched> Royscheds { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<Title> Titles { get; set; }

    public virtual DbSet<Titleauthor> Titleauthors { get; set; }

    public virtual DbSet<Titleview> Titleviews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-H1VFQN9;Database=pubs;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.AuId).HasName("UPKCL_auidind");

            entity.ToTable("authors");

            entity.HasIndex(e => new { e.AuLname, e.AuFname }, "aunmind");

            entity.Property(e => e.AuId)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("au_id");
            entity.Property(e => e.Address)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.AuFname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("au_fname");
            entity.Property(e => e.AuLname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("au_lname");
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Contract).HasColumnName("contract");
            entity.Property(e => e.Phone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasDefaultValue("UNKNOWN")
                .IsFixedLength()
                .HasColumnName("phone");
            entity.Property(e => e.State)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("state");
            entity.Property(e => e.Zip)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("zip");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("discounts");

            entity.Property(e => e.Discount1)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.Discounttype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("discounttype");
            entity.Property(e => e.Highqty).HasColumnName("highqty");
            entity.Property(e => e.Lowqty).HasColumnName("lowqty");
            entity.Property(e => e.StorId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("stor_id");

            entity.HasOne(d => d.Stor).WithMany()
                .HasForeignKey(d => d.StorId)
                .HasConstraintName("FK__discounts__stor___4F7CD00D");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId)
                .HasName("PK_emp_id")
                .IsClustered(false);

            entity.ToTable("employee", tb => tb.HasTrigger("employee_insupd"));

            entity.HasIndex(e => new { e.Lname, e.Fname, e.Minit }, "employee_ind").IsClustered();

            entity.Property(e => e.EmpId)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("emp_id");
            entity.Property(e => e.Fname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("fname");
            entity.Property(e => e.HireDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("hire_date");
            entity.Property(e => e.JobId)
                .HasDefaultValue((short)1)
                .HasColumnName("job_id");
            entity.Property(e => e.JobLvl)
                .HasDefaultValue((byte)10)
                .HasColumnName("job_lvl");
            entity.Property(e => e.Lname)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("lname");
            entity.Property(e => e.Minit)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("minit");
            entity.Property(e => e.PubId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValue("9952")
                .IsFixedLength()
                .HasColumnName("pub_id");

            entity.HasOne(d => d.Job).WithMany(p => p.Employees)
                .HasForeignKey(d => d.JobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__employee__job_id__5BE2A6F2");

            entity.HasOne(d => d.Pub).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__employee__pub_id__5EBF139D");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.JobId).HasName("PK__jobs__6E32B6A5D37BD118");

            entity.ToTable("jobs");

            entity.Property(e => e.JobId).HasColumnName("job_id");
            entity.Property(e => e.JobDesc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("New Position - title not formalized yet")
                .HasColumnName("job_desc");
            entity.Property(e => e.MaxLvl).HasColumnName("max_lvl");
            entity.Property(e => e.MinLvl).HasColumnName("min_lvl");
        });

        modelBuilder.Entity<PubInfo>(entity =>
        {
            entity.HasKey(e => e.PubId).HasName("UPKCL_pubinfo");

            entity.ToTable("pub_info");

            entity.Property(e => e.PubId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pub_id");
            entity.Property(e => e.Logo)
                .HasColumnType("image")
                .HasColumnName("logo");
            entity.Property(e => e.PrInfo)
                .HasColumnType("text")
                .HasColumnName("pr_info");

            entity.HasOne(d => d.Pub).WithOne(p => p.PubInfo)
                .HasForeignKey<PubInfo>(d => d.PubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__pub_info__pub_id__571DF1D5");
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.PubId).HasName("UPKCL_pubind");

            entity.ToTable("publishers");

            entity.Property(e => e.PubId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pub_id");
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValue("USA")
                .HasColumnName("country");
            entity.Property(e => e.PubName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("pub_name");
            entity.Property(e => e.State)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("state");
        });

        modelBuilder.Entity<Roysched>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("roysched");

            entity.HasIndex(e => e.TitleId, "titleidind");

            entity.Property(e => e.Hirange).HasColumnName("hirange");
            entity.Property(e => e.Lorange).HasColumnName("lorange");
            entity.Property(e => e.Royalty).HasColumnName("royalty");
            entity.Property(e => e.TitleId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("title_id");

            entity.HasOne(d => d.Title).WithMany()
                .HasForeignKey(d => d.TitleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__roysched__title___4D94879B");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => new { e.StorId, e.OrdNum, e.TitleId }).HasName("UPKCL_sales");

            entity.ToTable("sales");

            entity.HasIndex(e => e.TitleId, "titleidind");

            entity.Property(e => e.StorId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("stor_id");
            entity.Property(e => e.OrdNum)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ord_num");
            entity.Property(e => e.TitleId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("title_id");
            entity.Property(e => e.OrdDate)
                .HasColumnType("datetime")
                .HasColumnName("ord_date");
            entity.Property(e => e.Payterms)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("payterms");
            entity.Property(e => e.Qty).HasColumnName("qty");

            entity.HasOne(d => d.Stor).WithMany(p => p.Sales)
                .HasForeignKey(d => d.StorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__sales__stor_id__4AB81AF0");

            entity.HasOne(d => d.Title).WithMany(p => p.Sales)
                .HasForeignKey(d => d.TitleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__sales__title_id__4BAC3F29");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.StorId).HasName("UPK_storeid");

            entity.ToTable("stores");

            entity.Property(e => e.StorId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("stor_id");
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.State)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("state");
            entity.Property(e => e.StorAddress)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("stor_address");
            entity.Property(e => e.StorName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("stor_name");
            entity.Property(e => e.Zip)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("zip");
        });

        modelBuilder.Entity<Title>(entity =>
        {
            entity.HasKey(e => e.TitleId).HasName("UPKCL_titleidind");

            entity.ToTable("titles");

            entity.HasIndex(e => e.Title1, "titleind");

            entity.Property(e => e.TitleId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("title_id");
            entity.Property(e => e.Advance)
                .HasColumnType("money")
                .HasColumnName("advance");
            entity.Property(e => e.Notes)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("notes");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.PubId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pub_id");
            entity.Property(e => e.Pubdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("pubdate");
            entity.Property(e => e.Royalty).HasColumnName("royalty");
            entity.Property(e => e.Title1)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.Type)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasDefaultValue("UNDECIDED")
                .IsFixedLength()
                .HasColumnName("type");
            entity.Property(e => e.YtdSales).HasColumnName("ytd_sales");

            entity.HasOne(d => d.Pub).WithMany(p => p.Titles)
                .HasForeignKey(d => d.PubId)
                .HasConstraintName("FK__titles__pub_id__412EB0B6");
        });

        modelBuilder.Entity<Titleauthor>(entity =>
        {
            entity.HasKey(e => new { e.AuId, e.TitleId }).HasName("UPKCL_taind");

            entity.ToTable("titleauthor");

            entity.HasIndex(e => e.AuId, "auidind");

            entity.HasIndex(e => e.TitleId, "titleidind");

            entity.Property(e => e.AuId)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("au_id");
            entity.Property(e => e.TitleId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("title_id");
            entity.Property(e => e.AuOrd).HasColumnName("au_ord");
            entity.Property(e => e.Royaltyper).HasColumnName("royaltyper");

            entity.HasOne(d => d.Au).WithMany(p => p.Titleauthors)                
                .HasForeignKey(d => d.AuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__titleauth__au_id__44FF419A");

            entity.HasOne(d => d.Title).WithMany(p => p.Titleauthors)
                .HasForeignKey(d => d.TitleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__titleauth__title__45F365D3");
        });

        modelBuilder.Entity<Titleview>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("titleview");

            entity.Property(e => e.AuLname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("au_lname");
            entity.Property(e => e.AuOrd).HasColumnName("au_ord");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.PubId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pub_id");
            entity.Property(e => e.Title)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.YtdSales).HasColumnName("ytd_sales");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
