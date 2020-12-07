import { TestBed } from '@angular/core/testing';

import { ListaContratoService } from './lista-contrato.service';

describe('ListaContratoService', () => {
  let service: ListaContratoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ListaContratoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
