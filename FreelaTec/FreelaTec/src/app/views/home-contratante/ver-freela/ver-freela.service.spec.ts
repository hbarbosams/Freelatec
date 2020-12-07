import { TestBed } from '@angular/core/testing';

import { VerFreelaService } from './ver-freela.service';

describe('VerFreelaService', () => {
  let service: VerFreelaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VerFreelaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
