using Microsoft.EntityFrameworkCore.Query.Internal;
using tehnohem_api.Model;

namespace tehnohem_api.Repositories.Interface
{
    public interface IRawRepository
    {
        ICollection<Raw> getAllRaws();
        Raw? getRaw(int id);
        Raw addNewRaw(Raw raw);
        void removeRaw(Raw raw);
        void updateRaw(Raw raw,Raw newRaw);

    }
}
