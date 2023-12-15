import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddNewRawComponent } from './add-new-raw.component';

describe('AddNewRawComponent', () => {
  let component: AddNewRawComponent;
  let fixture: ComponentFixture<AddNewRawComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddNewRawComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddNewRawComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
