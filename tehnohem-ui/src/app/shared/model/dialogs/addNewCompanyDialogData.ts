import { Company } from "../company";
import { CompanyType } from "../enums/companyType";

export interface AddNewCompanyDialogData {
    companyType: CompanyType;
    company: Company | undefined;
    update:boolean;
}