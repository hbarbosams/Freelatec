import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {LoginComponent} from './views/login/login.component';
import {CadastroComponent} from './views/cadastro/cadastro.component';
import {CampanhasComponent} from './views/campanhas/campanhas.component';
import {HomeContratanteComponent} from './views/home-contratante/home-contratante.component';
import {HomeFreelancerComponent} from './views/home-freelancer/home-freelancer.component';
import {ContratoComponent} from './views/contrato/contrato.component';
import {CadastroEmpresaComponent} from './views/cadastro-empresa/cadastro-empresa.component';
import {CadastroFreelancerComponent} from './views/cadastro-freelancer/cadastro-freelancer.component';

const routes: Routes = [
  {path: '',
    component: LoginComponent
  },
  {
    path: 'HomeContratante',
    component: HomeContratanteComponent
  },
  {
    path: 'HomeFreelancer',
    component: HomeFreelancerComponent
  },
  {
    path: 'Cadastro',
    component: CadastroComponent
  },
  {
    path: 'Campanhas',
    component: CampanhasComponent
  },
  {
    path: 'Contrato',
    component: ContratoComponent
  },
  {
    path: 'CadastroEmpresa',
    component: CadastroEmpresaComponent
  },
  {
    path: 'CadastroFreelancer',
    component: CadastroFreelancerComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
