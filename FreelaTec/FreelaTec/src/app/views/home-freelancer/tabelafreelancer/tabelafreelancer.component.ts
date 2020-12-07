import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import {MatTable} from '@angular/material/table';
import {TabelafreelancerDataSource} from './tabelafreelancer-datasource';
import {Contrato} from '../../../../Models/Contrato';
import {ListaContratoService} from '../../lista-contratos/lista-contrato.service';
import {LoginService} from '../../login/login.service';

@Component({
  selector: 'app-tabelafreelancer',
  templateUrl: './tabelafreelancer.component.html',
  styleUrls: ['./tabelafreelancer.component.css']
})
export class TabelafreelancerComponent implements AfterViewInit, OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatTable) table: MatTable<Contrato>;
  dataSource: TabelafreelancerDataSource;
  contagem: any;
  list = [];
  itens: number;


  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['dataContrato', 'prazo', 'total', 'descricao'];

  constructor(private listacontratoServive: ListaContratoService, private loginService: LoginService) {
  }

  ngOnInit() {
    this.listaContratos();
    this.dataSource = new TabelafreelancerDataSource();
  }

  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
    this.table.dataSource = this.dataSource;
  }

  listaContratos(): void  {
    this.listacontratoServive.pegaContratosFreelancer(this.loginService.login).subscribe((lista) => {
      this.dataSource = new TabelafreelancerDataSource();
      this.dataSource.data = lista;
      this.itens = this.dataSource.data.length;
      this.ngAfterViewInit();
    });
  }

}
