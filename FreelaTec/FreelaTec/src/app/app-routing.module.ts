import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {LoginComponent} from './views/login/login.component';
import {CadastroComponent} from './views/cadastro/cadastro.component';
import {HomeContratanteComponent} from './views/home-contratante/home-contratante.component';
import {HomeFreelancerComponent} from './views/home-freelancer/home-freelancer.component';
import {ContratoComponent} from './views/contrato/contrato.component';
import {CadastroEmpresaComponent} from './views/cadastro-empresa/cadastro-empresa.component';
import {CadastroFreelancerComponent} from './views/cadastro-freelancer/cadastro-freelancer.component';
import {ListaContratosComponent} from './views/lista-contratos/lista-contratos.component';
import {VerServicosComponent} from './views/ver-servicos/ver-servicos.component';
import {VerFreelaComponent} from './views/home-contratante/ver-freela/ver-freela.component';
import {EditarComponent} from './views/editar/editar.component';

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
  },
  {
    path: 'ContratosLista',
    component: ListaContratosComponent
  },
  {
    path: 'VerContrato',
    component: VerServicosComponent
  },
  {
    path: 'VerFreela',
    component: VerFreelaComponent
  },
  {
    path: 'Editar',
    component: EditarComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
