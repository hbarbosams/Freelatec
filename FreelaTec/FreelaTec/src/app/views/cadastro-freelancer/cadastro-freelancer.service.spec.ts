import { TestBed } from '@angular/core/testing';

import { CadastroFreelancerService } from './cadastro-freelancer.service';

describe('CadastroFreelancerService', () => {
  let service: CadastroFreelancerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CadastroFreelancerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
