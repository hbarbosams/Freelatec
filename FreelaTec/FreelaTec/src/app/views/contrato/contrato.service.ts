import {Injectable} from '@angular/core';
import {environment} from '../../../environments/environment';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {Contrato} from '../../../Models/Contrato';
import {Servico} from '../../../Models/servico';

@Injectable({
  providedIn: 'root'
})
export class ContratoService {
  urlListaProjetos = environment.API + 'Projeto/Lista';
  urlCriaContrato = environment.API + 'Contrato/Create';
  urlCriaServico = environment.API + 'Servico/Create';
  lista: Servico[] = [];
  constructor(private http: HttpClient) { }

  listaProjetos(): Observable<any>{    // @ts-ignore
    return  this.http.get<any>(this.urlListaProjetos);
  }

  adicionaprojeto(item: Servico): void {
    this.lista.push(item);
}

  criaNovoContrato(contrato: Contrato): Observable<any>{

    // @ts-ignore
    return  this.http.post<any>(this.urlCriaContrato, contrato);
  }

  mandaProjetos(contrato: number): Observable<any>{
    // tslint:disable-next-line:forin
        for (const index in this.lista){
          this.lista[index].contratonr = contrato;
    }
        return  this.http.post<any>(this.urlCriaServico, this.lista);
  }
}
