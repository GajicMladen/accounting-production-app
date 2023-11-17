import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BussinesFlowComponent } from './bussines-flow.component';

describe('BussinesFlowComponent', () => {
  let component: BussinesFlowComponent;
  let fixture: ComponentFixture<BussinesFlowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BussinesFlowComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BussinesFlowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
