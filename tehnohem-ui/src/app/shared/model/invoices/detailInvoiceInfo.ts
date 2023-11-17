import { InternalDocumentType } from "../internalDocumentsData";
import { InvoiceItem } from "./invoiceItem";

export interface DetailInvoiceInfo{
    invoiceID: string;
    date : Date;

    invoiceType: InternalDocumentType;

    supplierID: string;
    supplierName: string;

    customerID:string;
    customerName: string;
    
    valueOutPdv: number;
    valuePdv : number;
    valueTotal: number;

    items : InvoiceItem[];

}