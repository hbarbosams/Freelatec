import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import validate = WebAssembly.validate;

@Component({
  selector: 'app-cadastro-empresa',
  templateUrl: './cadastro-empresa.component.html',
  styleUrls: ['./cadastro-empresa.component.css']
})
export class CadastroEmpresaComponent implements OnInit {


  constructor(private fb: FormBuilder) { }
  // @ts-ignore
  contratante: FormGroup;
  ngOnInit(): void {
    this.contratante = this.fb.group({
      Nome: [null, Validators.required, Validators.maxLength(200)],
      Cnpj: [null, Validators.required, Validators.minLength(14)],
      Login: [null, Validators.required, Validators.maxLength(30), Validators.minLength(6)],
      Senha: [null, Validators.required, Validators.maxLength(20), Validators.minLength(6)],
      Email: [null, Validators.required, Validators.maxLength(200), Validators.email],
      Telefone: [null, Validators.required, Validators.maxLength(14)],
      Area: [null, Validators.required, Validators.maxLength(100)],
      Desc: [null, Validators.required]

    });
  }

  cadastrar (): void{
    console.log(this.contratante.value);
  }

}
