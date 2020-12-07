import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {Observable} from 'rxjs';
import {environment} from '../../../environments/environment';
import {Contrato} from '../../../Models/Contrato';
import {LoginService} from '../login/login.service';

@Injectable({
  providedIn: 'root'
})
export class ListaContratoService {
  urlLista = environment.API + 'Contrato/Lista';
  verContrato = new Contrato();
  urlPegaProjetos = environment.API + 'Servico/ListaServico';
  urlPegacontrato = environment.API + 'Contrato/Update';
  urlPegacontratoFreelancer = environment.API + 'Contrato/ListaFreelancer';
  urlDeletaContrato = environment.API + 'Contrato/Delete';


  constructor(private http: HttpClient, private login: LoginService) { }

  busca(): Observable<any>{
    return  this.http.get<any>(this.urlLista);
  }

  pegaContratosFreelancer(nr: number | undefined): Observable<any>{
    // @ts-ignore
    const param = new HttpParams().set('id', nr);
    // @ts-ignore
    return  this.http.get<any>(this.urlPegacontratoFreelancer, {params: param});
  }

  verServicos(nr: number | undefined): Observable<any>{
    // @ts-ignore
    const param = new HttpParams().set('nrContrato', nr);
    // @ts-ignore
    return  this.http.get<any>(this.urlPegaProjetos, {params: param});
  }

  pegaContrato(): Observable<any> {
    this.verContrato.status = 2;
    this.verContrato.dataInicial = new Date();
    this.verContrato.freelancerid = this.login.freelancer.id;
    return  this.http.post<any>(this.urlPegacontrato, this.verContrato);
  }

  finalizaContrato(contrato: Contrato): Observable<any> {
    return  this.http.post<any>(this.urlPegacontrato, contrato);
  }

  deletarContrato(contrato: Contrato): Observable<any> {

    // @ts-ignore
    return  this.http.post<any>(this.urlDeletaContrato, contrato);
  }
}
