
export interface ProductToSell {
    productId:number;
    name: string;
    unit:string;
    price_single: number;
    amount: number;
    pdv:number;
    
    value_out_pdv:number;
    value_pdv:number;
    value_total:number;
    
    rabat:number;
    discount: number;
    price_single_no_pdv:number;
    price_single_pdv:number;
  }