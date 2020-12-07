import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {Observable} from 'rxjs';
import {environment} from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class HomeFreelaService {
  urllogin = environment.API + 'Freelancer/Read';

  constructor(private http: HttpClient) {

  }

  buscacadastro(id: any): Observable<any>{
    const log = new HttpParams().set('id', id);
    return this.http.get<any>(this.urllogin, {params: log});
  }




}
