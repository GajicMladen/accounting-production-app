import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InternalDocumentsDialogComponent } from './internal-documents-dialog.component';

describe('InternalDocumentsDialogComponent', () => {
  let component: InternalDocumentsDialogComponent;
  let fixture: ComponentFixture<InternalDocumentsDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InternalDocumentsDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InternalDocumentsDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
