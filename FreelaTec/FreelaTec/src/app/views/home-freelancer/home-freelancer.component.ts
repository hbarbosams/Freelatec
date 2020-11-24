import { Component, OnInit } from '@angular/core';
import {LoginService} from '../login/login.service';

@Component({
  selector: 'app-home-freelancer',
  templateUrl: './home-freelancer.component.html',
  styleUrls: ['./home-freelancer.component.css']
})
export class HomeFreelancerComponent implements OnInit {

  constructor(public loginService: LoginService) { }

  ngOnInit(): void {
  }

}
