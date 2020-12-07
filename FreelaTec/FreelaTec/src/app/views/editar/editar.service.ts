import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {Observable} from 'rxjs';
import {environment} from '../../../environments/environment';
import {Pessoa} from '../../../Models/Pessoa';

@Injectable({
  providedIn: 'root'
})
export class EditarService {

  rota: string;
  urlPegaDados = environment.API + 'Pessoa/Read';
  urlSalvaDados = environment.API + 'Pessoa/Update';

  constructor(private http: HttpClient) { }


  Dados(id: number): Observable<any>{
    // @ts-ignore
    const dados = new HttpParams().set('id', id);
    // @ts-ignore
    return  this.http.get<any>(this.urlPegaDados, {params: dados});
  }

  salvar(pessoa: Pessoa): Observable<any>{
    return  this.http.post<any>(this.urlSalvaDados, pessoa);
  }



}
