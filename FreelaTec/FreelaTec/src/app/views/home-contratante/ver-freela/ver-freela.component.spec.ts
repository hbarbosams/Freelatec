import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VerFreelaComponent } from './ver-freela.component';

describe('VerFreelaComponent', () => {
  let component: VerFreelaComponent;
  let fixture: ComponentFixture<VerFreelaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VerFreelaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VerFreelaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
