import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class HomeContServiceService {

  urllogin = environment.API + 'Contratante/Read';

  constructor(private http: HttpClient) { }

  buscacadastro(id: any): Observable<any>{
    const log = new HttpParams().set('id', id);
    return this.http.get<any>(this.urllogin, {params: log});
  }



}
