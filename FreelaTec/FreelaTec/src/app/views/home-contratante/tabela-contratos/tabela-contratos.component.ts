import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable } from '@angular/material/table';
import { TabelaContratosDataSource, TabelaContratosItem } from './tabela-contratos-datasource';

@Component({
  selector: 'app-tabela-contratos',
  templateUrl: './tabela-contratos.component.html',
  styleUrls: ['./tabela-contratos.component.css']
})
export class TabelaContratosComponent implements AfterViewInit, OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatTable) table: MatTable<TabelaContratosItem>;
  dataSource: TabelaContratosDataSource;
  contagem: any;

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['id', 'name'];

  ngOnInit() {
    this.dataSource = new TabelaContratosDataSource();
    this.contagem = this.dataSource.data.length;
  }

  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
    this.table.dataSource = this.dataSource;
  }
}
