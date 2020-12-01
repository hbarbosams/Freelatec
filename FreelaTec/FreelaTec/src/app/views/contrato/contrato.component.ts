import { Component, OnInit } from '@angular/core';
import {ContratoService} from './contrato.service';

@Component({
  selector: 'app-contrato',
  templateUrl: './contrato.component.html',
  styleUrls: ['./contrato.component.css']
})
export class ContratoComponent implements OnInit {
  ListaProjetos: any;

  constructor(private Contratoservice: ContratoService) { }

  ngOnInit(): void {
    this.listaProj();
  }

  listaProj(): void {
    this.Contratoservice.listaProjetos().subscribe((retorno) => {
      this.ListaProjetos = retorno;
    });
  }

  adicionaProjeto(): void {
}

}
