import { ProductToSell } from "../productToSell";

export interface OutgoingInvoiceDTO {
    invoiceID: string ;
    buyerID: string ;
    date: string ;
    totalValue: number ;
    totalValueOfPDV: number ;
    totalValueWithoutPDV: number ;
    
    invoiceItems:ProductToSell[] ;
       
}