import { DetailInvoiceInfo } from "./invoices/detailInvoiceInfo";

export enum InternalDocumentType{
    INCOMING_INVOICE,
    INCOMING_OTHER_INVOICE,
    OUTGOING_INVOICE,
    OUTGOING_CASH_INVOICE,
    PAYCHECK,
    INTERNAL_ISSUE_RAW,
    INTERNAL_ISSUE_PRODUCT,
    INCOMING_INVOICE_PAYMENT
}

export interface InternalDocumentData{
    title:string;
    documentType:InternalDocumentType;
    isReadonly :boolean;
    invoice? :DetailInvoiceInfo
}