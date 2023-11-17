using tehnohem_api.DTO;
using tehnohem_api.Model;
using tehnohem_api.Model.Enums;
using tehnohem_api.Services.Interface;
using tehnohem_api.UnitOfWork.Interface;

namespace tehnohem_api.Services.Implementation
{
    public class InvoicesService : IInvoicesService
    {
        private IUnitOfWork unitOfWork;

        public InvoicesService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void AddNewIncomingInvoice(IncomingInvoiceDTO newIncomingInvoiceDTO)
        {
            Company supplier = this.unitOfWork.CompanyRepository.getById(newIncomingInvoiceDTO.SupplierID);
            
            Invoice newInvoice = new Invoice(newIncomingInvoiceDTO,supplier,null,InvoiceType.INCOMING_INVOICE);

            List<InvoiceItem> invoiceItems = new List<InvoiceItem>();
            foreach (IncomingInvoiceItemDTO invoiceItemDTO in newIncomingInvoiceDTO.InvoiceItems)
            {
                InvoiceItem invoiceItem = new InvoiceItem(invoiceItemDTO,newInvoice);
                if (invoiceItemDTO.itemID == -1)
                {
                    invoiceItem.itemID = addNewRaw(invoiceItemDTO);
                }
                else {
                    invoiceItem.itemID = invoiceItemDTO.itemID;
                    updateRawStateAdd(invoiceItemDTO);
                }
                invoiceItems.Add(invoiceItem);
            }

            newInvoice.InvoiceItems = invoiceItems;

            this.unitOfWork.InvoiceRepository.AddNewIncomingInvoice(newInvoice);
            this.unitOfWork.Commit();
        }
        private int addNewRaw(IncomingInvoiceItemDTO incomingInvoiceItemDTO) {
            Raw newRaw = new Raw();
            newRaw.Name = incomingInvoiceItemDTO.name;
            newRaw.CurrentAmount = incomingInvoiceItemDTO.count;
            newRaw.RawType = incomingInvoiceItemDTO.rawType;
            newRaw.SinglePrice = incomingInvoiceItemDTO.price_single;
            newRaw.TotalValue = incomingInvoiceItemDTO.value_total;
            newRaw = this.unitOfWork.RawRepository.addNewRaw(newRaw);
            return newRaw.ID;
        }

        private void updateRawStateAdd(IncomingInvoiceItemDTO incomingInvoiceItemDTO) {
            Raw currentRaw = this.unitOfWork.RawRepository.getRaw(incomingInvoiceItemDTO.itemID);
            Raw updatedRaw = new Raw();
            updatedRaw.Name = currentRaw.Name;
            updatedRaw.TotalValue = currentRaw.TotalValue + incomingInvoiceItemDTO.value_total;
            updatedRaw.CurrentAmount = currentRaw.CurrentAmount + incomingInvoiceItemDTO.count;
            updatedRaw.SinglePrice = (float)(updatedRaw.TotalValue / updatedRaw.CurrentAmount);
            this.unitOfWork.RawRepository.updateRaw(currentRaw, updatedRaw);
        }

        private void updateRawStateSubtract(IncomingInvoiceItemDTO incomingInvoiceItemDTO)
        {
            Raw currentRaw = this.unitOfWork.RawRepository.getRaw(incomingInvoiceItemDTO.itemID);
            Raw updatedRaw = new Raw();
            updatedRaw.Name = currentRaw.Name;
            updatedRaw.TotalValue = currentRaw.TotalValue - incomingInvoiceItemDTO.value_total;
            updatedRaw.CurrentAmount = currentRaw.CurrentAmount - incomingInvoiceItemDTO.count;
            updatedRaw.SinglePrice = currentRaw.SinglePrice;
            this.unitOfWork.RawRepository.updateRaw(currentRaw, updatedRaw);
        }
        public List<Invoice> GetAllIncomingInvoices()
        {
            return this.unitOfWork.InvoiceRepository.GetAllIncomingInvoices();
        }

        public List<Invoice> GetAllOutgoingCashInvoices()
        {
            throw new NotImplementedException();
        }

        public List<Invoice> GetAllOutgoingInvoices()
        {
            throw new NotImplementedException();
        }

        public List<GeneralInvoiceInfoDTO> GetGeneralInvoicesInfo(List<Invoice> invoices)
        {
            List<GeneralInvoiceInfoDTO> retVal = new List<GeneralInvoiceInfoDTO>();
            foreach (var item in invoices)
            {
                GeneralInvoiceInfoDTO newItem = new GeneralInvoiceInfoDTO(item);
                retVal.Add(newItem);
            }
            return retVal;
        }

        public DetailInvoiceInfoDTO GetIncomingInvoice(string invoiceID) { 
            Invoice invoice = this.unitOfWork.InvoiceRepository.GetInvoiceFullInfo(invoiceID);
            return new DetailInvoiceInfoDTO(invoice);
        }

        public List<DetailInvoiceInfoDTO> GetDetailInvoicesInfo(List<Invoice> invoices)
        {
            List<DetailInvoiceInfoDTO> retVal = new List<DetailInvoiceInfoDTO>();
            foreach (var item in invoices)
            {
                DetailInvoiceInfoDTO newItem = new DetailInvoiceInfoDTO(item);
                retVal.Add(newItem);
            }
            return retVal;
        }

        public void AddNewInternalIssueRaw(IncomingInvoiceDTO newIncomingInvoiceDTO)
        {

            Invoice newInvoice = new Invoice(newIncomingInvoiceDTO, null, null, InvoiceType.INTERNAL_ISSUE_RAW);

            List<InvoiceItem> invoiceItems = new List<InvoiceItem>();
            foreach (IncomingInvoiceItemDTO invoiceItemDTO in newIncomingInvoiceDTO.InvoiceItems)
            {
                InvoiceItem invoiceItem = new InvoiceItem(invoiceItemDTO, newInvoice);
                invoiceItem.itemID = invoiceItemDTO.itemID;
                updateRawStateSubtract(invoiceItemDTO);
                invoiceItems.Add(invoiceItem);
            }

            newInvoice.InvoiceItems = invoiceItems;

            this.unitOfWork.InvoiceRepository.AddNewIncomingInvoice(newInvoice);
            this.unitOfWork.Commit();
        }

        public List<Invoice> GetAllInternalIssueRaw()
        {
            return this.unitOfWork.InvoiceRepository.GetAllInternalIssueRaw();
        }
    }
}
