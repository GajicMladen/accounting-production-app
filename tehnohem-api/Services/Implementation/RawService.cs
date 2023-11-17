using tehnohem_api.Model;
using tehnohem_api.Services.Interface;
using tehnohem_api.UnitOfWork.Interface;

namespace tehnohem_api.Services.Implementation
{
    public class RawService : IRawService
    {
        private IUnitOfWork unitOfWork;
        public RawService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void addNewRaw(Raw raw)
        {
            this.unitOfWork.RawRepository.addNewRaw(raw);
            this.unitOfWork.Commit();
        }

        public ICollection<Raw> getAllRaws()
        {
            return this.unitOfWork.RawRepository.getAllRaws();
        }

        public Raw? getRaw(int id)
        {
            return this.unitOfWork.RawRepository.getRaw(id);
        }

        public void removeRaw(int rawId)
        {
            Raw? raw = this.unitOfWork.RawRepository.getRaw(rawId);
            if (raw != null) { 
                this.unitOfWork.RawRepository.removeRaw(raw);
                this.unitOfWork.Commit();
            }
        }

        public void updateRaw(Raw newRaw)
        {
            Raw? raw = this.unitOfWork.RawRepository.getRaw(newRaw.ID);
            if (raw != null) {
                this.unitOfWork.RawRepository.updateRaw(raw, newRaw);
                this.unitOfWork.Commit();
            }
        }
    }
}
