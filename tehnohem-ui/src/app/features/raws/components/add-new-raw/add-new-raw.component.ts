import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { AddNewRawDialogData } from 'src/app/shared/model/dialogs/addNewRawDialogData';
import { RawType } from 'src/app/shared/model/enums/rawType';
import { Raw } from 'src/app/shared/model/raw';
import { RawService } from 'src/app/shared/services/raw-service/raw.service';

@Component({
  selector: 'app-add-new-raw',
  templateUrl: './add-new-raw.component.html',
  styleUrls: ['./add-new-raw.component.css']
})
export class AddNewRawComponent implements OnInit {

  rawType = RawType;

  form: FormGroup =  new FormGroup({
    name : new FormControl(),
    singlePrice : new FormControl(),
    currentAmount : new FormControl(),
    totalValue : new FormControl(),
  });

  constructor(
    public dialogRef: MatDialogRef<AddNewRawComponent>,
    @Inject(MAT_DIALOG_DATA) public data:AddNewRawDialogData,
    private rawService: RawService
    ) { }

  ngOnInit(): void {
    if(this.data.raw){
      this.form.get("name")?.setValue(this.data.raw?.name)
      this.form.get("singlePrice")?.setValue(this.data.raw?.singlePrice)
      this.form.get("currentAmount")?.setValue(this.data.raw?.currentAmount)
      this.form.get("totalValue")?.setValue(this.data.raw?.totalValue)

    }
  }

  saveRaw(){
    let newRaw : Raw ={
      id: this.data.raw?.id,
      name: this.form.get("name")?.value,
      singlePrice: this.form.get('singlePrice')?.value,
      currentAmount: this.form.get('currentAmount')?.value,
      totalValue: this.form.get('totalValue')?.value,
      rawType: this.data.rawType
    } 

    if(this.data.update){
      
      this.rawService.editRaw(newRaw).subscribe(
        data=>{
          this.dialogRef.close("editedRaw");
        }
      );
    }
    else{
      this.rawService.addNewRaw(newRaw).subscribe(
        data=>{
          this.dialogRef.close("addedNewRaw");
        }
      );
    }

  }

}
