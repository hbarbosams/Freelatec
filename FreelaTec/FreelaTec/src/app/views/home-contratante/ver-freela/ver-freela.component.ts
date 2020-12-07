import { Component, OnInit } from '@angular/core';
import {VerFreelaService} from './ver-freela.service';
import {Router} from '@angular/router';
import {Freelancer} from '../../../../Models/Freelancer';

@Component({
  selector: 'app-ver-freela',
  templateUrl: './ver-freela.component.html',
  styleUrls: ['./ver-freela.component.css']
})
export class VerFreelaComponent implements OnInit {
  freelancer = new Freelancer();

  constructor(private verFreela: VerFreelaService, private router: Router) { }

  ngOnInit(): void {
    this.pegadados();

  }

  pegadados(): void{
    this.verFreela.pegaFreelancer().subscribe((dados) => {
      this.freelancer = dados;
    });
  }

  voltar(): void{
    this.router.navigate(['HomeContratante']);
  }
}
