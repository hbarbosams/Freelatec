import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import {MatTable} from '@angular/material/table';
import {ListaContratosDataSource} from './lista-contratos-datasource';
import {Contrato} from '../../../Models/Contrato';
import {ListaContratoService} from './lista-contrato.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-lista-contratos',
  templateUrl: './lista-contratos.component.html',
  styleUrls: ['./lista-contratos.component.css']
})
export class ListaContratosComponent implements AfterViewInit, OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatTable) table: MatTable<Contrato>;
  dataSource: ListaContratosDataSource;
  itens: number;
  list = [];

  constructor(private listacontratoServive: ListaContratoService,
              private router: Router) {
  }

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['descricao', 'total', 'prazo', 'acao'];

  ngOnInit() {
    this.dataSource = new ListaContratosDataSource();
    this.listaContratos();

  }

  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
    this.table.dataSource = this.dataSource;
  }

  listaContratos(): void  {
    this.listacontratoServive.busca().subscribe((lista) => {
      this.dataSource = new ListaContratosDataSource();
      // @ts-ignore
      lista.forEach(contrato => {
        if (contrato.status === 1){
         // @ts-ignore
          this.list.push(contrato);
        }
      });
      this.dataSource.data = this.list;
      this.itens = this.dataSource.data.length;
      this.ngAfterViewInit();
    });
  }

  verServicos(item: Contrato ): void {
    this.listacontratoServive.verContrato = item;
    this.router.navigate(['VerContrato']);
  }




}
