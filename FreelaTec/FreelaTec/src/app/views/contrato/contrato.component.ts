import {Component, OnInit} from '@angular/core';
import {ContratoService} from './contrato.service';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {ProjetosItem} from '../../../Models/Projeto';
import {Contrato} from '../../../Models/Contrato';
import {LoginService} from '../login/login.service';
import {Servico} from '../../../Models/servico';
import {MatSnackBar} from '@angular/material/snack-bar';
import {Router} from '@angular/router';

@Component({
  selector: 'app-contrato',
  templateUrl: './contrato.component.html',
  styleUrls: ['./contrato.component.css']
})
export class ContratoComponent implements OnInit {
  item: FormGroup;
  formContrato: FormGroup;
  public ListaProjetos: ProjetosItem[];
  total = 0;
  novoItem: Servico;
  contrato: Contrato = new Contrato();
  constructor(public Contratoservice: ContratoService,
              private fb: FormBuilder, private login: LoginService,
              private snak: MatSnackBar,
              private router: Router) { }

  ngOnInit(): void {
    this.listaProj();
    this.Contratoservice.lista = [];

    this.formContrato = this.fb.group({
      descricao: [null],
      data: [null, [Validators.required]]
    });
    this.item = this.fb.group({
      projeto: [null, [Validators.required]],
      valor: [null, [Validators.required]],
      descricao: [null, [Validators.required]],
    });
  }

  listaProj(): void {
    this.Contratoservice.listaProjetos().subscribe((retorno) => {
      this.ListaProjetos = retorno;
    });
  }

  adiciona(): void {
    this.novoItem =  new Servico();
    this.novoItem.descricaoProjeto = this.item.get('projeto')?.value.descricao;
    this.novoItem.idProjeto = this.item.get('projeto')?.value.idProjeto;
    this.novoItem.valor = this.item.get('valor')?.value;
    this.total += this.item.get('valor')?.value * 1;
    this.novoItem.descricaoServico = this.item.get('descricao')?.value;
    this.Contratoservice.adicionaprojeto(this.novoItem);
    this.snak.open('Projeto adicionado com sucesso!', 'X', {
      duration: 3000,
      horizontalPosition: 'right',
      verticalPosition: 'top',
    });
}
  criaContrato(): void {
    this.contrato.contratanteid = this.login.contratante.id;
    this.contrato.dataContrato = new Date();
    this.contrato.descricao = this.formContrato.get('descricao')?.value;
    this.contrato.prazo = this.formContrato.get('data')?.value;
    this.contrato.total = this.total;
    this.contrato.status = 1;
    this.Contratoservice.criaNovoContrato(this.contrato).subscribe((retorno) => {
      this.Contratoservice.mandaProjetos(retorno.nrContrato).subscribe(() => {
        this.snak.open('O seu contrato foi realzado com sucesso!', 'X', {
          duration: 3000,
          horizontalPosition: 'right',
          verticalPosition: 'top',
        });
        this.router.navigate(['HomeContratante']);
      });
          });
  }

  voltar(): void {
    this.router.navigate(['HomeContratante']);
  }
}

