import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { AddNewProductDialogData } from 'src/app/shared/model/dialogs/addNewProductDialogData';
import { Product } from 'src/app/shared/model/product';
import { ProductService } from 'src/app/shared/services/product-service/product.service';

@Component({
  selector: 'app-add-new-product',
  templateUrl: './add-new-product.component.html',
  styleUrls: ['./add-new-product.component.css']
})
export class AddNewProductComponent implements OnInit {

  form: FormGroup =  new FormGroup({
    name : new FormControl(),
    barCode : new FormControl(),
    volume : new FormControl(),
    currentAmount : new FormControl(),
    singlePrice: new FormControl(),
    totalValue : new FormControl(),
  });

  constructor(
    public dialogRef: MatDialogRef<AddNewProductComponent>,
    @Inject(MAT_DIALOG_DATA) public data:AddNewProductDialogData,
    private productService: ProductService
    ) { }

  ngOnInit(): void {
    if(this.data.update){
      this.form.get('name')?.setValue(this.data.product!.name);
      this.form.get('volume')?.setValue(this.data.product!.volume);
      this.form.get('barCode')?.setValue(this.data.product!.barCode);
      this.form.get('currentAmount')?.setValue(this.data.product!.currentAmount);
      this.form.get('singlePrice')?.setValue(this.data.product!.singlePrice);
      this.form.get('totalValue')?.setValue(this.data.product!.totalValue);
    }
  }

  saveProduct(){
    let newProduct : Product = {
      id: this.data.product ?  this.data.product?.id: 0,
      name: this.form.get('name')?.value,
      volume: this.form.get('volume')?.value,
      barCode: this.form.get('barCode')?.value,
      currentAmount: this.form.get('currentAmount')?.value,
      singlePrice: this.form.get('singlePrice')?.value,
      totalValue: this.form.get('totalValue')?.value,
    }

    if(this.data.update){
      this.productService.editProduct(newProduct).subscribe(
        data=>{
          this.dialogRef.close("editedProduct");
        }
      )
    }
    else{
      this.productService.addNewProduct(newProduct).subscribe(
        data=>{
          this.dialogRef.close("addedNewProduct");
        }
      );
    }
  }

}
