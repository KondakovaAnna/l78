using Lab78.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab78.Data;

public class DBContext : DbContext
{
    public DBContext(DbContextOptions<DBContext> options) : base(options)
    {
        //Database.EnsureCreated();
    }

    public DbSet<Superhero> Superheroes { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<Colour> Colours { get; set; }
    public DbSet<Race> Races { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Hero_attribute> HeroAttributes { get; set; }
    public DbSet<Hero_power> HeroPowers { get; set; }
    public DbSet<Alignment> Alignments { get; set; }
    public DbSet<Attribute_db> Attributes { get; set; }
    public DbSet<Superpower> Superpowers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlite("Filename=superhero.db");
        base.OnConfiguring(optionsBuilder);
        // if (optionsBuilder.IsConfigured)
        // {
        //     optionsBuilder.UseSqlServer("Filename=Superheroes.db", builder => builder.EnableRetryOnFailure());
        // }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Superhero>().ToTable("superhero")
            .HasMany(e=>e.attributes)
            .WithOne(e => e.Superhero)
            .OnDelete(DeleteBehavior.Cascade);
        // .HasMany(e => e.attributes)
        // .WithOne(e => e.Superhero)
        // .HasForeignKey(e => e.hero_id);
        modelBuilder.Entity<Gender>(entity => 
        entity.ToTable("gender"));//.ToTable("gender");
        modelBuilder.Entity<Colour>().ToTable("colour");
        modelBuilder.Entity<Race>().ToTable("race");
        modelBuilder.Entity<Publisher>().ToTable("publisher");
        modelBuilder.Entity<Hero_attribute>().ToTable("hero_attribute")
            .HasOne(e => e.Superhero)
            .WithMany(e => e.attributes)
            .HasForeignKey(e => e.hero_id);
            modelBuilder.Entity<Hero_power>().ToTable("hero_power")
                .HasOne(e => e.Superhero)
                .WithMany(e => e.powers)
                .HasForeignKey(e => e.hero_id);
		modelBuilder.Entity<Alignment>(entity =>
            entity.ToTable("alignment"));
		//modelBuilder.Entity<Alignment>().ToTable("Alignment");
        modelBuilder.Entity<Attribute_db>().ToTable("attribute");
        modelBuilder.Entity<Superpower>().ToTable("superpower");
    }
}