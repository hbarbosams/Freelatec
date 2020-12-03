import {Injectable} from '@angular/core';
import {environment} from '../../../environments/environment';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {ProjetosItem} from '../../../Models/Projeto';

@Injectable({
  providedIn: 'root'
})
export class ContratoService {
  urlListaProjetos = environment.API + 'Projeto/Lista';
  lista: ProjetosItem[] = [];
  constructor(private http: HttpClient) { }

  listaProjetos(): Observable<any>{    // @ts-ignore
    return  this.http.get<any>(this.urlListaProjetos);
  }

  adicionaprojeto(item: ProjetosItem): void {
    this.lista.push(item);
}

  criaNovoContrato(): Observable<any>{    // @ts-ignore
    return  this.http.get<any>(this.urlListaProjetos);
  }





}
