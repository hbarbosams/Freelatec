import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable } from '@angular/material/table';
import { ProjetosDataSource } from './projetos-datasource';
import {ProjetosItem} from '../../../../Models/Projeto';
import {ContratoService} from '../contrato.service';


@Component({
  selector: 'app-projetos',
  templateUrl: './projetos.component.html',
  styleUrls: ['./projetos.component.css']
})
export class ProjetosComponent implements AfterViewInit, OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatTable) table: MatTable<ProjetosItem>;
  dataSource: ProjetosDataSource;
  contagem: number;

  constructor(public contratoService: ContratoService) {
  }

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['descricaoProjeto', 'descricaoServico',  'valor'];

  ngOnInit() {
    // @ts-ignore
    this.dataSource = new ProjetosDataSource();
    this.contagem = this.dataSource.data.length;

  }
  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
    this.table.dataSource = this.dataSource;
  }

  atualizar(): void{
    // @ts-ignore
    this.dataSource = new ProjetosDataSource();

    this.ngAfterViewInit();
  }
}
