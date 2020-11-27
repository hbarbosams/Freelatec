import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {Router} from '@angular/router';
import {CadastroFreelancerService} from './cadastro-freelancer.service';
import {MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: 'app-cadastro-freelancer',
  templateUrl: './cadastro-freelancer.component.html',
  styleUrls: ['./cadastro-freelancer.component.css']
})
export class CadastroFreelancerComponent implements OnInit {

  constructor(private fb: FormBuilder, private router: Router,
              private cadastroFreelancerService: CadastroFreelancerService,
              private snak: MatSnackBar) { }
  // @ts-ignore
  Freelancer: FormGroup;
  ngOnInit(): void {
    this.Freelancer = this.fb.group({
      Nome: [null, [Validators.required, Validators.maxLength(200)]],
      Cpf:  [null, [Validators.required, Validators.maxLength(20)]],
      Login: [null, [Validators.required, Validators.maxLength(30)]],
      Senha: [null, [Validators.required, Validators.maxLength(20)]],
      Email: [null, [Validators.required, Validators.maxLength(100), Validators.email]],
      Telefone: [null, [Validators.required, Validators.maxLength(14)]],
      Ra: [null, [Validators.required, Validators.maxLength(30)]],
      Experiencia: [null, Validators.required]
    });
  }

  cadastrar(): void{

    this.cadastroFreelancerService.create(this.Freelancer.value).subscribe((retorno) => {
      console.log(retorno);
      this.router.navigate(['']);
    });
  }
  login(): void{
    this.router.navigate(['']);
  }


  ConfereCPF(): void {
    if (this.Freelancer.get('Cpf')?.value !== null) {
      this.cadastroFreelancerService.CPF(this.Freelancer.get('Cpf')?.value).subscribe((retorno) => {
        if (retorno !== null) {
          this.snak.open('CPF já cadastrado!', 'X', {
            duration: 2000,
            horizontalPosition: 'right',
            verticalPosition: 'top',
          });
          this.Freelancer.get('Cpf')?.setValue(null);
        }
      });
    }
  }

  ConfereLogin(): void {
    if (this.Freelancer.get('Login')?.value !== null) {
      this.cadastroFreelancerService.Login(this.Freelancer.get('Login')?.value).subscribe((retorno) => {
        if (retorno !== null) {
          this.snak.open('Login já cadastrado!', 'X', {
            duration: 2000,
            horizontalPosition: 'right',
            verticalPosition: 'top',
          });
          this.Freelancer.get('Login')?.setValue(null);
        }
      });
    }
  }

  ConfereEmail(): void {
    if (this.Freelancer.get('Email')?.value !== null) {
      this.cadastroFreelancerService.Email(this.Freelancer.get('Email')?.value).subscribe((retorno) => {
        if (retorno !== null) {
          this.snak.open('Email já cadastrado!', 'X', {
            duration: 2000,
            horizontalPosition: 'right',
            verticalPosition: 'top',
          });
          this.Freelancer.get('Email')?.setValue(null);
        }
      });
    }
  }

  ConfereRa(): void {
    if (this.Freelancer.get('Ra')?.value !== null) {
      this.cadastroFreelancerService.Ra(this.Freelancer.get('Ra')?.value).subscribe((retorno) => {
        if (retorno !== null) {
          this.snak.open('Ra já cadastrado!', 'X', {
            duration: 2000,
            horizontalPosition: 'right',
            verticalPosition: 'top',
          });
          this.Freelancer.get('Ra')?.setValue(null);
        }
      });
    }
  }


}
