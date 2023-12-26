import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { BussinesFlowComponent } from '../features/bussines-flow/bussines-flow.component';
import { HistoryComponent } from '../features/history/history.component';
import { TabService } from '../shared/services/tabService/tab.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-shell',
  templateUrl: './shell.component.html',
  styleUrls: ['./shell.component.css']
})
export class ShellComponent implements OnInit {

  @ViewChild(BussinesFlowComponent) bussinesFlowComponent! : BussinesFlowComponent;
  @ViewChild(HistoryComponent) historyComponent! : HistoryComponent;

  constructor(
    private tabService:TabService,
    private router: Router,
  ) { }

  ngOnInit(): void {
  }
  tabToShow : number = 3.1;

  changeTab(newTab:number){
    this.tabToShow= newTab;
    this.tabService.changeTab(newTab);
    if( this.tabToShow >= 1 && this.tabToShow < 2 ){
      this.router.navigateByUrl("/products");
    }
    else if( this.tabToShow >= 2 && this.tabToShow < 3){
      this.router.navigateByUrl("/raws");
    }
    else if( this.tabToShow >= 3 && this.tabToShow < 4){
      this.router.navigateByUrl("/companies");
    }
    else if( this.tabToShow >= 4 && this.tabToShow < 5){
      this.router.navigateByUrl("/sell");
    }
    else if( this.tabToShow >= 5 && this.tabToShow < 6){
      this.router.navigateByUrl("/history");
    }
    else if( this.tabToShow >= 6 && this.tabToShow < 7){
      this.router.navigateByUrl("/bussinesFlow");
    }
    
  }

  updateBussinesFlow(){
    // this.bussinesFlowComponent.updateTab(this.tabToShow);
  }

  updateHistoryComponent(){
    // this.historyComponent.updateTab(this.tabToShow);
  }
}
