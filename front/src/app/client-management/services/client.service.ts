import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { Client } from '../models/client';
import { ClientListItem } from '../models/client-list-item';
import { OrderListItem } from '../models/order-list-item';

@Injectable({
  providedIn: 'root'
})
export class ClientService {
  private url = environment.apiUrl + '/api/sportNutritionClient/';

  constructor(private http: HttpClient) { }

  getClients(): Observable<Array<ClientListItem>> {
    return this.http.get<Array<ClientListItem>>(`${this.url}list clients`);
  }

  getClient(clientId: number): Observable<Client> {
    return this.http.get<Client>(`${this.url}show one by id/${clientId}`);
  }

  getOrders(clientId: number): Observable<Array<OrderListItem>> {
    return this.http.get<Array<OrderListItem>>(`${this.url}orders/${clientId}`);
  }

  addClient(myclient: Client): Observable<Client> {
    return this.http.post<Client>(`${this.url}create`, myclient);
  }

  updateClient(myclient: Client): Observable<Object> {
    return this.http.post<Object>(`${this.url}update/${myclient.sportNutritionClientID}`, myclient);
  }

  deleteClient(clientId: number): Observable<Object> {
    return this.http.post<Object>(`${this.url}annihilate/${clientId}`, null);
  }
}
