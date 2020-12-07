import {Injectable} from '@angular/core';
import {Router} from '@angular/router';
import {HttpClient, HttpParams} from '@angular/common/http';
import {Observable} from 'rxjs';
import {ContratanteModel} from '../../../Models/Contratante';
import {environment} from '../../../environments/environment';
import {Freelancer} from '../../../Models/Freelancer';

@Injectable({
  providedIn: 'root'
})
export class CadastroEmpresaService {
  urlCreate = environment.API + 'Contratante/Create';
  urlCNPJ = environment.API + 'Contratante/CNPJ';
  dadosCadastrais = new Freelancer();
  constructor(private router: Router, private http: HttpClient) { }
  // @ts-ignore
  create(contratante: any): Observable<any> {

    return this.http.post<ContratanteModel>(this.urlCreate, contratante);
  }

  CNPJ(cnpj: string): Observable<any>{
    const cn = new HttpParams().set('cnpj', cnpj);
    // @ts-ignore
    return  this.http.get<any>(this.urlCNPJ, {params: cn});
  }
}
