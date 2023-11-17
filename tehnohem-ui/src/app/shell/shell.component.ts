import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { BussinesFlowComponent } from '../features/bussines-flow/bussines-flow.component';

@Component({
  selector: 'app-shell',
  templateUrl: './shell.component.html',
  styleUrls: ['./shell.component.css']
})
export class ShellComponent implements OnInit {

  @ViewChild(BussinesFlowComponent) bussinesFlowComponent! : BussinesFlowComponent;

  constructor() { }

  ngOnInit(): void {
  }
  tabToShow : number = 5.1;

  updateBussinesFlow(){
    this.bussinesFlowComponent.updateTab(this.tabToShow);
  }
}
