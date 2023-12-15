import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule} from '@angular/material/list';
import { MatToolbarModule} from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import { ProductsComponent } from './products/products.component';
import { MatTableModule} from '@angular/material/table';
import { RawsComponent } from './raws/raws.component';
import { SharedModule } from '../shared/shared.module';
import { CompaniesComponent } from './companies/companies.component';
import { SellComponent } from './sell/sell.component';
import { HistoryComponent } from './history/history.component';
import { BussinesFlowComponent } from './bussines-flow/bussines-flow.component';
import { AddNewCompanyComponent } from './companies/components/add-new-company/add-new-company.component';
import { DeliveryPlacesComponent } from './companies/components/delivery-places/delivery-places.component';
import { AddNewRawComponent } from './raws/components/add-new-raw/add-new-raw.component';
import { AddNewProductComponent } from './products/components/add-new-product/add-new-product.component';

@NgModule({
  declarations: [
    ProductsComponent,
    RawsComponent,
    CompaniesComponent,
    SellComponent,
    HistoryComponent,
    BussinesFlowComponent,
    AddNewCompanyComponent,
    DeliveryPlacesComponent,
    AddNewRawComponent,
    AddNewProductComponent
  ],
  imports: [
    CommonModule,
    MatSidenavModule, 
    MatListModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatTableModule,
    SharedModule
  ],
  exports:[
    ProductsComponent,
    RawsComponent,
    CompaniesComponent,
    SellComponent,
    HistoryComponent,
    BussinesFlowComponent
  ]
})
export class FeaturesModule { }
