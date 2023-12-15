import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-test',
  template: '<button (click)="showToastr()">Show Toastr</button>',
})
export class TestComponent {
  constructor(private toastr: ToastrService) {}

  ngOnInit() {
    // Try showing a Toastr message on component initialization
    this.toastr.success('This is a test Toastr message');
  }
  showToastr() {
    this.toastr.success('This is a test Toastr message');
  }
}
