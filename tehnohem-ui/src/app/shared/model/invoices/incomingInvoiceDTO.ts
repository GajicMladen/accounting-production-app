import { Company } from "../company";
import { Raw } from "../raw";
import { RawToSell } from "../rawToSell";

export interface IncomingInvoiceDTO{
    invoiceID: string;
    date : string;
    supplierID: string;
    invoiceItems : RawToSell[];
    totalValueOfPdv: number;
    totalValueWithoutPdv: number;
    totalValue : number;
}