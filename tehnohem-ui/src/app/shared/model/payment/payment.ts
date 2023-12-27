import { PaymentItem } from "./paymentItem";
import { PaymentType } from "./paymentType";


export interface Payment{
    paymentId:string;
    paymentIdSystem:string;
    paymentType:PaymentType;
    date: string;
    
    payerID: string;
    payerName: string;

    receiverID:string;
    receiverName: string;

    paymentItems: PaymentItem[];

    totalValue : number;

}