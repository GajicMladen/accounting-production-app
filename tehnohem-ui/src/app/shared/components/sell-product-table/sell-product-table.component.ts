import { Component, OnInit } from '@angular/core';
import { ProductToSell } from '../../model/productToSell';
import { Product } from '../../model/product';
;

let ELEMENT_DATA: ProductToSell[] = [
  {
    position: 1,
    name: "sirce",
    count: 96,
    price_single: 0.94,
    price_total:90.24,
    rabat:21.89,
    discount: 0,
    osnovica_pdv_a:68.35,
    pdv:11.62,
    price_pdv:79.97,
    price_single_no_pdv:0.712,
    price_single_pdv:0.83,
  },
  {
    position: 2,
    name: "sirce",
    count: 96,
    price_single: 0.94,
    price_total:90.24,
    rabat:21.89,
    discount: 0,
    osnovica_pdv_a:68.35,
    pdv:11.62,
    price_pdv:79.97,
    price_single_no_pdv:0.712,
    price_single_pdv:0.83,
  },
  {
    position: 3,
    name: "sirce",
    count: 96,
    price_single: 0.94,
    price_total:90.24,
    rabat:21.89,
    discount: 0,
    osnovica_pdv_a:68.35,
    pdv:11.62,
    price_pdv:79.97,
    price_single_no_pdv:0.712,
    price_single_pdv:0.83,
  }
];

@Component({
  selector: 'app-sell-product-table',
  templateUrl: './sell-product-table.component.html',
  styleUrls: ['./sell-product-table.component.css']
})
export class SellProductTableComponent implements OnInit {
  displayedColumns: string[] = [ 
    "position",
    "name",
    "count",
    "price_single",
    "price_total",
    "rabat",
    "discount",
    "osnovica_pdv_a",
    "pdv",
    "price_pdv",
    "price_single_no_pdv",
    "price_single_pdv",
    "delete"
  ];
  dataSource = ELEMENT_DATA;

  selectedRow : ProductToSell | undefined;
  constructor(
  ) { }

  ngOnInit(): void {
  }
  isRowSelected(row:ProductToSell):boolean{
    if(this.selectedRow != undefined){
      return this.selectedRow!.position === row.position;
    }
    return false; 
  }
  clickRow(row:ProductToSell):ProductToSell | undefined{
    
    if(this.selectedRow != undefined && this.selectedRow.position === row.position)
      return undefined;
    
    return row; 
  }
  
  deleteProduct(product:ProductToSell){
    this.dataSource = this.dataSource.filter(item => item !== product);
    console.log(this.dataSource);
  }

  addProduct(newProduct:ProductToSell){
    this.dataSource = [...this.dataSource, newProduct];
    console.log(this.dataSource);
  }
}
