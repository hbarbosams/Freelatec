import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {Router} from '@angular/router';
import {EditarService} from './editar.service';
import {LoginService} from '../login/login.service';
import {Pessoa} from '../../../Models/Pessoa';

@Component({
  selector: 'app-editar',
  templateUrl: './editar.component.html',
  styleUrls: ['./editar.component.css']
})
export class EditarComponent implements OnInit {
  // @ts-ignore
  public pessoa: FormGroup;
  public dados: Pessoa;

  constructor(private fb: FormBuilder,
              private router: Router,
              private editarService: EditarService,
              private login: LoginService) { }

  ngOnInit(): void {

    this.dadosCadastrais();
    this.pessoa = this.fb.group({
      nome: [null, [Validators.required, Validators.maxLength(200)]],
      login: [null, [Validators.required, Validators.maxLength(30)]],
      senha: [null, [Validators.required, Validators.maxLength(20)]],
      email: [null, [Validators.required, Validators.maxLength(100), Validators.email]],
      telefone: [null, [Validators.required, Validators.maxLength(14)]]
    });
  }

  voltar(): void{
    this.router.navigate([this.editarService.rota]);
  }


  dadosCadastrais(): void {
    this.editarService.Dados(this.login.login).subscribe((dados) => {
      this.dados = dados;
      // @ts-ignore
      this.pessoa.get('nome')?.setValue(this.dados.nome);
      this.pessoa.get('login')?.setValue(this.dados.login);
      this.pessoa.get('email')?.setValue(this.dados.email);
      this.pessoa.get('telefone')?.setValue(this.dados.telefone);
    });
}

  salvar(): void{
    this.dados.nome = this.pessoa.get('nome')?.value;
    this.dados.senha = this.pessoa.get('senha')?.value;
    this.dados.email = this.pessoa.get('email')?.value;
    this.dados.telefone = this.pessoa.get('telefone')?.value;
    this.dados.login = this.pessoa.get('login')?.value;
    this.editarService.salvar(this.dados).subscribe(() => {
      this.router.navigate([this.editarService.rota]);
    });
  }

}
