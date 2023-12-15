import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PaymentRecordDialogComponent } from './payment-record-dialog.component';

describe('PaymentRecordDialogComponent', () => {
  let component: PaymentRecordDialogComponent;
  let fixture: ComponentFixture<PaymentRecordDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PaymentRecordDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PaymentRecordDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
