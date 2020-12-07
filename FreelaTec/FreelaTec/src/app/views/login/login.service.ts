import { Injectable } from '@angular/core';
import {Freelancer} from '../../../Models/Freelancer';
import {ContratanteModel} from '../../../Models/Contratante';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  public freelancer: Freelancer;
  public contratante: ContratanteModel;
  public login: number;
  public autentica = false;
  public freela = false;
  public contrat = false;
  public user: string;
  constructor() { }
}
