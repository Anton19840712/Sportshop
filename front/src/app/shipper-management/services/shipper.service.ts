import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { Shipper } from '../models/shipper';
import { ShipperListItem } from '../models/shipper-list-item';

@Injectable({
  providedIn: 'root'
})
export class ShipperService {
  private url = environment.apiUrl + '/api/shippers/';

  constructor(private http: HttpClient) { }

  getShippers(): Observable<Array<ShipperListItem>> {
    return this.http.get<Array<ShipperListItem>>(`${this.url}GetAll`);
  }

  getShipper(shipperId: number): Observable<Shipper> {
    return this.http.get<Shipper>(`${this.url}${shipperId}`);
  }

  addShipper(myshipper: Shipper): Observable<Shipper> {
    return this.http.post<Shipper>(`${this.url}`, myshipper);
  }

  updateShipper(myshipper: Shipper): Observable<Object> {
    return this.http.put<Object>(`${this.url}${myshipper.shipperID}`, myshipper);
  }

  deleteShipper(shipperId: number): Observable<Object> {
    return this.http.delete<Object>(`${this.url}${shipperId}`);
  }

  setShipperStatus(shipperId: number, deletedStatus: boolean): Observable<Object> {
    return this.http.put<Shipper>(`${this.url}${shipperId}/status/${deletedStatus}`, null);
  }
}
