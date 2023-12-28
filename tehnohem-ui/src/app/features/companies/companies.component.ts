import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Company } from 'src/app/shared/model/company';
import { AddNewCompanyDialogData } from 'src/app/shared/model/dialogs/addNewCompanyDialogData';
import { CompanyType } from 'src/app/shared/model/enums/companyType';
import { CompanyService } from 'src/app/shared/services/company-service/company.service';
import { AddNewCompanyComponent } from './components/add-new-company/add-new-company.component';
import { TabService } from 'src/app/shared/services/tabService/tab.service';

@Component({
  selector: 'app-companies',
  templateUrl: './companies.component.html',
  styleUrls: ['./companies.component.css']
})
export class CompaniesComponent implements OnInit {

  @Input() tabToShow: number = 0;
  suppliers: Company[] = [];
  customers: Company[] = [];
  thirdPartyCompanies: Company[] = [];

  constructor(
    private companyService:CompanyService,
    public dialog:MatDialog,
    private tabService: TabService,
  ) { }

  ngOnInit(): void {
    this.tabService.getTab$().subscribe(data => {
      this.tabToShow = data;
    });
    this.updateData();
  }

  updateData(){
    this.companyService.getAllSupplierCompanies().subscribe(
      data=> {
        this.suppliers = data;
      }
    );
    this.companyService.getAllCustomerCompanies().subscribe(
      data=> {
        this.customers = data;
      }
    );
    this.companyService.getAllThirdPartyCompanies().subscribe(
      data=> {
        this.thirdPartyCompanies = data;
      }
    );
  }
  dialogData!: AddNewCompanyDialogData;
  companyType : CompanyType = CompanyType.SUPPLIER;
  
  addNewCompany(){
    if(this.tabToShow === 3.1 )
      this.companyType= CompanyType.SUPPLIER;
    else if(this.tabToShow === 3.2 )
    this.companyType= CompanyType.CUSTOMER;
    else if(this.tabToShow === 3.3 )
      this.companyType= CompanyType.THIRD_PARTY;
    this.dialogData={
      companyType:this.companyType,
      update:false,
      company:undefined
    }
    const dialogRef = this.dialog.open(AddNewCompanyComponent,{
      data:this.dialogData
    });
    dialogRef.afterClosed().subscribe(data => {
      if( data == "addedCompany")
        this.updateData();
    })
  }

  companyDeleted(){
    this.updateData();
  }

}
