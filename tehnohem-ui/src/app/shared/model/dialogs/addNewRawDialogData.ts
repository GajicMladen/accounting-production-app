import { RawType } from "../enums/rawType";
import { Raw } from "../raw";

export interface AddNewRawDialogData{
    rawType: RawType;
    raw: Raw| undefined;
    update: boolean;
}