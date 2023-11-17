using Microsoft.EntityFrameworkCore;
using tehnohem_api.DB;
using tehnohem_api.Model;
using tehnohem_api.Repositories.Interface;

namespace tehnohem_api.Repositories.Implementation
{
    public class RawRepository : IRawRepository
    {
        private PostgresqlContext postgresqlContext;
        private DbSet<Raw> raws;
        public RawRepository(PostgresqlContext postgresqlContext)
        {
            this.postgresqlContext = postgresqlContext;
            raws= this.postgresqlContext.raws;
        }
        public Raw addNewRaw(Raw raw)
        {
            return this.raws.Add(raw).Entity;
        }

        public ICollection<Raw> getAllRaws()
        {
            return this.raws.ToList();
        }

        public Raw? getRaw(int id)
        {
            return this.raws.Where(r => r.ID == id).FirstOrDefault();
        }

        public void removeRaw(Raw raw)
        {
            this.raws.Remove(raw);
        }

        public void updateRaw(Raw raw, Raw newRaw)
        {
            raw.SinglePrice = newRaw.SinglePrice;
            raw.Name = newRaw.Name;
            raw.TotalValue = newRaw.TotalValue;
            raw.CurrentAmount = newRaw.CurrentAmount;
        }
    }
}
