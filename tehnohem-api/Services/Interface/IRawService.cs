using tehnohem_api.Model;

namespace tehnohem_api.Services.Interface
{
    public interface IRawService
    {

        ICollection<Raw> getAllRaws();
        Raw? getRaw(int id);
        void addNewRaw(Raw raw);
        void removeRaw(int raw);
        void updateRaw(Raw raw);
    }
}
