import {Injectable} from '@angular/core';
import {Router} from '@angular/router';
import {HttpClient, HttpParams} from '@angular/common/http';
import {Observable} from 'rxjs';
import {ContratanteModel} from '../../../Models/Contratante';
import {environment} from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CadastroEmpresaService {
  urlCreate = environment.API + 'Contratante/Create';
  constructor(private router: Router, private http: HttpClient) { }
  // @ts-ignore
  create(contratante: any): Observable<any> {

    return this.http.post<ContratanteModel>(this.urlCreate, contratante);
  }
}
