import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {Router} from '@angular/router';
import {CadastroEmpresaService} from './cadastro-empresa.service';
import {ContratanteModel} from '../../../Models/Contratante';

@Component({
  selector: 'app-cadastro-empresa',
  templateUrl: './cadastro-empresa.component.html',
  styleUrls: ['./cadastro-empresa.component.css']
})
export class CadastroEmpresaComponent implements OnInit {
  constructor(private fb: FormBuilder, private router: Router,
              private cadastroEmpresaService: CadastroEmpresaService ) { }
  // @ts-ignore
  contratante: FormGroup;
  ngOnInit(): void {
    this.contratante = this.fb.group({
      Nome: [null, Validators.required],
      Cnpj: [null, Validators.required],
      Login: [null, Validators.required],
      Senha: [null, Validators.required],
      Email: [null, Validators.required],
      Telefone: [null, Validators.required],
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

}
