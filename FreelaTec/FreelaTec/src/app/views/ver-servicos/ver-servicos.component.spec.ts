import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VerServicosComponent } from './ver-servicos.component';

describe('VerServicosComponent', () => {
  let component: VerServicosComponent;
  let fixture: ComponentFixture<VerServicosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VerServicosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VerServicosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
