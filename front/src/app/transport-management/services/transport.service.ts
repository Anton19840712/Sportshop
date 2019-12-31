import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { Transport } from '../models/transport';
import { TransportListItem } from '../models/transport-list-item';

@Injectable({
  providedIn: 'root'
})
export class TransportService {
  private url = environment.apiUrl + 'api/transport/';

  constructor(private http: HttpClient) { }

  getTransports(): Observable<Array<TransportListItem>> {
    return this.http.get<Array<TransportListItem>>(this.url);
  }

  getTransport(transportId: number): Observable<Transport> {
    return this.http.get<Transport>(`${this.url}${transportId}`);
  }

  addTransport(transport: Transport): Observable<Transport> {
    return this.http.post<Transport>(`${this.url}`, transport);
  }

  updateTransport(transport: Transport): Observable<Object> {
    return this.http.put<Object>(`${this.url}${transport.id}`, transport);
  }

  deleteTransport(transportId: number): Observable<Object> {
    return this.http.delete<Object>(`${this.url}${transportId}`);
  }

  updateInformation(transportId: number,fileToUpload: File): Observable<Object> {
    const formData: FormData = new FormData();
    formData.append('fileKey', fileToUpload, fileToUpload.name);
    return this.http.patch<Object>(`${this.url}${transportId}/info`, formData);
  }
}
