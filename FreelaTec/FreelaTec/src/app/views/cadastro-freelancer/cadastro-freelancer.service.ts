import {Injectable} from '@angular/core';
import {Router} from '@angular/router';
import {environment} from '../../../environments/environment';
import {HttpClient, HttpParams} from '@angular/common/http';
import {Observable} from 'rxjs';
import {ContratanteModel} from '../../../Models/Contratante';

@Injectable({
  providedIn: 'root'
})
export class CadastroFreelancerService {

  urlCreate = environment.API + 'Freelancer/Create';
  urlCPF = environment.API + 'Freelancer/CPF';
  urlLogin = environment.API + 'Freelancer/Login';
  urlEmail = environment.API + 'Freelancer/Email';
  urlRa = environment.API + 'Freelancer/Ra';
  constructor(private router: Router, private http: HttpClient) { }
  // @ts-ignore
  create(Freelancer: any): Observable<any> {

    return this.http.post<ContratanteModel>(this.urlCreate, Freelancer);
  }
  CPF(cpf: string): Observable<any>{
    const cp = new HttpParams().set('cpf', cpf);
    // @ts-ignore
    return  this.http.get<any>(this.urlCPF, {params: cp});
  }

  Login(login: string): Observable<any>{
    const logs = new HttpParams().set('Login', login);
    // @ts-ignore
    return  this.http.get<any>(this.urlLogin, {params: logs});
  }

  Email(email: string): Observable<any>{
    const ema = new HttpParams().set('Email', email);
    // @ts-ignore
    return  this.http.get<any>(this.urlEmail, {params: ema});
  }

  Ra(Ra: string): Observable<any>{
    const raaluno = new HttpParams().set('ra', Ra);
    // @ts-ignore
    return  this.http.get<any>(this.urlRa, {params: raaluno});
  }
}
