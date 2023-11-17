import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Raw } from '../../model/raw';
import { Product } from '../../model/product';



@Component({
  selector: 'app-simple-count-table',
  templateUrl: './simple-count-table.component.html',
  styleUrls: ['./simple-count-table.component.css']
})
export class SimpleCountTableComponent implements OnInit {
  @Input() displayedColumns: string[] = [ 'name', 'singlePrice','currentAmount','totalValue','options' ];
  @Input() dataSource : Raw[] | Product[] = [];
  
  @Output() addClicked : EventEmitter<any> = new EventEmitter();
  @Output() deleteRowClicked : EventEmitter<any> = new EventEmitter();
  @Output() editRowClicked :  EventEmitter<any> = new EventEmitter();
   
  showOptions:boolean = false;
  selectedRow : any;

  constructor() { }

  ngOnInit(): void {
  }

  addBtnClicked(){
    this.addClicked.emit("");
  }

  editBtnClicked(){
    this.editRowClicked.emit(this.selectedRow);
  }

  deleteBtnClicked(){
    this.deleteRowClicked.emit(this.selectedRow.id);
  }

  selectRow( row : any){
    if(this.selectedRow === row)
      this.selectedRow = undefined;
    else 
      this.selectedRow = row;
  }

  isRowSelected(row : any):boolean{
    return this.selectedRow == row;
  }

}
