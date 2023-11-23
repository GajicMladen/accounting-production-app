import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { SellProductTableComponent } from 'src/app/shared/components/sell-product-table/sell-product-table.component';
import { Company } from 'src/app/shared/model/company';
import { Product } from 'src/app/shared/model/product';
import { ProductToSell } from 'src/app/shared/model/productToSell';
import { CompanyService } from 'src/app/shared/services/company-service/company.service';

@Component({
  selector: 'app-sell',
  templateUrl: './sell.component.html',
  styleUrls: ['./sell.component.css']
})
export class SellComponent implements OnInit {

  @ViewChild(SellProductTableComponent) sellComponent! :SellProductTableComponent;

  @Input() selectedCompany : Company | undefined ;
  @Input() selectedDeliveryPlace : Company | undefined;

  companies : Company[] = [];
  deliveryPlaces : Company[] = [];

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

  constructor(
    private companyService: CompanyService
  ) { }

  ngOnInit(): void {
    this.companyService.getAllCustomerCompanies().subscribe(data => {
      this.companies = data.sort((a,b)=> a.name.charCodeAt(0) - b.name.charCodeAt(0));
    })
  }

  changeSelectedCompany(selectedCompany: Company){
    this.selectedCompany = selectedCompany;
    this.selectedDeliveryPlace = undefined;
    this.companyService.getAllDeliveryPlaces(this.selectedCompany.id).subscribe(data=> {
        this.deliveryPlaces = data;
      }
    );
  }

  
  changeSelectedDeliveryPlace(selectedDeliveryPlace: Company){
    this.selectedDeliveryPlace = selectedDeliveryPlace;
  }

  changedSelectedProduct(newProduct:Product|undefined){
    this.selectedProduct = newProduct;
  }

  addNewProductToList(newProduct: ProductToSell){
    this.sellComponent.addProduct(newProduct);
  }
}
