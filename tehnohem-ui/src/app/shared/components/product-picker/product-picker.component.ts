import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Product } from '../../model/product';




const ELEMENT_DATA: Product[] = [
  {id: 0, name: 'Sirce', volume: "1/1", barCode: '4400233300007',singlePrice:11,totalValue:22,currentAmount:2},
  {id: 1, name: 'Task Maxi ', volume: "5/1", barCode: '88002352300007',singlePrice:11,totalValue:22,currentAmount:2},
  {id: 2, name: 'Rival pumpica', volume: "0.75/1", barCode: '4400233300007',singlePrice:11,totalValue:22,currentAmount:2},
  {id: 3, name: 'Auto glas', volume: "3/1", barCode: '440013255632517',singlePrice:11,totalValue:22,currentAmount:2},
  
];
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
  dataSource = ELEMENT_DATA;

  constructor() { }
  
  ngOnInit(): void {
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
