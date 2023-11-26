import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { SellProductTableComponent } from 'src/app/shared/components/sell-product-table/sell-product-table.component';
import { Company } from 'src/app/shared/model/company';
import { OutgoingInvoiceDTO } from 'src/app/shared/model/invoices/outgoingInvoiceDTO';
import { Product } from 'src/app/shared/model/product';
import { ProductToSell } from 'src/app/shared/model/productToSell';
import { CompanyService } from 'src/app/shared/services/company-service/company.service';
import { InvoicesService } from 'src/app/shared/services/invoices-service/invoices.service';

@Component({
  selector: 'app-sell',
  templateUrl: './sell.component.html',
  styleUrls: ['./sell.component.css']
})
export class SellComponent implements OnInit {

  @ViewChild(SellProductTableComponent) sellComponent! :SellProductTableComponent;

  @Input() selectedCompany : Company | undefined ;
  @Input() selectedDeliveryPlace : Company | undefined;


  invoiceID : string = "";
  date : Date  = new Date() ;

  companies : Company[] = [];
  deliveryPlaces : Company[] = [];


  formGroup : FormGroup = new FormGroup({
    singlePrice: new FormControl(),
    amount : new FormControl(),
    unit : new FormControl("1"),
    rabat: new FormControl(0),
    discount: new FormControl(0),
    pdv: new FormControl(7)
  })
  selectedProduct : Product | undefined;
  
  productsToSell : ProductToSell[] = [];
  

  total_value_without_pdv : number = 0;
  total_value_of_pdv : number = 0;
  total_value_with_pdv: number = 0;
  
  constructor(
    private companyService: CompanyService,
    private toastr: ToastrService,
    private invoicesService : InvoicesService
  ) { }

  ngOnInit(): void {
    this.companyService.getAllCustomerCompanies().subscribe(data => {
      this.companies = data.sort((a,b)=> a.name.charCodeAt(0) - b.name.charCodeAt(0));
    })
  }

  deletedProductToSell(product:ProductToSell){
    this.productsToSell = this.productsToSell.filter(r => r != product);
    this.updateTotalPrices();
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
    this.formGroup.get("singlePrice")?.setValue(this.selectedProduct?.singlePrice);
    this.formGroup.get("amount")?.setValue(null);
  }

  addNewProductToList(){

    if( this.productAlreadyAdded(this.selectedProduct!.id) ){
      this.toastr.warning("Već si dodao taj proizvod.");
      return;
    }


    let singlePrice = this.formGroup.get("singlePrice")?.value;
    let amount = this.formGroup.get("amount")?.value;
    let rabat = this.formGroup.get("rabat")?.value;
    let discount = this.formGroup.get("discount")?.value;
    let pdv = this.formGroup.get("pdv")?.value;
    let unit = this.formGroup.get('unit')?.value === '1'? "kom":"l";
    
    let total_value_out_pdv = this.round(singlePrice * amount );
    let total_value_pdv =this.round( total_value_out_pdv * (pdv/100));
    let total_value =this.round( total_value_pdv + total_value_out_pdv);

    let price_single_no_pdv =this.round( total_value_out_pdv / amount);
    let price_single_pdv =this.round( total_value / amount);

    let newProductToSell : ProductToSell =  {
      productId: this.selectedProduct!.id,
      name: this.selectedProduct!.name,
      unit: unit,
      amount: amount,
      price_single: singlePrice,
      rabat: rabat,
      discount: discount,
      pdv: pdv,
      value_out_pdv: total_value_out_pdv,
      value_pdv: total_value_pdv,
      value_total: total_value,

      price_single_no_pdv: price_single_no_pdv,
      price_single_pdv: price_single_pdv,
    }

    this.productsToSell =[...this.productsToSell,newProductToSell];
    this.updateTotalPrices();
  }

  round(num : number):number{
    return Math.round(num*100)/100;
  }

  productAlreadyAdded(productId:number):boolean{
    let exist : boolean = false;
    this.productsToSell.forEach(x => {
      if(x.productId === productId)
        exist = true;
    });
    return exist;
  }

  updateTotalPrices(){
    this.total_value_without_pdv =  0;
    this.total_value_of_pdv =  0;
    this.total_value_with_pdv=  0;

    this.productsToSell.forEach(x =>{
      this.total_value_without_pdv += x.value_out_pdv;
      this.total_value_of_pdv += x.value_pdv;
      this.total_value_with_pdv += x.value_total;
    })
  }

  addNewOutgoingInvoice(){
    let newOutgoingInvoice : OutgoingInvoiceDTO ={
      invoiceID: this.invoiceID,
      buyerID: this.selectedCompany!.id,
      date: this.date.toLocaleDateString('sv'),
      totalValue: this.total_value_with_pdv,
      totalValueOfPDV: this.total_value_of_pdv,
      totalValueWithoutPDV: this.total_value_without_pdv,
      invoiceItems: this.productsToSell
    }
    this.invoicesService.addNewOutgoingInvoice(newOutgoingInvoice).subscribe(
      { 

        error: x => {
          this.toastr.error(x);
        },
        next: x => {
          this.toastr.success(x);
        }
        
      }
    );

  }
}
