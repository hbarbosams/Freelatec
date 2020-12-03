import {Pessoa} from './Pessoa';


export class ContratanteModel extends Pessoa{
  contratanteId?: number;
  descrContratante?: string;
  areaAtuacao?: string;
  cnpj?: any;
}
