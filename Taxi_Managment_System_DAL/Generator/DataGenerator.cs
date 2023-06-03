using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_Managment_System_DAL.Models;

namespace Taxi_Managment_System_DAL.Generator
{
    internal static class DataGenerator
    {
        public static List<Cab> Cabs = new();
        public static List<CabRide> CabRides = new();
        public static List<CabRideStatus> CabRideStatuses = new();
        public static List<Driver> Drivers = new();
        public static List<Shift> Shifts = new();
        public static List<Status> Statuses = new();
        public static List<PaymentType> PaymentTypes = new();


        private const int _cabs = 10;
        private const int _cabRides = 10;
        private const int _cabRideStatuses = 10;
        private const int _shifts = 10;
        private const int _statuses = 30;
        private const int _paymentTypes = 2;
        private const int _drivers = 10;

        public static void Generator()
        {
            Cabs = new Faker<Cab>()
                .RuleFor()
        }

    }
}
