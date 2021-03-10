import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Municipio } from '../models/Municipio';

@Injectable({
  providedIn: 'root'
})
export class MunicipioService {

  urlBase = `${environment.urlApi}municipio`;

  constructor(private http: HttpClient) { }

  obterTodos() : Observable<Municipio[]> {
    return this.http.get<Municipio[]>(this.urlBase);
  }

  obterTodosPeloEstadoId(estadoId: number) : Observable<Municipio[]> {
    return this.http.get<Municipio[]>(`${this.urlBase}/estadoId=${estadoId}`);
  }

  salvar(municipio: Municipio) {
    return this.http.post(this.urlBase, municipio);
  }

  deletar(id: number) {
    return this.http.delete(`${this.urlBase}/${id}`);
  }

  editar(municipio: Municipio) {
    return this.http.put(`${this.urlBase}/${municipio.id}`, municipio);
  }
}
