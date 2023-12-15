import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Company } from '../../model/company';
import { CompanyService } from '../../services/company-service/company.service';
import { MatDialog } from '@angular/material/dialog';
import { DeliveryPlacesComponent } from 'src/app/features/companies/components/delivery-places/delivery-places.component';
import { AddNewCompanyComponent } from 'src/app/features/companies/components/add-new-company/add-new-company.component';


@Component({
  selector: 'app-company-info',
  templateUrl: './company-info.component.html',
  styleUrls: ['./company-info.component.css']
})
export class CompanyInfoComponent implements OnInit {

  @Input() company!:Company;
  @Input() isReadonly:boolean = false;
  @Input() deleteOption: boolean= true;
  @Input() deliveryPlacesOption : boolean = true;

  @Output() deletedEmiter : EventEmitter<any> = new EventEmitter<any>();

  
  constructor(
    private companyService: CompanyService,
    public dialog:MatDialog
  ) { }

  ngOnInit(): void {
  }

  deleteCompany(companyId: string){
    this.companyService.deleteCompany(companyId).subscribe(
      data => {
        console.log(data);
        this.deletedEmiter.emit("");
      }
    )
  }

  openDeliveryPlacesInfo(){
    const dialogRef = this.dialog.open(DeliveryPlacesComponent,{
      data:this.company
    });
  }

  openCompanyInfo(){
    if(!this.isReadonly){
      const dialogRefEditCompany = this.dialog.open(AddNewCompanyComponent,{
        data: {company: this.company ,companyType: this.company.companyType , update: true}
      });
      dialogRefEditCompany.afterClosed().subscribe(
        data => {
          console.log(data);
          if(data == "changed")
            this.updateCompanyData();
        }
      )
    }
  }

  updateCompanyData(){
    this.companyService.getCompanyInfo(this.company.id).subscribe(
      data =>{
        this.company = data;
      }
    )
  }
}
