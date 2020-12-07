import { Component, OnInit } from '@angular/core';
import {LoginService} from '../login/login.service';
import {Freelancer} from '../../../Models/Freelancer';
import {HomeFreelaService} from './home-freela.service';
import {Router} from '@angular/router';
import {EditarService} from '../editar/editar.service';

@Component({
  selector: 'app-home-freelancer',
  templateUrl: './home-freelancer.component.html',
  styleUrls: ['./home-freelancer.component.css']
})
export class HomeFreelancerComponent implements OnInit {
  dadosCadastrais = new Freelancer();

  constructor(public loginService: LoginService,
              private serviceFreelancer: HomeFreelaService,
              private router: Router,
              private editarService: EditarService) { }

  ngOnInit(): void {
    this.serviceFreelancer.buscacadastro(this.loginService.freelancer.id).subscribe((resultados) => {
      this.dadosCadastrais = resultados;
      this.loginService.user = resultados.nome;
    });
  }

  vercontratos(): void {
    this.router.navigate(['ContratosLista']);
  }

  editar(): void{
    this.editarService.rota = 'HomeFreelancer';
    this.router.navigate(['Editar']);
  }

}
