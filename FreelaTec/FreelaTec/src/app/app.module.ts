import {BrowserModule} from '@angular/platform-browser';
import {LOCALE_ID, NgModule} from '@angular/core';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {NavegacaoComponent} from './Componentes/navegacao/navegacao.component';
import {LayoutModule} from '@angular/cdk/layout';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatButtonModule} from '@angular/material/button';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatIconModule} from '@angular/material/icon';
import {MatListModule} from '@angular/material/list';
import {MatCardModule} from '@angular/material/card';
import {LoginComponent} from './views/login/login.component';
import {MatFormFieldModule} from '@angular/material/form-field';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatNativeDateModule, MatOptionModule} from '@angular/material/core';
import {MatSelectModule} from '@angular/material/select';
import {MatInputModule} from '@angular/material/input';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatMenuModule} from '@angular/material/menu';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatSortModule} from '@angular/material/sort';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import {MatDialogModule} from '@angular/material/dialog';
import {MatTooltipModule} from '@angular/material/tooltip';
import {HttpClientModule} from '@angular/common/http';
import {IConfig, NgxMaskModule} from 'ngx-mask';
import {registerLocaleData} from '@angular/common';
import localePt from '@angular/common/locales/pt';
import {Ng2SearchPipeModule} from 'ng2-search-filter';
import {CadastroComponent} from './views/cadastro/cadastro.component';
import {HomeContratanteComponent} from './views/home-contratante/home-contratante.component';
import {HomeFreelancerComponent} from './views/home-freelancer/home-freelancer.component';
import {ContratoComponent} from './views/contrato/contrato.component';
import {CadastroEmpresaComponent} from './views/cadastro-empresa/cadastro-empresa.component';
import {CadastroFreelancerComponent} from './views/cadastro-freelancer/cadastro-freelancer.component';
import {TabelaContratosComponent} from './views/home-contratante/tabela-contratos/tabela-contratos.component';
import { ProjetosComponent } from './views/contrato/projetos/projetos.component';

registerLocaleData(localePt);
const maskConfig: Partial<IConfig> = {
  validation: false,
};


@NgModule({
  declarations: [
    AppComponent,
    NavegacaoComponent,
    LoginComponent,
    CadastroComponent,
    HomeContratanteComponent,
    HomeFreelancerComponent,
    ContratoComponent,
    CadastroEmpresaComponent,
    CadastroFreelancerComponent,
    TabelaContratosComponent,
    ProjetosComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatSidenavModule,
    MatListModule,
    MatCardModule,
    MatButtonModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatSnackBarModule,
    HttpClientModule,
    MatGridListModule,
    MatTooltipModule,
    MatOptionModule,
    MatSelectModule,
    MatIconModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatInputModule,
    ReactiveFormsModule,
    MatAutocompleteModule,
    NgxMaskModule.forRoot(maskConfig),
    Ng2SearchPipeModule,
    LayoutModule,
    MatMenuModule,
    MatProgressSpinnerModule,
    MatDialogModule
  ],
  providers: [{
    provide: LOCALE_ID,
    useValue: 'pt-BR'
  }],
  bootstrap: [AppComponent]
})
export class AppModule {

}
