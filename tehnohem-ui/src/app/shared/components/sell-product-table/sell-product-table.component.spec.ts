import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SellProductTableComponent } from './sell-product-table.component';

describe('SellProductTableComponent', () => {
  let component: SellProductTableComponent;
  let fixture: ComponentFixture<SellProductTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SellProductTableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SellProductTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
