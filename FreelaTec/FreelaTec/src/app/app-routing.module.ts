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
import {GuardsService} from './guards/guards.service';

const routes: Routes = [
  {path: '',
    component: LoginComponent
  },
  {
    path: 'HomeContratante',
    component: HomeContratanteComponent,
    canActivate: [GuardsService]
  },
  {
    path: 'HomeFreelancer',
    component: HomeFreelancerComponent,
    canActivate: [GuardsService]
  },
  {
    path: 'Cadastro',
    component: CadastroComponent
  },
  {
    path: 'Contrato',
    component: ContratoComponent,
    canActivate: [GuardsService]
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
    component: ListaContratosComponent,
    canActivate: [GuardsService]
  },
  {
    path: 'VerContrato',
    component: VerServicosComponent,
    canActivate: [GuardsService]
  },
  {
    path: 'VerFreela',
    component: VerFreelaComponent,
    canActivate: [GuardsService]
  },
  {
    path: 'Editar',
    component: EditarComponent,
    canActivate: [GuardsService]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
