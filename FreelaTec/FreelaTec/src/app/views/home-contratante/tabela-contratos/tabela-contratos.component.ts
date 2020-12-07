import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import {MatTable} from '@angular/material/table';
import {TabelaContratosDataSource} from './tabela-contratos-datasource';
import {Contrato} from '../../../../Models/Contrato';
import {ListaContratoService} from '../../lista-contratos/lista-contrato.service';
import {LoginService} from '../../login/login.service';
import {MatSnackBar} from '@angular/material/snack-bar';
import {VerFreelaService} from '../ver-freela/ver-freela.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-tabela-contratos',
  templateUrl: './tabela-contratos.component.html',
  styleUrls: ['./tabela-contratos.component.css']
})
export class TabelaContratosComponent implements AfterViewInit, OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatTable) table: MatTable<Contrato>;
  dataSource: TabelaContratosDataSource;
  contagem: any;
  list = [];
  itens: number;

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['dataContrato', 'prazo', 'total', 'descricao', 'botao', 'lixeira'];

  constructor(private listacontratoServive: ListaContratoService,
              private loginService: LoginService,
              private snak: MatSnackBar,
              private verFreelaService: VerFreelaService,
              private router: Router) {
  }

  ngOnInit() {
    this.listaContratos();
    this.dataSource = new TabelaContratosDataSource();
    this.contagem = this.dataSource.data.length;

  }

  // tslint:disable-next-line:typedef
  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
    this.table.dataSource = this.dataSource;
  }

  listaContratos(): void {
    this.list = [];
    this.listacontratoServive.busca().subscribe((lista) => {
      this.dataSource = new TabelaContratosDataSource();
      // @ts-ignore
      lista.forEach(contrato => {
        if (contrato.contratanteid === this.loginService.login) {
          // @ts-ignore
          this.list.push(contrato);
        }
      });
      this.dataSource.data = this.list;
      this.itens = this.dataSource.data.length;
      this.ngAfterViewInit();
    });
  }

  // tslint:disable-next-line:typedef
  delete(contrato: Contrato) {
    this.listacontratoServive.deletarContrato(contrato).subscribe((lista) => {
      this.snak.open('O Contrato foi Deletado!', 'X', {
        duration: 3000,
        horizontalPosition: 'right',
        verticalPosition: 'top',
      });
      this.listaContratos();

    });
  }

  verFreela(id: number): void{
    this.verFreelaService.id = id;
    this.router.navigate(['VerFreela']);
  }
}
