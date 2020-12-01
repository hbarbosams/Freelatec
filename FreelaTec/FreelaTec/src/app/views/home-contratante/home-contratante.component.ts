import {Component, OnInit} from '@angular/core';
import {LoginService} from '../login/login.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-home-contratante',
  templateUrl: './home-contratante.component.html',
  styleUrls: ['./home-contratante.component.css']
})
export class HomeContratanteComponent implements OnInit {

  constructor(public loginService: LoginService,
              private route: Router) { }

  ngOnInit(): void {

  }

  criacontrato(): void{
    this.route.navigate(['Contrato']);
  }



}
