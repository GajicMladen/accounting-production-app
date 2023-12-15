import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Company } from 'src/app/shared/model/company';
import { AddNewCompanyDialogData } from 'src/app/shared/model/dialogs/addNewCompanyDialogData';
import { CompanyType } from 'src/app/shared/model/enums/companyType';
import { CompanyService } from 'src/app/shared/services/company-service/company.service';

@Component({
  selector: 'app-add-new-company',
  templateUrl: './add-new-company.component.html',
  styleUrls: ['./add-new-company.component.css']
})
export class AddNewCompanyComponent implements OnInit {

  companyTypes = CompanyType;
  
  form: FormGroup =  new FormGroup({
    name : new FormControl(),
    jib : new FormControl(),
    ib : new FormControl(),
    address : new FormControl(),
    phoneNumber: new FormControl(),
    contactPerson : new FormControl(),
    email : new FormControl()
  });

  constructor(
    public dialogRef: MatDialogRef<AddNewCompanyComponent>,
    @Inject(MAT_DIALOG_DATA) public data:AddNewCompanyDialogData,
    private companyService : CompanyService
  ) { }

  ngOnInit(): void {

    if(this.data.update){
      this.form.get("name")?.setValue(this.data.company?.name);
      this.form.get("jib")?.setValue(this.data.company?.jib);
      this.form.get("ib")?.setValue(this.data.company?.ib);
      this.form.get("address")?.setValue(this.data.company?.address);
      this.form.get("phoneNumber")?.setValue(this.data.company?.phoneNumber);
      this.form.get("contactPerson")?.setValue(this.data.company?.contactPerson);
      this.form.get("email")?.setValue(this.data.company?.email);
    }
  }

  saveCompany(){
    let newCompany : Company = {
      id: this.data.update ? this.data.company!.id : "",
      name: this.form.get('name')!.value,
      jib: this.form.get('jib')!.value,
      ib: this.form.get('ib')!.value,
      address: this.form.get('address')!.value,
      phoneNumber: this.form.get('phoneNumber')!.value,
      email: this.form.get('email')!.value,
      companyType: this.data.companyType,
      contactPerson: this.form.get('contactPerson')!.value,
      headCompanyId: this.data.update ? "" :  this.data.company?.id 
    }
    
    if(this.data.update){
      this.companyService.updateCompany(newCompany).subscribe(
        data =>{
          console.log(data);
          this.dialogRef.close("changed");
        }
      );
    }
    else{
      this.companyService.addNewCompany(newCompany).subscribe(
        data =>{
          console.log(data);
          this.dialogRef.close("addedCompany");
        }
      );
    }

  }
}
