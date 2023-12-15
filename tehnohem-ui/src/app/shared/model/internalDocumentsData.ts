import { InternalDocumentType } from "./enums/invoiceType";
import { DetailInvoiceInfo } from "./invoices/detailInvoiceInfo";

export interface InternalDocumentData{
    title:string;
    documentType:InternalDocumentType;
    isReadonly :boolean;
    invoice? :DetailInvoiceInfo
}