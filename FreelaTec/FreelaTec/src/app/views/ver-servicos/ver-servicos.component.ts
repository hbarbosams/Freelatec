import {Component, OnInit} from '@angular/core';
import {ListaContratoService} from '../lista-contratos/lista-contrato.service';
import {Servico} from '../../../Models/servico';
import {Router} from '@angular/router';
import {MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: 'app-ver-servicos',
  templateUrl: './ver-servicos.component.html',
  styleUrls: ['./ver-servicos.component.css']
})
export class VerServicosComponent implements OnInit {
  listProjetos: Servico[];

  constructor(public listaContratos: ListaContratoService,
              private router: Router, private snak: MatSnackBar) { }

  ngOnInit(): void {
    this.listaContratos.verServicos(this.listaContratos.verContrato.nrContrato).subscribe((lista) => {
      this.listProjetos = lista;
    });
  }

  pegarContrato(): void {
    this.listaContratos.pegaContrato().subscribe( () => {
      this.router.navigate(['HomeFreelancer']);
      this.snak.open('Contrato aceito com sucesso, faça um café Coder!', 'X', {
        duration: 3000,
        horizontalPosition: 'right',
        verticalPosition: 'top',
      });
    });
  }

  voltar(): void {
    this.router.navigate(['ContratosLista']);
  }

}
