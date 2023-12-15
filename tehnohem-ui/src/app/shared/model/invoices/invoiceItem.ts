export interface InvoiceItem{
    itemID:number;
    name: string;
    count: number; //100 
    unit: string; // kom
    price_single: number; //1 km/kom
    pdv:number; //17%
    value_out_pdv:number; //100 (price_out_pdv * count)
    value_pdv:number; //17 ( price_out_pdv * pdv )
    value_total:number; //117 ( price_out_pdv + pdv_value  )
    
    productId? : number;
    rabat? :number ;
    discount? : number;
    price_single_no_pdv?:number;
    price_single_pdv?:number;
    amount? : number;
}