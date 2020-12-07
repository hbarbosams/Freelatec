import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { LoginService } from '../login/login.service';
import { ContratanteModel } from './../../../Models/Contratante';
import { HomeContServiceService } from './home-cont-service.service';
import {EditarService} from '../editar/editar.service';

@Component({
  selector: 'app-home-contratante',
  templateUrl: './home-contratante.component.html',
  styleUrls: ['./home-contratante.component.css']
})
export class HomeContratanteComponent implements OnInit {
  // tslint:disable-next-line: new-parens
  dadosCadastrais = new ContratanteModel;

  constructor(public loginService: LoginService,
              private route: Router,
              private contService: HomeContServiceService,
              private editarService: EditarService) { }

  ngOnInit(): void {

    this.contService.buscacadastro(this.loginService.contratante.id).subscribe((dados) => {
      this.dadosCadastrais = dados;
      this.loginService.user = dados.nome;
    });
  }
  criacontrato(): void{
    this.route.navigate(['Contrato']);
  }

  editar(): void{
    this.editarService.rota = 'HomeContratante';
    this.route.navigate(['Editar']);
  }

}
