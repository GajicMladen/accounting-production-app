import { TestBed } from '@angular/core/testing';

import { RawService } from './raw.service';

describe('RawService', () => {
  let service: RawService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RawService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
