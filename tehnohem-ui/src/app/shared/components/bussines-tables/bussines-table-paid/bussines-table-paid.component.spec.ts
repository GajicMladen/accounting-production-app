import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BussinesTablePaidComponent } from './bussines-table-paid.component';

describe('BussinesTablePaidComponent', () => {
  let component: BussinesTablePaidComponent;
  let fixture: ComponentFixture<BussinesTablePaidComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BussinesTablePaidComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BussinesTablePaidComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
