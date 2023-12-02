import { Payment } from "./payment";
import { PaymentType } from "./paymentType";


export interface PaymentDialogData{
    paymentType: PaymentType;
    isReadonly:boolean;
    payment? : Payment;

}