import { TestBed } from '@angular/core/testing';

import { HomeContServiceService } from './home-cont-service.service';

describe('HomeContServiceService', () => {
  let service: HomeContServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HomeContServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
