import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompanyPickerComponent } from './company-picker.component';

describe('CompanyPickerComponent', () => {
  let component: CompanyPickerComponent;
  let fixture: ComponentFixture<CompanyPickerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CompanyPickerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CompanyPickerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
