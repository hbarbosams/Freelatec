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
      nome: [null, [Validators.required, Validators.maxLength(200)]],
      cpf:  [null, [Validators.required, Validators.maxLength(20)]],
      login: [null, [Validators.required, Validators.maxLength(30)]],
      senha: [null, [Validators.required, Validators.maxLength(20)]],
      email: [null, [Validators.required, Validators.maxLength(100), Validators.email]],
      telefone: [null, [Validators.required, Validators.maxLength(14)]],
      ra: [null, [Validators.required, Validators.maxLength(30)]],
      experiencia: [null, Validators.required]
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
    if (this.Freelancer.get('cpf')?.value !== null) {
      this.cadastroFreelancerService.CPF(this.Freelancer.get('cpf')?.value).subscribe((retorno) => {
        if (retorno !== null) {
          this.snak.open('CPF já cadastrado!', 'X', {
            duration: 2000,
            horizontalPosition: 'right',
            verticalPosition: 'top',
          });
          this.Freelancer.get('cpf')?.setValue(null);
        }
      });
    }
  }

  ConfereLogin(): void {
    if (this.Freelancer.get('login')?.value !== null) {
      this.cadastroFreelancerService.Login(this.Freelancer.get('login')?.value).subscribe((retorno) => {
        if (retorno !== null) {
          this.snak.open('Login já cadastrado!', 'X', {
            duration: 2000,
            horizontalPosition: 'right',
            verticalPosition: 'top',
          });
          this.Freelancer.get('login')?.setValue(null);
        }
      });
    }
  }

  ConfereEmail(): void {
    if (this.Freelancer.get('email')?.value !== null) {
      this.cadastroFreelancerService.Email(this.Freelancer.get('email')?.value).subscribe((retorno) => {
        if (retorno !== null) {
          this.snak.open('Email já cadastrado!', 'X', {
            duration: 2000,
            horizontalPosition: 'right',
            verticalPosition: 'top',
          });
          this.Freelancer.get('email')?.setValue(null);
        }
      });
    }
  }

  ConfereRa(): void {
    if (this.Freelancer.get('ra')?.value !== null) {
      this.cadastroFreelancerService.Ra(this.Freelancer.get('ra')?.value).subscribe((retorno) => {
        if (retorno !== null) {
          this.snak.open('Ra já cadastrado!', 'X', {
            duration: 2000,
            horizontalPosition: 'right',
            verticalPosition: 'top',
          });
          this.Freelancer.get('ra')?.setValue(null);
        }
      });
    }
  }


}
