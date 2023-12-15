import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Product } from '../../model/product';
import { ProductService } from '../../services/product-service/product.service';




@Component({
  selector: 'app-product-picker',
  templateUrl: './product-picker.component.html',
  styleUrls: ['./product-picker.component.css']
})
export class ProductPickerComponent implements OnInit {

  @Output() selectedProductEmiter: EventEmitter<Product|undefined> = new EventEmitter();
  selectedProduct : Product | undefined;
  i : number = 0;
  displayedColumns: string[] = [ 'name',"volume"];
  dataSource : Product[] = [];

  constructor(
    private productService:ProductService
  ) { }
  
  ngOnInit(): void {
    this.productService.getAllProducts().subscribe(
      data=>{
        this.dataSource = data;
      }
    )

  }
  
  isRowSelected(row:Product):boolean{
    if(this.selectedProduct != undefined){
      return this.selectedProduct.id === row.id;
    }
    return false; 
  }
  
  clickProduct(row:Product):Product|undefined{
    
    if(this.selectedProduct != undefined && this.selectedProduct.id === row.id)
      this.selectedProduct = undefined;
    else{
      this.selectedProduct = row;
      this.i = this.selectedProduct!.id;
    }

    
    this.selectedProductEmiter.emit(this.selectedProduct);
    return this.selectedProduct;
  }

  clearSelection(){
    this.selectedProduct= undefined;
  }
}
