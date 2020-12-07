import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {Router} from '@angular/router';
import {CadastroEmpresaService} from './cadastro-empresa.service';
import {MatSnackBar} from '@angular/material/snack-bar';
import {CadastroFreelancerService} from '../cadastro-freelancer/cadastro-freelancer.service';

@Component({
  selector: 'app-cadastro-empresa',
  templateUrl: './cadastro-empresa.component.html',
  styleUrls: ['./cadastro-empresa.component.css']
})
export class CadastroEmpresaComponent implements OnInit {
  constructor(private fb: FormBuilder, private router: Router,
              private cadastroEmpresaService: CadastroEmpresaService,
              private snak: MatSnackBar,
              private cadastroFreelancerService: CadastroFreelancerService) { }
  // @ts-ignore
  contratante: FormGroup;
  ngOnInit(): void {
    this.contratante = this.fb.group({
      nome: [null, [Validators.required, Validators.maxLength(200)]],
      cnpj: [null, [Validators.required, Validators.maxLength(20)]],
      login: [null, [Validators.required, Validators.maxLength(30)]],
      senha: [null, [Validators.required, Validators.maxLength(20)]],
      email: [null, [Validators.required, Validators.maxLength(100), Validators.email]],
      telefone: [null, [Validators.required, Validators.maxLength(14)]],
      areaAtuacao: [null, Validators.required],
      descrContratante: [null, Validators.required]
    });
  }

  cadastrar(): void{

    this.cadastroEmpresaService.create(this.contratante.value).subscribe((retorno) => {
      console.log(retorno);
      this.router.navigate(['']);
    });
  }
  login(): void{
    this.router.navigate(['']);
  }

  ConfereCNPJ(): void {
    if (this.contratante.get('cnpj')?.value !== null) {
      this.cadastroEmpresaService.CNPJ(this.contratante.get('cnpj')?.value).subscribe((retorno) => {
        if (retorno !== null) {
          this.snak.open('CNPJ já cadastrado!', 'X', {
            duration: 2000,
            horizontalPosition: 'right',
            verticalPosition: 'top',
          });
          this.contratante.get('cnpj')?.setValue(null);
        }
      });
    }
  }

  ConfereLogin(): void {
    if (this.contratante.get('login')?.value !== null) {
      this.cadastroFreelancerService.Login(this.contratante.get('login')?.value).subscribe((retorno) => {
        if (retorno !== null) {
          this.snak.open('Login já cadastrado!', 'X', {
            duration: 2000,
            horizontalPosition: 'right',
            verticalPosition: 'top',
          });
          this.contratante.get('login')?.setValue(null);
        }
      });
    }
  }

  ConfereEmail(): void {
    if (this.contratante.get('email')?.value !== null) {
      this.cadastroFreelancerService.Email(this.contratante.get('email')?.value).subscribe((retorno) => {
        if (retorno !== null) {
          this.snak.open('Email já cadastrado!', 'X', {
            duration: 2000,
            horizontalPosition: 'right',
            verticalPosition: 'top',
          });
          this.contratante.get('email')?.setValue(null);
        }
      });
    }
  }
}
