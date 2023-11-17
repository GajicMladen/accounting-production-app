import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SimpleCountTableComponent } from '../shared/components/simple-count-table/simple-count-table.component';

describe('SimpleCountTableComponent', () => {
  let component: SimpleCountTableComponent;
  let fixture: ComponentFixture<SimpleCountTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SimpleCountTableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SimpleCountTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
