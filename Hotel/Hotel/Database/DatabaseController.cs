using Hotel.Helpers;
using Hotel.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Database
{
    public class DatabaseController
    {
        readonly SQLiteAsyncConnection _database;

        public DatabaseController(string databasePath)
        {
            _database = new SQLiteAsyncConnection(databasePath);
            _database.CreateTableAsync<Reservation>().Wait();
            _database.CreateTableAsync<Attraction>().Wait();
        }

        public Task<List<Reservation>> GetReservationsAsync()
        {
            return _database.Table<Reservation>()
                .OrderBy(t => t.LastName)
                .ThenBy(t => t.FirstName)
                .ToListAsync();
        }

        public Task<List<Attraction>> GetAttractionsAsync()
        {
            return _database.Table<Attraction>()
                .OrderBy(t => t.StartTime)
                .ToListAsync();
        }

        public bool CheckIfReservationIsEmpty()
        {
            var list = _database.Table<Reservation>().ToListAsync().Result;
            if (list.Count == 0)
                return true;
            else
                return false;
        }

        public Task<Reservation> GetReservationAsync(int id)
        {
            return _database.Table<Reservation>()
                .Where(i => i.ReservationId == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveReservationAsync(Reservation reservation)
        {
            if (reservation.ReservationId != 0)
            {
                return _database.UpdateAsync(reservation);
            }
            else
            {
                return _database.InsertAsync(reservation);
            }
        }

        public Task<int> DeleteReservationAsync(Reservation reservation)
        {
            return _database.DeleteAsync(reservation);
        }

        public void loadAttractions()
        {
            AttractionHelper helper = new AttractionHelper();
            var list = helper.createAttractions();
            _database.InsertAsync(list[0]);
            _database.InsertAsync(list[1]);
            _database.InsertAsync(list[2]);
        }
    }
}