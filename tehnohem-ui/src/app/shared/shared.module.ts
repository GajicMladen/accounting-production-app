import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { SimpleCountTableComponent } from './components/simple-count-table/simple-count-table.component';
import { CompanyInfoComponent } from './components/company-info/company-info.component';
import { MatCardModule } from '@angular/material/card';
import { CompanyPickerComponent } from './components/company-picker/company-picker.component';
import { MatSelectModule } from '@angular/material/select';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ProductInfoComponent } from './components/product-info/product-info.component';
import { ProductPickerComponent } from './components/product-picker/product-picker.component';
import { MatRadioModule } from '@angular/material/radio';
import { SellProductTableComponent } from './components/sell-product-table/sell-product-table.component';
import { FileInfoComponent } from './components/file-info/file-info.component';
import { InternalDocumentsDialogComponent } from './components/dialogs/internal-documents-dialog/internal-documents-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { SellRawTableComponent } from './components/sell-raw-table/sell-raw-table.component';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { BussinesTablePaidComponent } from './components/bussines-tables/bussines-table-paid/bussines-table-paid.component';
import { BussinesTableExpenseComponent } from './components/bussines-tables/bussines-table-expense/bussines-table-expense.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { HttpClientModule } from '@angular/common/http';
import { LoaderComponent } from './components/loader/loader.component';
import { MatProgressSpinnerModule }from '@angular/material/progress-spinner';

@NgModule({
  declarations: [
    SimpleCountTableComponent,
    CompanyInfoComponent,
    CompanyPickerComponent,
    ProductInfoComponent,
    ProductPickerComponent,
    SellProductTableComponent,
    FileInfoComponent,
    InternalDocumentsDialogComponent,
    SellRawTableComponent,
    BussinesTablePaidComponent,
    BussinesTableExpenseComponent,
    LoaderComponent,
  ],
  imports: [
    CommonModule,
    MatSidenavModule,
    MatListModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatTableModule,
    MatCardModule,
    MatSelectModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatRadioModule,
    MatDialogModule,
    MatCheckboxModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatSlideToggleModule,
    HttpClientModule,
    MatProgressSpinnerModule,
    ReactiveFormsModule
  ],
  exports: [
    MatSidenavModule,
    MatListModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatTableModule,
    MatCardModule,
    MatInputModule,
    MatRadioModule,
    MatFormFieldModule,
    MatDialogModule,
    MatDatepickerModule,
    MatNativeDateModule,
    SimpleCountTableComponent,
    CompanyInfoComponent,
    MatSelectModule,
    CompanyPickerComponent,
    ProductInfoComponent,
    ProductPickerComponent,
    SellProductTableComponent,
    FileInfoComponent,
    InternalDocumentsDialogComponent,
    MatCheckboxModule,
    BussinesTableExpenseComponent,
    FormsModule,
    ReactiveFormsModule,
    MatSlideToggleModule,
    LoaderComponent,
  ],
})
export class SharedModule {}
