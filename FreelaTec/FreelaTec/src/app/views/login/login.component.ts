import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {Router} from '@angular/router';
import {HttpClient, HttpParams} from '@angular/common/http';
import {Observable} from 'rxjs';
import {environment} from '../../../environments/environment';
import {LoginService} from './login.service';
import {MatSnackBar} from '@angular/material/snack-bar';

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
               private http: HttpClient, private loginService: LoginService,
               private  snak: MatSnackBar) { }

  ngOnInit(): void {

    this.formulario = this.formBuilder.group({
      login: [null, Validators.required],
      senha: [null, Validators.required]
    });
  }


  envia() {
    this.consulta().subscribe((dados) => {
      if ( dados == null ){
        this.snak.open('O seu login falhou, tente novamente!', 'X', {
          duration: 2000,
          horizontalPosition: 'right',
          verticalPosition: 'top',
        });
      } else {
        if (dados.cnpj == null){
          this.loginService.freelancer = dados;
          this.loginService.login = dados.id;
          this.loginService.autentica = true;
          this.loginService.freela = true;
          this.loginService.user = dados.nome;
          this.router.navigate(['HomeFreelancer']);
        } else {
          if (dados.cpf == null) {
            this.loginService.contratante = dados;
            this.loginService.login = dados.id;
            this.loginService.autentica = true;
            this.loginService.contrat = true;
            this.router.navigate(['HomeContratante']);
          }
        }
      }
    });
  }
  consulta(): Observable<any> {
    return this.http.post<any>(this.urllogin, this.formulario.value);
  }

  cadastro(): void{
    this.router.navigate(['Cadastro']);
  }

}
