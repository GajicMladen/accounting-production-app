import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { BussinesFlowComponent } from '../features/bussines-flow/bussines-flow.component';
import { HistoryComponent } from '../features/history/history.component';

@Component({
  selector: 'app-shell',
  templateUrl: './shell.component.html',
  styleUrls: ['./shell.component.css']
})
export class ShellComponent implements OnInit {

  @ViewChild(BussinesFlowComponent) bussinesFlowComponent! : BussinesFlowComponent;
  @ViewChild(HistoryComponent) historyComponent! : HistoryComponent;

  constructor() { }

  ngOnInit(): void {
  }
  tabToShow : number = 6.11;

  updateBussinesFlow(){
    this.bussinesFlowComponent.updateTab(this.tabToShow);
  }

  updateHistoryComponent(){
    this.historyComponent.updateTab(this.tabToShow);
  }
}
