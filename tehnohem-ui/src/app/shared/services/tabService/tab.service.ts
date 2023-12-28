import { Injectable } from '@angular/core';
import { BehaviorSubject, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TabService {

  private tabToShow : Subject<number> = new BehaviorSubject<number>(5.4);

  constructor() { }

  getTab$(){
    return this.tabToShow.asObservable();
  }

  changeTab(newTab:number){
    this.tabToShow.next(newTab);
  }
}
