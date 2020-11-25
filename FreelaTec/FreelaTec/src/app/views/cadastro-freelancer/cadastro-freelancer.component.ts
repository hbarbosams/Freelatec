import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {Router} from '@angular/router';
import {CadastroFreelancerService} from './cadastro-freelancer.service';

@Component({
  selector: 'app-cadastro-freelancer',
  templateUrl: './cadastro-freelancer.component.html',
  styleUrls: ['./cadastro-freelancer.component.css']
})
export class CadastroFreelancerComponent implements OnInit {

  constructor(private fb: FormBuilder, private router: Router,
              private cadastroFreelancerService: CadastroFreelancerService ) { }
  // @ts-ignore
  Freelancer: FormGroup;
  ngOnInit(): void {
    this.Freelancer = this.fb.group({
      Nome: [null, Validators.required],
      Cpf: [null, Validators.required],
      Login: [null, Validators.required],
      Senha: [null, Validators.required],
      Email: [null, Validators.required],
      Telefone: [null, Validators.required],
      Ra: [null, Validators.required],
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

}
