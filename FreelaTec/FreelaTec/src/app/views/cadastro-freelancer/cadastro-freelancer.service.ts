import {Injectable} from '@angular/core';
import {Router} from '@angular/router';
import {environment} from '../../../environments/environment';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {ContratanteModel} from '../../../Models/Contratante';

@Injectable({
  providedIn: 'root'
})
export class CadastroFreelancerService {

  urlCreate = environment.API + 'Contratante/Create';
  constructor(private router: Router, private http: HttpClient) { }
  // @ts-ignore
  create(Freelancer: any): Observable<any> {

    return this.http.post<ContratanteModel>(this.urlCreate, Freelancer);
  }
}
