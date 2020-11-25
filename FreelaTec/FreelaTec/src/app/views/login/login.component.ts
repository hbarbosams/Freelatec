import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {Router} from '@angular/router';
import {HttpClient, HttpParams} from '@angular/common/http';
import {Observable} from 'rxjs';
import {environment} from '../../../environments/environment';
import {LoginService} from './login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
  // @ts-ignore
  formulario: FormGroup;
  urllogin = environment.API + 'Login/Read';

  constructor( private formBuilder: FormBuilder , private router: Router,
               private http: HttpClient, private loginService: LoginService) { }

  ngOnInit(): void {

    this.formulario = this.formBuilder.group({
      Login: [null, Validators.required],
      Senha: [null, Validators.required]
    });
  }


  envia() {
    this.consulta(this.formulario.value).subscribe((dados) => {
      this.loginService.cadastro = dados;
      if (dados.cnpj == null){
        this.router.navigate(['HomeFreelancer']);
      }else {
        this.router.navigate(['HomeContratante']);
      }

    } );
  }


  consulta(dados: string): Observable<any> {
    console.log(this.formulario.get('Login')?.value);
    const parametros = dados ?
      {params: new HttpParams().set('login', this.formulario.get('Login')?.value)
          .set('senha', this.formulario.get('Senha')?.value) } : {};
    return this.http.get<any>(this.urllogin, parametros);
  }

  cadastro(): void{
    this.router.navigate(['Cadastro']);
  }

}
