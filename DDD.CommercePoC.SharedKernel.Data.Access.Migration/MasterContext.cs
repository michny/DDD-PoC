﻿using System.Data.Entity;
using DDD.CommercePoC.Shop.Core.Model;
using DDD.CommercePoC.Shop.Core.Model.CartAggregate;
using DDD.CommercePoC.Shop.Core.Model.OrderAggregate;
using DDD.CommercePoC.Shop.Core.Model.ProductAggregate;
using DDD.CommercePoC.Shop.Core.Model.ValueObjects;

namespace DDD.CommercePoC.SharedKernel.Data.Access.Migration
{
    public class MasterContext : DatabaseContext
    {
        public MasterContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MasterContext, Configuration.DbMigrationConfiguration>());
        }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CartLineItem> CartLineItems { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Variant> Variants { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderLineItem> OrderLineItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.ComplexType<Money>();

            base.OnModelCreating(modelBuilder);
        }
    }
}