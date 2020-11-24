import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeContratanteComponent } from './home-contratante.component';

describe('HomeContratanteComponent', () => {
  let component: HomeContratanteComponent;
  let fixture: ComponentFixture<HomeContratanteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HomeContratanteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeContratanteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
