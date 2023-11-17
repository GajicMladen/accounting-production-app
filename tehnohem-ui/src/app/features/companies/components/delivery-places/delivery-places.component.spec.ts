import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeliveryPlacesComponent } from './delivery-places.component';

describe('DeliveryPlacesComponent', () => {
  let component: DeliveryPlacesComponent;
  let fixture: ComponentFixture<DeliveryPlacesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeliveryPlacesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeliveryPlacesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
