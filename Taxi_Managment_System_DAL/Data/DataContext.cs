﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Taxi_Managment_System_DAL.Data.Configurations;
using Taxi_Managment_System_DAL.Generator;
using Taxi_Managment_System_DAL.Models;

namespace Taxi_Managment_System_DAL.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Cab> Cabs { get; set; }
        public DbSet<CabRide> CabRides { get; set; }
        public DbSet<CabRideStatus> CabRideStatuses { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Status> Statuses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

   /*         DataGenerator.Generator();

            modelBuilder.Entity<Cab>().HasData(DataGenerator.Cabs);
            modelBuilder.Entity<CabRide>().HasData(DataGenerator.CabRides);
            modelBuilder.Entity<Driver>().HasData(DataGenerator.Drivers);
            modelBuilder.Entity<CabRideStatus>().HasData(DataGenerator.CabRideStatuses);
            modelBuilder.Entity<PaymentType>().HasData(DataGenerator.PaymentTypes);
            modelBuilder.Entity<Shift>().HasData(DataGenerator.Shifts);
            modelBuilder.Entity<Status>().HasData(DataGenerator.Statuses);*/
        }
    }
}
