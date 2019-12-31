import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { Order } from '../models/order';
import { OrderListItem } from '../models/order-list-item';
import { ShipperListItem } from '../../shipper-management/models/shipper-list-item';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private url = environment.apiUrl + 'api/sportNutritionOrders/';

  constructor(private http: HttpClient) { }

  getOrders(): Observable<Array<OrderListItem>> {
    return this.http.get<Array<OrderListItem>>(this.url);
  }

  getShippers(orderId: number): Observable<Array<ShipperListItem>> {
    return this.http.get<Array<ShipperListItem>>(`${this.url}${orderId}/shippers`);
  }

  // GET /api/sportNutritionOrders/{sportNutritionOrderId}/shippers

  getOrder(orderId: number): Observable<Order> {
    return this.http.get<Order>(`${this.url}${orderId}`);
  }

  addOrder(order: Order): Observable<Order> {
    return this.http.post<Order>(this.url, order);
  }

  updateOrder (order: Order): Observable<Order> {
    return this.http.put<Order>(`${this.url}${order.sportNutritionOrderID}`, order);
  }

  deleteOrder(orderId: number): Observable<Object> {
    return this.http.delete<Object>(`${this.url}${orderId}`);
  }
}
