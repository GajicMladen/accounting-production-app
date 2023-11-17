import { Product } from "../product";

export interface AddNewProductDialogData{
    product: Product | undefined;
    update: boolean;
    
}