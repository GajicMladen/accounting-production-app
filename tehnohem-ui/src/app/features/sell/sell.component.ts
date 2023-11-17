import { Component, OnInit, ViewChild } from '@angular/core';
import { SellProductTableComponent } from 'src/app/shared/components/sell-product-table/sell-product-table.component';
import { Product } from 'src/app/shared/model/product';
import { ProductToSell } from 'src/app/shared/model/productToSell';

@Component({
  selector: 'app-sell',
  templateUrl: './sell.component.html',
  styleUrls: ['./sell.component.css']
})
export class SellComponent implements OnInit {

  @ViewChild(SellProductTableComponent) sellComponent! :SellProductTableComponent;


  selectedProduct : Product | undefined;
  newProductToSell : ProductToSell =  {
    position: 3,
    name: "tasko",
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

  constructor() { }

  ngOnInit(): void {
  }

  changedSelectedProduct(newProduct:Product|undefined){
    this.selectedProduct = newProduct;
  }

  addNewProductToList(newProduct: ProductToSell){
    this.sellComponent.addProduct(newProduct);
  }
}
