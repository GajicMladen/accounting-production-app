import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SellRawTableComponent } from './sell-raw-table.component';

describe('SellRawTableComponent', () => {
  let component: SellRawTableComponent;
  let fixture: ComponentFixture<SellRawTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SellRawTableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SellRawTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
