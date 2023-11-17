import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BussinesTableExpenseComponent } from './bussines-table-expense.component';

describe('BussinesTableExpenseComponent', () => {
  let component: BussinesTableExpenseComponent;
  let fixture: ComponentFixture<BussinesTableExpenseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BussinesTableExpenseComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BussinesTableExpenseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
