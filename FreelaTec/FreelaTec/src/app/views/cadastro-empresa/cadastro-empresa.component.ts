import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {Router} from '@angular/router';
import {CadastroEmpresaService} from './cadastro-empresa.service';
import {ContratanteModel} from '../../../Models/Contratante';
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
      Nome: [null, [Validators.required, Validators.maxLength(200)]],
      Cnpj: [null, [Validators.required, Validators.maxLength(20)]],
      Login: [null, [Validators.required, Validators.maxLength(30)]],
      Senha: [null, [Validators.required, Validators.maxLength(20)]],
      Email: [null, [Validators.required, Validators.maxLength(100), Validators.email]],
      Telefone: [null, [Validators.required, Validators.maxLength(14)]],
      AreaAtuacao: [null, Validators.required],
      DescrContratante: [null, Validators.required]
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
    if (this.contratante.get('Cnpj')?.value !== null) {
      this.cadastroEmpresaService.CNPJ(this.contratante.get('Cnpj')?.value).subscribe((retorno) => {
        if (retorno !== null) {
          this.snak.open('CNPJ já cadastrado!', 'X', {
            duration: 2000,
            horizontalPosition: 'right',
            verticalPosition: 'top',
          });
          this.contratante.get('Cnpj')?.setValue(null);
        }
      });
    }
  }

  ConfereLogin(): void {
    if (this.contratante.get('Login')?.value !== null) {
      this.cadastroFreelancerService.Login(this.contratante.get('Login')?.value).subscribe((retorno) => {
        if (retorno !== null) {
          this.snak.open('Login já cadastrado!', 'X', {
            duration: 2000,
            horizontalPosition: 'right',
            verticalPosition: 'top',
          });
          this.contratante.get('Login')?.setValue(null);
        }
      });
    }
  }

  ConfereEmail(): void {
    if (this.contratante.get('Email')?.value !== null) {
      this.cadastroFreelancerService.Email(this.contratante.get('Email')?.value).subscribe((retorno) => {
        if (retorno !== null) {
          this.snak.open('Email já cadastrado!', 'X', {
            duration: 2000,
            horizontalPosition: 'right',
            verticalPosition: 'top',
          });
          this.contratante.get('Email')?.setValue(null);
        }
      });
    }
  }
}
