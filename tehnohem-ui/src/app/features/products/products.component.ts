import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { InternalDocumentsDialogComponent } from 'src/app/shared/components/dialogs/internal-documents-dialog/internal-documents-dialog.component';
import { InternalDocumentData } from 'src/app/shared/model/internalDocumentsData';

import {InternalDocumentType } from 'src/app/shared/model/enums/invoiceType';
import { Product } from 'src/app/shared/model/product';
import { Raw } from 'src/app/shared/model/raw';
import { ProductService } from 'src/app/shared/services/product-service/product.service';
import { AddNewProductComponent } from './components/add-new-product/add-new-product.component';
import { i18nMetaToJSDoc } from '@angular/compiler/src/render3/view/i18n/meta';


@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  displayedColumns: string[] = [ 'name', 'volume','singlePrice','currentAmount','totalValue','options' ];
  
  products : Product[] = [];
  
  constructor(
    public dialog:MatDialog,
    private productService: ProductService
  ) { }

  ngOnInit(): void {
    this.updateProducts();
  }
  
  updateProducts(){
    this.productService.getAllProducts().subscribe(
      data=>{
        this.products = data.sort((a,b) => a.name.charCodeAt(0) - b.name.charCodeAt(0) );;
      }
    )
  }

  dialogData : InternalDocumentData ={
    title:"Predatnica",
    documentType:InternalDocumentType.INTERNAL_ISSUE_PRODUCT,
    isReadonly:false
  }
  
  addProductInvoice(){

    this.dialogData={
      title:"Predatnica",
      documentType:InternalDocumentType.INTERNAL_ISSUE_PRODUCT,
      isReadonly:false
    }
    const dialogRef = this.dialog.open(InternalDocumentsDialogComponent,{
      data:this.dialogData
    });

    dialogRef.afterClosed().subscribe(data =>{
      if(data === "addedNewInternalIssueProduct"){
        this.updateProducts();
      }
    })
  }

  addNewProduct(){
    const dialogRefAddNewProduct = this.dialog.open(AddNewProductComponent,{
      data: {product:undefined,update:false}
    });
    dialogRefAddNewProduct.afterClosed().subscribe(
      data=>{
        if(data=="addedNewProduct"){
          this.updateProducts();
        }
      }
    )
  }

  editProduct(product:Product){
    const dialogRefAddNewProduct = this.dialog.open(AddNewProductComponent,{
      data: {product:product,update:true}
    });
    dialogRefAddNewProduct.afterClosed().subscribe(
      data=>{
        if(data=="editedProduct"){
          this.updateProducts();
        }
      }
    )
  }

  deleteProduct(productId:number){
    this.productService.deleteProduct(productId).subscribe(
      data=>{
        this.updateProducts();
      }
    )
  }

}
