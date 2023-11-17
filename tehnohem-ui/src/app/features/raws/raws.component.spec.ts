import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RawsComponent } from './raws.component';

describe('RawsComponent', () => {
  let component: RawsComponent;
  let fixture: ComponentFixture<RawsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RawsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RawsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
