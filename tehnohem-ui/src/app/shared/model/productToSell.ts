
export interface ProductToSell {
    productId:number;
    name: string;
    price_single: number;
    amount: number;
    rabat:number;
    discount: number;
    pdv:number;

    total_value_out_pdv:number;
    total_value_pdv:number;
    total_value:number;

    price_single_no_pdv:number;
    price_single_pdv:number;
  }