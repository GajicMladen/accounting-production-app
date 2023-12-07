import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompaniesComponent } from './features/companies/companies.component';
import { RawsComponent } from './features/raws/raws.component';
import { ProductsComponent } from './features/products/products.component';
import { SellComponent } from './features/sell/sell.component';
import { HistoryComponent } from './features/history/history.component';
import { BussinesFlowComponent } from './features/bussines-flow/bussines-flow.component';

const routes: Routes = [
  {path:'',redirectTo:'companies',pathMatch:'full'},
  {path:'companies', component: CompaniesComponent},
  {path:'raws', component: RawsComponent},
  {path:'products', component: ProductsComponent},
  {path:'sell', component: SellComponent},
  {path:'history', component: HistoryComponent},
  {path:'bussinesFlow', component: BussinesFlowComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { 


}
