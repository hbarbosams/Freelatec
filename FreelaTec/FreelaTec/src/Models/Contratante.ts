import {Pessoa} from './Pessoa';


export class ContratanteModel extends Pessoa{
  ContratanteId?: number;
  DescrContratante?: string;
  AreaAtuacao?: string;
  Cnpj?: string;
}
