import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Company } from 'src/app/shared/model/company';
import { CompanyService } from 'src/app/shared/services/company-service/company.service';
import { AddNewCompanyComponent } from '../add-new-company/add-new-company.component';
import { CompanyType } from 'src/app/shared/model/enums/companyType';

@Component({
  selector: 'app-delivery-places',
  templateUrl: './delivery-places.component.html',
  styleUrls: ['./delivery-places.component.css']
})
export class DeliveryPlacesComponent implements OnInit {

  deliveryPlaces : Company[] = [];

  constructor(
    public dialogRef: MatDialogRef<DeliveryPlacesComponent>,
    @Inject(MAT_DIALOG_DATA) public data:Company,
    private companyService : CompanyService,
    public dialog:MatDialog
    ) { }

  ngOnInit(): void {
    this.updateDeliveryPlaces();
  }

  updateDeliveryPlaces(){
    this.companyService.getAllDeliveryPlaces(this.data.id).subscribe(
      data =>{
        this.deliveryPlaces = data;
      }
    )
  }

  addNewDeliveryPlace(){
    const dialogRefNewDeliveryPlace = this.dialog.open(AddNewCompanyComponent,{
      data:{ companyType: CompanyType.CUSTOMER_DELIVERY_PLACE, company: this.data, update:false}
    })

    dialogRefNewDeliveryPlace.afterClosed().subscribe(data => {
      this.updateDeliveryPlaces();
    });
  }

}
