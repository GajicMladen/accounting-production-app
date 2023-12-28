﻿using tehnohem_api.DTO;
using tehnohem_api.Model;
using tehnohem_api.Model.Enums;
using tehnohem_api.Model.Invoice;
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

            this.unitOfWork.InvoiceRepository.AddNewInvoice(newInvoice);
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
            updatedRaw.SinglePrice = (float)Math.Round((float)(updatedRaw.TotalValue / updatedRaw.CurrentAmount),2);
            this.unitOfWork.RawRepository.updateRaw(currentRaw, updatedRaw);
        }

        private void updateRawStateSubtract(IncomingInvoiceItemDTO incomingInvoiceItemDTO)
        {
            Raw currentRaw = this.unitOfWork.RawRepository.getRaw(incomingInvoiceItemDTO.itemID);
            Raw updatedRaw = new Raw();
            updatedRaw.Name = currentRaw.Name;
            var total_value = currentRaw.TotalValue - incomingInvoiceItemDTO.value_total;
            if (total_value < 0)
                updatedRaw.TotalValue = 0;
            else 
                updatedRaw.TotalValue = total_value;
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
            return this.unitOfWork.InvoiceRepository.GetAllOutgoingCashInvoices();
        }

        public List<Invoice> GetAllOutgoingInvoices()
        {
            return this.unitOfWork.InvoiceRepository.GetAllOutgoingInvoices();
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

        public Invoice GetInvoice(string invoiceID)
        {
            return this.unitOfWork.InvoiceRepository.GetInvoiceFullInfo(invoiceID);
            
        }

        public DetailInvoiceInfoDTO GetInvoiceDTO(string invoiceID) { 
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

            this.unitOfWork.InvoiceRepository.AddNewInvoice(newInvoice);
            this.unitOfWork.Commit();
        }

        public List<Invoice> GetAllInternalIssueRaw()
        {
            return this.unitOfWork.InvoiceRepository.GetAllInternalIssueRaw();
        }

        public void AddNewInternalIssueProduct(IncomingInvoiceDTO newIncomingInvoice)
        {
            Invoice newInvoice = new Invoice(newIncomingInvoice, null, null, InvoiceType.INTERNAL_ISSUE_PRODUCT);

            List<InvoiceItem> invoiceItems = new List<InvoiceItem>();
            foreach (IncomingInvoiceItemDTO invoiceItemDTO in newIncomingInvoice.InvoiceItems)
            {
                InvoiceItem invoiceItem = new InvoiceItem(invoiceItemDTO, newInvoice);
                invoiceItem.itemID = invoiceItemDTO.itemID;
                updateProductStateAdd(invoiceItemDTO);
                invoiceItems.Add(invoiceItem);
            }

            newInvoice.InvoiceItems = invoiceItems;

            this.unitOfWork.InvoiceRepository.AddNewInvoice(newInvoice);
            this.unitOfWork.Commit();
        }

        private void updateProductStateAdd(IncomingInvoiceItemDTO incomingInvoiceItemDTO)
        {
            Product currentProduct= this.unitOfWork.ProductRepository.GetProductById(incomingInvoiceItemDTO.itemID);
            Product updatedProduct= new Product(currentProduct);
            updatedProduct.TotalValue = currentProduct.TotalValue + incomingInvoiceItemDTO.value_total;
            updatedProduct.CurrentAmount = currentProduct.CurrentAmount + incomingInvoiceItemDTO.count;
            updatedProduct.SinglePrice = (float)Math.Round((float)(updatedProduct.TotalValue / updatedProduct.CurrentAmount),2);
            this.unitOfWork.ProductRepository.UpdateProduct(currentProduct, updatedProduct);
        }
        private void updateProductStateMinus(OutgoingInvoiceItemDTO incomingInvoiceItemDTO)
        {
            Product currentProduct = this.unitOfWork.ProductRepository.GetProductById((int)incomingInvoiceItemDTO.productId);
            Product updatedProduct = new Product(currentProduct);
            var currentAmount = currentProduct.CurrentAmount - incomingInvoiceItemDTO.amount;
            
            updatedProduct.CurrentAmount = currentProduct.CurrentAmount - incomingInvoiceItemDTO.amount;
            updatedProduct.TotalValue = currentProduct.TotalValue - incomingInvoiceItemDTO.value_total;
            if (currentAmount > 0)
                updatedProduct.SinglePrice = (float)Math.Round((float)(updatedProduct.TotalValue / updatedProduct.CurrentAmount), 2);
            else
                updatedProduct.SinglePrice = currentProduct.SinglePrice;

            
            this.unitOfWork.ProductRepository.UpdateProduct(currentProduct, updatedProduct);
        }
        public List<Invoice> GetAllInternalIssueProduct()
        {
            return this.unitOfWork.InvoiceRepository.GetAllInternalIssueProduct();
        }

        public void AddNewOutgoingInvoice(OutgoingInvoiceDTO newIncomingInvoice)
        {
            Company customer = this.unitOfWork.CompanyRepository.getById(newIncomingInvoice.BuyerID);
            Invoice newInvoice;
            if(newIncomingInvoice.isCashInvoice)
                newInvoice = new Invoice(newIncomingInvoice, null, customer, InvoiceType.OUTGOING_CASH_INVOICE);
            else 
                newInvoice = new Invoice(newIncomingInvoice, null,customer, InvoiceType.OUTGOING_INVOICE);

            List<InvoiceItem> invoiceItems = new List<InvoiceItem>();
            foreach (OutgoingInvoiceItemDTO invoiceItemDTO in newIncomingInvoice.InvoiceItems)
            {
                InvoiceItem invoiceItem = new InvoiceItem(invoiceItemDTO, newInvoice);
                invoiceItem.itemID = invoiceItemDTO.productId;

                if (!newIncomingInvoice.isCashInvoice)
                    updateProductStateMinus(invoiceItemDTO);
                invoiceItems.Add(invoiceItem);
            }

            newInvoice.InvoiceItems = invoiceItems;

            this.unitOfWork.InvoiceRepository.AddNewInvoice(newInvoice);
            this.unitOfWork.Commit();
        }
        public void AddNewIncomingOtherInvoice(IncomingInvoiceDTO newIncomingInvoiceDTO)
        {
            Company supplier = this.unitOfWork.CompanyRepository.getById(newIncomingInvoiceDTO.SupplierID);
            Invoice newInvoice = new Invoice(newIncomingInvoiceDTO, supplier, null, InvoiceType.INCOMING_OTHER_INVOICE);

            List<InvoiceItem> invoiceItems = new List<InvoiceItem>();
            foreach (IncomingInvoiceItemDTO invoiceItemDTO in newIncomingInvoiceDTO.InvoiceItems)
            {
                InvoiceItem invoiceItem = new InvoiceItem(invoiceItemDTO, newInvoice);
                invoiceItems.Add(invoiceItem);
            }
            newInvoice.InvoiceItems = invoiceItems;

            this.unitOfWork.InvoiceRepository.AddNewInvoice(newInvoice);
            this.unitOfWork.Commit();
        }

        public List<Invoice> GetAllIncomingOtherInvoices()
        {
            return this.unitOfWork.InvoiceRepository.GetAllIncomingOtherInvoices();
        }

        public void DeleteInvoice(string invoiceID)
        {
            Invoice? invoice = this.unitOfWork.InvoiceRepository.GetInvoiceFullInfo(invoiceID);
            if (invoice != null) {
                if (invoice.InvoiceType == InvoiceType.OUTGOING_INVOICE)
                {
                    RevertStateOfProductsOutgoingInvoice(invoice);
                }
                else if (invoice.InvoiceType == InvoiceType.INTERNAL_ISSUE_PRODUCT) {
                    RevertStateOfProductsInternalIssue(invoice);
                }
                else if (invoice.InvoiceType == InvoiceType.INCOMING_INVOICE)
                {
                    RevertStateOfRawsIncomingInvoice(invoice);
                }
                else if(invoice.InvoiceType == InvoiceType.INTERNAL_ISSUE_RAW)
                {
                    RevertStateOfRawsInternalIssue(invoice);
                }
                this.unitOfWork.InvoiceRepository.DeleteInvoice(invoice);
                this.unitOfWork.Commit();
            }
        }

        public void RevertStateOfRawsIncomingInvoice(Invoice invoice) { 
            foreach(InvoiceItem invoiceItem in invoice.InvoiceItems)
            {
                Raw raw = this.unitOfWork.RawRepository.getRaw((int)invoiceItem.itemID);
                raw.CurrentAmount = raw.CurrentAmount - invoiceItem.Amount;
                raw.TotalValue = raw.TotalValue- invoiceItem.TotalValue;
            }
        }
        public void RevertStateOfRawsInternalIssue(Invoice invoice)
        {
            foreach (InvoiceItem invoiceItem in invoice.InvoiceItems)
            {
                Raw raw = this.unitOfWork.RawRepository.getRaw((int)invoiceItem.itemID);
                raw.CurrentAmount = raw.CurrentAmount + invoiceItem.Amount;
                raw.TotalValue = raw.TotalValue + invoiceItem.TotalValue;
            }
        }

        public void RevertStateOfProductsOutgoingInvoice(Invoice invoice) {
            foreach (InvoiceItem invoiceItem in invoice.InvoiceItems) {
                Product product = this.unitOfWork.ProductRepository.GetProductById((int)invoiceItem.itemID);
                product.CurrentAmount = product.CurrentAmount + invoiceItem.Amount;
                product.TotalValue = product.TotalValue + invoiceItem.TotalValue;
            }
        }
        public void RevertStateOfProductsInternalIssue(Invoice invoice)
        {
            foreach (InvoiceItem invoiceItem in invoice.InvoiceItems)
            {
                Product product = this.unitOfWork.ProductRepository.GetProductById((int)invoiceItem.itemID);
                product.CurrentAmount = product.CurrentAmount - invoiceItem.Amount;
                product.TotalValue = product.TotalValue - invoiceItem.TotalValue;
            }
        }

    }
}
