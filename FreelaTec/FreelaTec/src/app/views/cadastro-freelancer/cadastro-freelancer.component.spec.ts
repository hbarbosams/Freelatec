import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroFreelancerComponent } from './cadastro-freelancer.component';

describe('CadastroFreelancerComponent', () => {
  let component: CadastroFreelancerComponent;
  let fixture: ComponentFixture<CadastroFreelancerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CadastroFreelancerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CadastroFreelancerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
