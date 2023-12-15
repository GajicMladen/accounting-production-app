import { CompanyType } from "./enums/companyType";

export interface Company{
    id:string;
    name: string;
    jib: string;
    ib: string;
    address:string;
    phoneNumber:string | undefined;
    email: string;
    companyType: CompanyType;
    contactPerson: string;
    headCompanyId: string | undefined;
}