import { Component, OnInit } from '@angular/core';
import {LoginService} from '../login/login.service';

@Component({
  selector: 'app-home-contratante',
  templateUrl: './home-contratante.component.html',
  styleUrls: ['./home-contratante.component.css']
})
export class HomeContratanteComponent implements OnInit {

  constructor(public loginService: LoginService) { }

  ngOnInit(): void {

  }



}
