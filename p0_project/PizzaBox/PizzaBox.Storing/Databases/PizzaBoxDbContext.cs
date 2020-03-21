using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Databases
{
  public class PizzaBoxDbContext : DbContext
  {
    public DbSet<Crust> Crust { get; set; }
    public DbSet<Pizza> Pizza { get; set; }
    public DbSet<Size> Size { get; set; }
    public DbSet<Topping> Topping { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Store> Store { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer("server=localhost;database=pizzaboxdb;user id=sa;password=Password12345;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Crust>().HasKey(c => c.CrustId);
      builder.Entity<Pizza>().HasKey(p => p.PizzaId);
      builder.Entity<Pizza>().Property(p => p.PizzaId).ValueGeneratedNever();
      builder.Entity<Order>().HasKey(o => o.OrderId);
      builder.Entity<Order>().Property(o => o.OrderId).ValueGeneratedNever();
      builder.Entity<Size>().HasKey(s => s.SizeId);
      builder.Entity<Topping>().HasKey(t => t.ToppingId);
      builder.Entity<User>().HasKey(u => u.UserId);
      builder.Entity<Store>().HasKey(st => st.StoreId);
      builder.Entity<PizzaTopping>().HasKey(pt => new { pt.PizzaId, pt.ToppingId });
      
      
      

      builder.Entity<Crust>().HasMany(c => c.Pizzas).WithOne(p => p.Crust);
      builder.Entity<Store>().HasMany(st => st.Orders).WithOne(o => o.Store);
      builder.Entity<Pizza>().HasMany(p => p.PizzaToppings).WithOne(pt => pt.Pizza).HasForeignKey(pt => pt.PizzaId);
      builder.Entity<Size>().HasMany(s => s.Pizzas).WithOne(p => p.Size);
      builder.Entity<Topping>().HasMany(t => t.PizzaToppings).WithOne(pt => pt.Topping).HasForeignKey(pt => pt.ToppingId);
      builder.Entity<User>().HasMany(u => u.Orders).WithOne(o => o.User);
      builder.Entity<Store>().HasMany(s => s.Orders).WithOne(o => o.Store);
      builder.Entity<Order>().HasMany(o => o.Pizzas).WithOne(p => p.Order);

      //builder.Entity<Pizza>().HasData(new Pizza[]{});
      //builder.Entity<Order>().HasData(new Pizza[]{});
      builder.Entity<Crust>().HasData(new Crust[]
      {
        new Crust() { Name = "Deep Dish", Price = 3.50M },
        new Crust() { Name = "New York Style", Price = 2.50M },
        new Crust() { Name = "Thin Crust", Price = 1.50M }
      });

      builder.Entity<Size>().HasData(new Size[]
      {
        new Size() { Name = "Large", Price = 12.00M },
        new Size() { Name = "Medium", Price = 10.00M },
        new Size() { Name = "Small", Price = 8.00M },
      });

      builder.Entity<Topping>().HasData(new Topping[]
      {
        new Topping() { Name = "Cheese", Price = 0.25M },
        new Topping() { Name = "Pepperoni", Price = 0.50M },
        new Topping() { Name = "Tomato Sauce", Price = 0.75M },
      });

      builder.Entity<Store>().HasData(new Store[]
      {
        new Store() { StoreAddress = "230 N Center St", StoreCity = "Arlington", StoreState = "TX", StoreZip = "76011"},
        new Store() { StoreAddress = "989 N Walnut Creek Dr", StoreCity = "Mansfield", StoreState = "TX", StoreZip = "76063"},
        new Store() { StoreAddress = "301 W Rendon Crowley Rd", StoreCity = "Burleson", StoreState = "TX", StoreZip = "76028"},
      });


      builder.Entity<User>().HasData(new User[]
      {
        new User() { UserName = "Person1", FirstName = "A", LastName = "B", UserPass = "Password12345", UserAddress = "2700 E Broad St", UserCity = "Mansfield", UserState = "TX", UserZip = "76063"},
        new User() { UserName = "Person2", FirstName = "C", LastName = "D", UserPass = "Password123456", UserAddress = "2602 Mayfield Rd", UserCity = "Grand Prairie", UserState = "TX", UserZip = "75052"},
        new User() { UserName = "Person3", FirstName = "A", LastName = "G", UserPass = "Password1234567", UserAddress = "1 AT&T Way", UserCity = "Arlington", UserState = "TX", UserZip = "76011"},
      });
    }
  }
}
