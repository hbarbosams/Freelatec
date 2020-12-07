import { Injectable } from '@angular/core';
import {Observable} from 'rxjs';
import {HttpClient, HttpParams} from '@angular/common/http';
import {environment} from '../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class VerFreelaService {
  id: number;
  urlDeletaContrato = environment.API + 'Freelancer/Read';

  constructor(private http: HttpClient) { }



  pegaFreelancer(): Observable<any>{
    console.log(this.id);
    // @ts-ignore
    const param = new HttpParams().set('id', this.id);
    // @ts-ignore
    return  this.http.get<any>(this.urlDeletaContrato, {params: param});
  }
}
