import { TestBed } from '@angular/core/testing';

import { HomeFreelaService } from './home-freela.service';

describe('HomeFreelaService', () => {
  let service: HomeFreelaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HomeFreelaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
