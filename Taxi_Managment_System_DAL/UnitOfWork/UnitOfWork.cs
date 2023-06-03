using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_Managment_System_DAL.Data;
using Taxi_Managment_System_DAL.Generic;
using Taxi_Managment_System_DAL.Models;
using Taxi_Managment_System_DAL.UnitOfWork.Interfaces;

namespace Taxi_Managment_System_DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _db;
        private bool disposed = false;
        private GenericRepository<Cab> _cabs;
        private GenericRepository<CabRide> _cabRides;
        private GenericRepository<CabRideStatus> _cabRideStatuses;
        private GenericRepository<Driver> _drivers;
        private GenericRepository<PaymentType> _paymentTypes;
        private GenericRepository<Shift> _shifts;
        private GenericRepository<Status> _statuses;

        public UnitOfWork(DataContext db) { _db = db; }

        public GenericRepository<Cab> Cabs
        {
            get
            {
                if (_cabs == null)
                {
                    _cabs = new GenericRepository<Cab>(_db);
                }
                return _cabs;
            }
        }
        public GenericRepository<CabRide> CabRides
        {
            get
            {
                if (_cabRides == null)
                {
                    _cabRides = new GenericRepository<CabRide>(_db);
                }
                return _cabRides;
            }
        }
        public GenericRepository<CabRideStatus> CabRideStatuses
        {
            get
            {
                if (_cabRideStatuses == null)
                {
                    _cabRideStatuses = new GenericRepository<CabRideStatus>(_db);
                }
                return _cabRideStatuses;
            }
        }
        public GenericRepository<Driver> Drivers
        {
            get
            {
                if (_drivers == null)
                {
                    _drivers = new GenericRepository<Driver>(_db);
                }
                return _drivers;
            }
        }
        public GenericRepository<Shift> Shifts
        {
            get
            {
                if (_shifts == null)
                {
                    _shifts = new GenericRepository<Shift>(_db);
                }
                return _shifts;
            }
        }
        public GenericRepository<PaymentType> PaymentTypes
        {
            get
            {
                if (_paymentTypes == null)
                {
                    _paymentTypes = new GenericRepository<PaymentType>(_db);
                }
                return _paymentTypes;
            }
        }
        public GenericRepository<Status> Statuses
        {
            get
            {
                if (_statuses == null)
                {
                    _statuses = new GenericRepository<Status>(_db);
                }
                return _statuses;
            }
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            disposed = true;
        }
        public void Save()
        {
            _db.SaveChangesAsync();
        }
    }
}
