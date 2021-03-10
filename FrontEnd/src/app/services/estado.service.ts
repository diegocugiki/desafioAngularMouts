import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Estado } from '../models/Estado';

@Injectable({
  providedIn: 'root'
})
export class EstadoService {

  urlBase = `${environment.urlApi}estado`;

  constructor(private http: HttpClient) { }

  obterTodos() : Observable<Estado[]> {
    return this.http.get<Estado[]>(this.urlBase);
  }

  salvar(estado: Estado) {
    return this.http.post(this.urlBase, estado);
  }

  deletar(id: number) {
    return this.http.delete(`${this.urlBase}/${id}`);
  }

  editar(estado: Estado) {
    return this.http.put(`${this.urlBase}/${estado.id}`, estado);
  }
}
