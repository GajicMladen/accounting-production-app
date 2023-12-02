import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PaymentItemTableComponent } from './payment-item-table.component';

describe('PaymentItemTableComponent', () => {
  let component: PaymentItemTableComponent;
  let fixture: ComponentFixture<PaymentItemTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PaymentItemTableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PaymentItemTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
