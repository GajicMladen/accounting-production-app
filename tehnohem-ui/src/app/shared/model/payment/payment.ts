import { PaymentType } from "./paymentType";

export interface Payment{
    
    paymentType:PaymentType;
    
    payerId: string;
    payerName: string;

    receiverId:string;
    receiverName: string;

    paymentItems: PaymentItem[];

    valueTotal : number;

}