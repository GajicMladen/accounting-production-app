import { RawType } from "./enums/rawType";

export interface Raw{
    id?:number;
    name: string;
    singlePrice:number;
    currentAmount: number;
    totalValue:number;
    rawType?:RawType;
}