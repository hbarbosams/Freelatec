import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeFreelancerComponent } from './home-freelancer.component';

describe('HomeFreelancerComponent', () => {
  let component: HomeFreelancerComponent;
  let fixture: ComponentFixture<HomeFreelancerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HomeFreelancerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeFreelancerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
