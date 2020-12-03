export class Contrato {
  nrContrato: number;
  dataContrato: number;
  dataInicial: number;
  prazo: number;
  descricao: string;
  total: number;
  status: number;
  notaContratante: number;
  notaFreelancer: number;
  // tslint:disable-next-line:variable-name
  contratante_id: number | undefined;
  // tslint:disable-next-line:variable-name
  freelancer_id: number;
}
