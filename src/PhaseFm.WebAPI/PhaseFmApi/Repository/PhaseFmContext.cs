using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PhaseFmApi.Models.Entities;

namespace PhaseFmApi.Repository;

public partial class PhaseFmContext : DbContext
{
  public PhaseFmContext()
  {
  }

  public PhaseFmContext(DbContextOptions<PhaseFmContext> options)
	  : base(options)
  {
  }

  public virtual DbSet<Address> Addresses { get; set; }

  public virtual DbSet<Article> Articles { get; set; }

  public virtual DbSet<Basket> Baskets { get; set; }

  public virtual DbSet<Businessdetail> Businessdetails { get; set; }

  public virtual DbSet<Color> Colors { get; set; }

  public virtual DbSet<Delivery> Deliveries { get; set; }

  public virtual DbSet<Discount> Discounts { get; set; }

  public virtual DbSet<Employee> Employees { get; set; }

  public virtual DbSet<Employeetype> Employeetypes { get; set; }

  public virtual DbSet<Event> Events { get; set; }

  public virtual DbSet<Letter> Letters { get; set; }

  public virtual DbSet<Music> Musics { get; set; }

  public virtual DbSet<Musicrequest> Musicrequests { get; set; }

  public virtual DbSet<Musicrequeststatus> Musicrequeststatuses { get; set; }

  public virtual DbSet<Musicsubmission> Musicsubmissions { get; set; }

  public virtual DbSet<Musicsubmissionstatus> Musicsubmissionstatuses { get; set; }

  public virtual DbSet<Order> Orders { get; set; }

  public virtual DbSet<Orderline> Orderlines { get; set; }

  public virtual DbSet<Orderreceivedstatus> Orderreceivedstatuses { get; set; }

  public virtual DbSet<Orderstatus> Orderstatuses { get; set; }

  public virtual DbSet<Playlist> Playlists { get; set; }

  public virtual DbSet<Playlistmusic> Playlistmusics { get; set; }

  public virtual DbSet<Product> Products { get; set; }

  public virtual DbSet<Productcategory> Productcategories { get; set; }

  public virtual DbSet<Productcolor> Productcolors { get; set; }

  public virtual DbSet<Producttype> Producttypes { get; set; }

  public virtual DbSet<Quotation> Quotations { get; set; }

  public virtual DbSet<Quoteline> Quotelines { get; set; }

  public virtual DbSet<Radio> Radios { get; set; }

  public virtual DbSet<Radioshow> Radioshows { get; set; }

  public virtual DbSet<Show> Shows { get; set; }

  public virtual DbSet<User> Users { get; set; }

  public virtual DbSet<Vat> Vats { get; set; }


  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
	modelBuilder.Entity<Address>(entity =>
	{
	  entity.HasKey(e => e.Id).HasName("PK_address_Id");

	  entity.ToTable("address", "phasefm");

	  entity.Property(e => e.Id).ValueGeneratedNever();
	  entity.Property(e => e.PostalCode).HasMaxLength(45);

	  entity.HasOne(d => d.IdNavigation).WithOne(p => p.Address)
			  .HasForeignKey<Address>(d => d.Id)
			  .OnDelete(DeleteBehavior.ClientSetNull)
			  .HasConstraintName("FK_address_user");
	});

	modelBuilder.Entity<Article>(entity =>
	{
	  entity.HasKey(e => e.Id).HasName("PK_article_Id");

	  entity.ToTable("article", "phasefm");

	  entity.Property(e => e.Id).ValueGeneratedNever();
	  entity.Property(e => e.DateGenerated).HasColumnType("date");
	});

	modelBuilder.Entity<Basket>(entity =>
	{
	  entity.HasKey(e => e.Id).HasName("PK_basket_Id");

	  entity.ToTable("basket", "phasefm");

	  entity.Property(e => e.Id).ValueGeneratedNever();

	  entity.HasOne(d => d.Product).WithMany(p => p.Baskets)
			  .HasForeignKey(d => d.ProductId)
			  .OnDelete(DeleteBehavior.ClientSetNull)
			  .HasConstraintName("FK_basket_product");

	  entity.HasOne(d => d.User).WithMany(p => p.Baskets)
			  .HasForeignKey(d => d.UserId)
			  .OnDelete(DeleteBehavior.ClientSetNull)
			  .HasConstraintName("FK_basket_user");
	});

	modelBuilder.Entity<Businessdetail>(entity =>
	{
	  entity.HasKey(e => e.Id).HasName("PK_businessdetail_Id");

	  entity.ToTable("businessdetail", "phasefm");

	  entity.Property(e => e.Id).ValueGeneratedNever();
	  entity.Property(e => e.PostalCode).HasMaxLength(45);
	});

	modelBuilder.Entity<Color>(entity =>
	{
	  entity.HasKey(e => e.Id).HasName("PK_color_Id");

	  entity.ToTable("color", "phasefm");

	  entity.Property(e => e.Id).ValueGeneratedNever();
	});

	modelBuilder.Entity<Delivery>(entity =>
	{
	  entity.HasKey(e => e.Id).HasName("PK_delivery_Id");

	  entity.ToTable("delivery", "phasefm");

	  entity.Property(e => e.Id).ValueGeneratedNever();
	  entity.Property(e => e.Price).HasColumnType("decimal(10, 0)");
	});

	modelBuilder.Entity<Discount>(entity =>
	{
	  entity.HasKey(e => e.Id).HasName("PK_discount_Id");

	  entity.ToTable("discount", "phasefm");

	  entity.Property(e => e.Id).ValueGeneratedNever();
	  entity.Property(e => e.Percentage).HasColumnType("decimal(10, 0)");
	});

	modelBuilder.Entity<Employee>(entity =>
	{
	  entity.HasKey(e => e.Id).HasName("PK_employee_Id");

	  entity.ToTable("employee", "phasefm");

	  entity.Property(e => e.Id).ValueGeneratedNever();
	  entity.Property(e => e.Email).HasMaxLength(1000);
	  entity.Property(e => e.FirstName).HasMaxLength(1000);
	  entity.Property(e => e.LastName).HasMaxLength(1000);
	  entity.Property(e => e.PhoneNumber).HasMaxLength(45);

	  entity.HasOne(d => d.EmployeeType).WithMany(p => p.Employees)
			  .HasForeignKey(d => d.EmployeeTypeId)
			  .OnDelete(DeleteBehavior.ClientSetNull)
			  .HasConstraintName("FK_employee_employeetype");
	});

	modelBuilder.Entity<Employeetype>(entity =>
	{
	  entity.HasKey(e => e.Id).HasName("PK_employeetype_Id");

	  entity.ToTable("employeetype", "phasefm");

	  entity.Property(e => e.Id).ValueGeneratedNever();
	});

	modelBuilder.Entity<Event>(entity =>
	{
	  entity.HasKey(e => e.Id).HasName("PK_event_Id");

	  entity.ToTable("event", "phasefm");

	  entity.Property(e => e.Id).ValueGeneratedNever();
	  entity.Property(e => e.Date).HasColumnType("date");
	  entity.Property(e => e.Description).HasColumnType("text");
	  entity.Property(e => e.Name).HasMaxLength(4000);
	});

	modelBuilder.Entity<Letter>(entity =>
	{
	  entity.HasKey(e => e.Id).HasName("PK_letter_Id");

	  entity.ToTable("letter", "phasefm");

	  entity.Property(e => e.Id).ValueGeneratedNever();
	  entity.Property(e => e.DateGenerated).HasColumnType("date");
	  entity.Property(e => e.LetterContent).HasColumnType("text");
	  entity.Property(e => e.RecipientLastName).HasMaxLength(100);
	  entity.Property(e => e.RecipientName).HasMaxLength(100);
	});

	modelBuilder.Entity<Music>(entity =>
	{
	  entity.HasKey(e => e.Id).HasName("PK_music_Id");

	  entity.ToTable("music", "phasefm");

	  entity.Property(e => e.Id).ValueGeneratedNever();
	  entity.Property(e => e.AlbumName).HasMaxLength(1000);
	  entity.Property(e => e.ArtistName).HasMaxLength(1000);
	  entity.Property(e => e.Composer).HasMaxLength(1000);
	  entity.Property(e => e.Description).HasMaxLength(1000);
	  entity.Property(e => e.RecordLabel).HasMaxLength(1000);
	  entity.Property(e => e.ReleaseDate).HasColumnType("date");
	  entity.Property(e => e.SongName).HasMaxLength(1000);
	});

	modelBuilder.Entity<Musicrequest>(entity =>
	{
	  entity.HasKey(e => e.Id).HasName("PK_musicrequest_Id");

	  entity.ToTable("musicrequest", "phasefm");

	  entity.Property(e => e.Id).ValueGeneratedNever();
	  entity.Property(e => e.ArtistName).HasMaxLength(1000);
	  entity.Property(e => e.DateRequested).HasColumnType("date");
	  entity.Property(e => e.Email).HasMaxLength(1000);
	  entity.Property(e => e.FirstName).HasMaxLength(1000);
	  entity.Property(e => e.LastName).HasMaxLength(1000);
	  entity.Property(e => e.PhoneNumber).HasMaxLength(45);

	  entity.HasOne(d => d.Status).WithMany(p => p.Musicrequests)
			  .HasForeignKey(d => d.StatusId)
			  .OnDelete(DeleteBehavior.ClientSetNull)
			  .HasConstraintName("FK_musicrequest_musicrequeststatus");
	});

	modelBuilder.Entity<Musicrequeststatus>(entity =>
	{
	  entity.HasKey(e => e.Id).HasName("PK_musicrequeststatus_Id");

	  entity.ToTable("musicrequeststatus", "phasefm");

	  entity.Property(e => e.Id).ValueGeneratedNever();
	  entity.Property(e => e.Description).HasMaxLength(2000);
	  entity.Property(e => e.Name).HasMaxLength(1000);
	});

	modelBuilder.Entity<Musicsubmission>(entity =>
	{
	  entity.HasKey(e => e.Id).HasName("PK_musicsubmission_Id");

	  entity.ToTable("musicsubmission", "phasefm");

	  entity.Property(e => e.Id).ValueGeneratedNever();
	  entity.Property(e => e.ArtistName).HasMaxLength(1000);
	  entity.Property(e => e.Composer).HasMaxLength(1000);
	  entity.Property(e => e.Description).HasMaxLength(1000);
	  entity.Property(e => e.Email).HasMaxLength(1000);
	  entity.Property(e => e.FirstName).HasMaxLength(1000);
	  entity.Property(e => e.Genre).HasMaxLength(2000);
	  entity.Property(e => e.LastName).HasMaxLength(1000);
	  entity.Property(e => e.RecordLabel).HasMaxLength(1000);
	  entity.Property(e => e.ReleaseDate).HasColumnType("date");

	  entity.HasOne(d => d.Status).WithMany(p => p.Musicsubmissions)
			  .HasForeignKey(d => d.StatusId)
			  .OnDelete(DeleteBehavior.ClientSetNull)
			  .HasConstraintName("FK_musicsubmission_musicsubmissionstatus");
	});

	modelBuilder.Entity<Musicsubmissionstatus>(entity =>
	{
	  entity.HasKey(e => e.Id).HasName("PK_musicsubmissionstatus_Id");

	  entity.ToTable("musicsubmissionstatus", "phasefm");

	  entity.Property(e => e.Id).ValueGeneratedNever();
	  entity.Property(e => e.Description).HasMaxLength(2000);
	  entity.Property(e => e.Name).HasMaxLength(1000);
	});

	modelBuilder.Entity<Order>(entity =>
	{
	  entity.HasKey(e => e.Id).HasName("PK_order_Id");

	  entity.ToTable("order", "phasefm");

	  entity.Property(e => e.Id).ValueGeneratedNever();
	  entity.Property(e => e.Amount).HasColumnType("decimal(10, 0)");
	  entity.Property(e => e.Date).HasColumnType("date");

	  entity.HasOne(d => d.OrderReceivedStatus).WithMany(p => p.Orders)
			  .HasForeignKey(d => d.OrderReceivedStatusId)
			  .OnDelete(DeleteBehavior.ClientSetNull)
			  .HasConstraintName("FK_order_orderreceivedstatus");

	  entity.HasOne(d => d.OrderStatus).WithMany(p => p.Orders)
			  .HasForeignKey(d => d.OrderStatusId)
			  .OnDelete(DeleteBehavior.ClientSetNull)
			  .HasConstraintName("FK_order_orderstatus");

	  entity.HasOne(d => d.User).WithMany(p => p.Orders)
			  .HasForeignKey(d => d.UserId)
			  .OnDelete(DeleteBehavior.ClientSetNull)
			  .HasConstraintName("FK_order_user");
	});

	modelBuilder.Entity<Orderline>(entity =>
	{
	  entity.HasKey(e => e.Id).HasName("PK_orderline_Id");

	  entity.ToTable("orderline", "phasefm");

	  entity.Property(e => e.Id).ValueGeneratedNever();

	  entity.HasOne(d => d.Product).WithMany(p => p.Orderlines)
			  .HasForeignKey(d => d.ProductId)
			  .OnDelete(DeleteBehavior.ClientSetNull)
			  .HasConstraintName("FK_orderline_product");
	});

	modelBuilder.Entity<Orderreceivedstatus>(entity =>
	{
	  entity.HasKey(e => e.Id).HasName("PK_orderreceivedstatus_Id");

	  entity.ToTable("orderreceivedstatus", "phasefm");

	  entity.Property(e => e.Id).ValueGeneratedNever();
	  entity.Property(e => e.Name).HasMaxLength(1000);
	});

	modelBuilder.Entity<Orderstatus>(entity =>
	{
	  entity.HasKey(e => e.Id).HasName("PK_orderstatus_Id");

	  entity.ToTable("orderstatus", "phasefm");

	  entity.Property(e => e.Id).ValueGeneratedNever();
	  entity.Property(e => e.Name).HasMaxLength(1000);
	});

	modelBuilder.Entity<Playlist>(entity =>
	{
	  entity.HasKey(e => e.Id).HasName("PK_playlist_Id");

	  entity.ToTable("playlist", "phasefm");

	  entity.Property(e => e.Id).ValueGeneratedNever();
	});

	modelBuilder.Entity<Playlistmusic>(entity =>
	{
	  entity.HasKey(e => e.Id).HasName("PK_playlistmusic_Id");

	  entity.ToTable("playlistmusic", "phasefm");

	  entity.Property(e => e.Id).ValueGeneratedNever();

	  entity.HasOne(d => d.Music).WithMany(p => p.Playlistmusics)
			  .HasForeignKey(d => d.MusicId)
			  .OnDelete(DeleteBehavior.ClientSetNull)
			  .HasConstraintName("FK_playlistmusic_music");

	  entity.HasOne(d => d.PlayList).WithMany(p => p.Playlistmusics)
			  .HasForeignKey(d => d.PlayListId)
			  .OnDelete(DeleteBehavior.ClientSetNull)
			  .HasConstraintName("FK_playlistmusic_playlist");
	});

	modelBuilder.Entity<Product>(entity =>
	{
	  entity.HasKey(e => e.Id).HasName("PK_product_Id");

	  entity.ToTable("product", "phasefm");

	  entity.Property(e => e.Id).ValueGeneratedNever();
	  entity.Property(e => e.CostPrice).HasColumnType("decimal(10, 0)");
	  entity.Property(e => e.SellingPrice).HasColumnType("decimal(10, 0)");

	  entity.HasOne(d => d.ProductCategory).WithMany(p => p.Products)
			  .HasForeignKey(d => d.ProductCategoryId)
			  .OnDelete(DeleteBehavior.ClientSetNull)
			  .HasConstraintName("FK_product_productcategory");

	  entity.HasOne(d => d.ProductType).WithMany(p => p.Products)
			  .HasForeignKey(d => d.ProductTypeId)
			  .OnDelete(DeleteBehavior.ClientSetNull)
			  .HasConstraintName("FK_product_producttype");
	});

	modelBuilder.Entity<Productcategory>(entity =>
	{
	  entity.HasKey(e => e.Id).HasName("PK_productcategory_Id");

	  entity.ToTable("productcategory", "phasefm");

	  entity.Property(e => e.Id).ValueGeneratedNever();
	  entity.Property(e => e.Name).HasMaxLength(1000);
	});

	modelBuilder.Entity<Productcolor>(entity =>
	{
	  entity.HasKey(e => e.Id).HasName("PK_productcolor_Id");

	  entity.ToTable("productcolor", "phasefm");

	  entity.Property(e => e.Id).ValueGeneratedNever();

	  entity.HasOne(d => d.Color).WithMany(p => p.Productcolors)
			  .HasForeignKey(d => d.ColorId)
			  .OnDelete(DeleteBehavior.ClientSetNull)
			  .HasConstraintName("FK_productcolor_color");

	  entity.HasOne(d => d.Product).WithMany(p => p.Productcolors)
			  .HasForeignKey(d => d.ProductId)
			  .OnDelete(DeleteBehavior.ClientSetNull)
			  .HasConstraintName("FK_productcolor_product");
	});

	modelBuilder.Entity<Producttype>(entity =>
	{
	  entity.HasKey(e => e.Id).HasName("PK_producttype_Id");

	  entity.ToTable("producttype", "phasefm");

	  entity.Property(e => e.Id).ValueGeneratedNever();
	  entity.Property(e => e.Name).HasMaxLength(2000);

	  entity.HasOne(d => d.ProductCategory).WithMany(p => p.Producttypes)
			  .HasForeignKey(d => d.ProductCategoryId)
			  .OnDelete(DeleteBehavior.ClientSetNull)
			  .HasConstraintName("FK_producttype_productcategory");
	});

	modelBuilder.Entity<Quotation>(entity =>
	{
	  entity.HasKey(e => e.Id).HasName("PK_quotation_Id");

	  entity.ToTable("quotation", "phasefm");

	  entity.Property(e => e.Id).ValueGeneratedNever();
	  entity.Property(e => e.DateCreated).HasColumnType("date");
	});

	modelBuilder.Entity<Quoteline>(entity =>
	{
	  entity.HasKey(e => e.Id).HasName("PK_quoteline_Id");

	  entity.ToTable("quoteline", "phasefm");

	  entity.Property(e => e.Id).ValueGeneratedNever();
	  entity.Property(e => e.CostPerUnit).HasColumnType("decimal(10, 0)");

	  entity.HasOne(d => d.Quotation).WithMany(p => p.Quotelines)
			  .HasForeignKey(d => d.QuotationId)
			  .OnDelete(DeleteBehavior.ClientSetNull)
			  .HasConstraintName("FK_quoteline_quotation");
	});

	modelBuilder.Entity<Radio>(entity =>
	{
	  entity.HasKey(e => e.Id).HasName("PK_radio_Id");

	  entity.ToTable("radio", "phasefm");

	  entity.Property(e => e.Id).ValueGeneratedNever();
	  entity.Property(e => e.Day).HasMaxLength(45);
	});

	modelBuilder.Entity<Radioshow>(entity =>
	{
	  entity.HasKey(e => e.Id).HasName("PK_radioshow_Id");

	  entity.ToTable("radioshow", "phasefm");

	  entity.Property(e => e.Id).ValueGeneratedNever();

	  entity.HasOne(d => d.Radio).WithMany(p => p.Radioshows)
			  .HasForeignKey(d => d.RadioId)
			  .OnDelete(DeleteBehavior.ClientSetNull)
			  .HasConstraintName("FK_radioshow_radio");

	  entity.HasOne(d => d.Show).WithMany(p => p.Radioshows)
			  .HasForeignKey(d => d.ShowId)
			  .OnDelete(DeleteBehavior.ClientSetNull)
			  .HasConstraintName("FK_radioshow_show");
	});

	modelBuilder.Entity<Show>(entity =>
	{
	  entity.HasKey(e => e.Id).HasName("PK_show_Id");

	  entity.ToTable("show", "phasefm");

	  entity.Property(e => e.Id).ValueGeneratedNever();
	});

	modelBuilder.Entity<User>(entity =>
	{
	  entity.HasKey(e => e.Id).HasName("PK_user_Id");

	  entity.ToTable("user", "phasefm");

	  entity.Property(e => e.Id).ValueGeneratedNever();
	  entity.Property(e => e.Email).HasMaxLength(255);
	  entity.Property(e => e.FirstName).HasMaxLength(500);
	  entity.Property(e => e.LastName).HasMaxLength(500);
	  entity.Property(e => e.Password).HasMaxLength(400);
	  entity.Property(e => e.PhoneNumber).HasMaxLength(45);
	});

	modelBuilder.Entity<Vat>(entity =>
	{
	  entity.HasKey(e => e.Id).HasName("PK_vat_Id");

	  entity.ToTable("vat", "phasefm");

	  entity.Property(e => e.Id).ValueGeneratedNever();
	  entity.Property(e => e.Percentage).HasColumnType("decimal(10, 0)");
	});

	OnModelCreatingPartial(modelBuilder);
  }

  partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
