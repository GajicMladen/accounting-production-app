import { Component, Input, OnInit } from '@angular/core';
import { DetailInvoiceInfo } from '../../model/invoices/detailInvoiceInfo';

@Component({
  selector: 'app-file-info',
  templateUrl: './file-info.component.html',
  styleUrls: ['./file-info.component.css']
})
export class FileInfoComponent implements OnInit {
  
  @Input() invoice!: DetailInvoiceInfo;
  
  constructor() { }

  ngOnInit(): void {
  }

}
