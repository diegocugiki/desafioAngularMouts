import { Estado } from "./Estado";

export class Municipio {

    constructor () {
      this.id = 0;
      this.nome = '';
      this.prefeito = '';
      this.populacao = 0;
      this.estadoId = 0;
      this.estado = new Estado();
    }
  
    id: number;
    nome: string;
    prefeito: string;
    populacao: number;
    estadoId: number;
    estado: Estado;
}