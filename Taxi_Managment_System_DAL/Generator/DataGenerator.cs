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
        private const int _statuses = 3;
        private const int _paymentTypes = 2;
        private const int _drivers = 10;

        public static void Generator()
        {
            Cabs = new Faker<Cab>()
                .RuleFor(c => c.LicensePlate, f=> f.Vehicle.Random.AlphaNumeric(6))
                .RuleFor(c=>c.Manufacture_year, f=> f.Random.Int(30))
                .RuleFor(c=>c.CarModel, f=>f.Vehicle.Model())
                .RuleFor(c=>c.Active, f=>f.Random.Bool())
                .Generate(_cabs);

            Drivers = new Faker<Driver>()
                .RuleFor(x => x.FirstName, f => f.Person.FirstName)
               .RuleFor(x => x.LastName, f => f.Person.LastName)
               .RuleFor(x => x.Working, f => f.Random.Bool())
               .RuleFor(x=>x.DrivingLicenceNumber, f => f.Random.AlphaNumeric(10))
               .RuleFor(x=>x.BirthDate, f=>f.Date.Past())
               .RuleFor(x=>x.ExpiryDate, f=>f.Date.Past())
                .Generate(_drivers);

            Statuses = new Faker<Status>()
                .RuleFor(s=>s.StatusName, f=>f.PickRandom("В дорозі","Очікує","Подорож закінчена"))
                .Generate(_statuses);

            Shifts = new Faker<Shift>()
                .RuleFor(s => s.ShiftEndTime, f=> f.Date.Past())
                .RuleFor(s=>s.ShiftStartTime, (f, x) => f.Date.Between(x.ShiftEndTime, x.ShiftEndTime.AddHours(12)))
                .RuleFor(s=>s.CabId, f=>f.PickRandom(Cabs).Id)
                .RuleFor(s => s.DriverId, f => f.PickRandom(Drivers).Id)
                .Generate(_shifts);

            PaymentTypes = new Faker<PaymentType>()
                 .RuleFor(s => s.NameType, f => f.PickRandom("готівка", "карта"))
                .Generate(_paymentTypes);

            CabRides = new Faker<CabRide>()
                .RuleFor(s => s.Canceled, f=>f.Random.Bool())
                .RuleFor(s=>s.AddressStartingPoint, f=>f.Address.StreetAddress())
                .RuleFor(s => s.AddressDestination, f => f.Address.StreetAddress())
                .RuleFor(s => s.Price, f => f.Finance.Amount())
                .RuleFor(s => s.RideStartTime, f => f.Date.Past())
                .RuleFor(s => s.RideEndTime, (f, x) => f.Date.Between(x.RideStartTime, x.RideStartTime.AddMinutes(30)))
                .RuleFor(s => s.ShiftId, f => f.PickRandom(Shifts).Id)
                .RuleFor(s => s.PaymentTypeId, f => f.PickRandom(PaymentTypes).Id)
                .Generate(_cabRides);

            CabRideStatuses = new Faker<CabRideStatus>()
                .RuleFor(s => s.StatusId, f => f.PickRandom(Statuses).Id)
                .RuleFor(s => s.CabRideId, f => f.PickRandom(CabRides).Id)
                .RuleFor(s=>s.StatusTime, f => f.Date.Past())
                .Generate(_cabRideStatuses);
        }

    }
}
