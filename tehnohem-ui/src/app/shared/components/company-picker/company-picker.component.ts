import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Company } from '../../model/company';



export interface PeriodicElement {
  name: string;
  position: number;
  count: number;
  options: string;
}


@Component({
  selector: 'app-company-picker',
  templateUrl: './company-picker.component.html',
  styleUrls: ['./company-picker.component.css']
})
export class CompanyPickerComponent implements OnInit {
  
  @Input() companies: Company[] =[];
  @Input() selectedCompany:Company|undefined;
  
  @Output() companySelected : EventEmitter<any> = new EventEmitter();


  displayedColumns: string[] = [ 'name'];
  
  constructor() { }

  ngOnInit(): void {
  }

  selectRow( row : any){
    if(this.selectedCompany === row)
      this.selectedCompany = undefined;
    else 
      this.selectedCompany = row;
    this.companySelected.emit(this.selectedCompany);
  }

  isRowSelected(row : any):boolean{
    return this.selectedCompany == row;
  }
}
