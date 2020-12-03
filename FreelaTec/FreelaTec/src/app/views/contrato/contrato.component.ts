import {Component, EventEmitter, OnInit} from '@angular/core';
import {ContratoService} from './contrato.service';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {ProjetosItem} from '../../../Models/Projeto';
import {Contrato} from '../../../Models/Contrato';
import {LoginService} from '../login/login.service';

@Component({
  selector: 'app-contrato',
  templateUrl: './contrato.component.html',
  styleUrls: ['./contrato.component.css']
})
export class ContratoComponent implements OnInit {
  evento = new EventEmitter();
  item: FormGroup;
  public ListaProjetos: any;
  novoItem: ProjetosItem;
  contrato: Contrato = new Contrato();
  constructor(public Contratoservice: ContratoService, private fb: FormBuilder, private login: LoginService) { }

  ngOnInit(): void {
    this.listaProj();

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
    this.novoItem =  new ProjetosItem();
    this.novoItem.descricaoProjeto = this.item.get('projeto')?.value.descricao;
    this.novoItem.idProjeto = this.item.get('projeto')?.value.idProjeto;
    this.novoItem.valor = this.item.get('valor')?.value;
    this.novoItem.descricaoServico = this.item.get('descricao')?.value;
    this.Contratoservice.adicionaprojeto(this.novoItem);
    this.evento.emit();
}
  criaContrato(): void {
    this.contrato.contratante_id = this.login.contratante.id;
    this.Contratoservice.criaNovoContrato().subscribe((retorno) => {
      this.ListaProjetos = retorno;
    });
  }
}
