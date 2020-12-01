import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent implements OnInit {
  public projeto: FormGroup;

  constructor(private router: Router, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.projeto = this.fb.group({
      Nome: [null, [Validators.required, Validators.maxLength(200)]],
    });


  }

  empresa(): void{
    this.router.navigate(['CadastroEmpresa']);
  }

  freelancer(): void{
    this.router.navigate(['CadastroFreelancer']);
  }

  login(): void{
    this.router.navigate(['']);
  }


}
