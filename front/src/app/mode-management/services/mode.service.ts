import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { Mode } from '../models/mode';
import { ModeListItem } from '../models/mode-list-item';

@Injectable({
  providedIn: 'root'
})

export class ModeService {
  private url = environment.apiUrl + 'api/mode/';

  constructor(private http: HttpClient) { }

  getModes(): Observable<Array<ModeListItem>> {
    return this.http.get<Array<ModeListItem>>(`${this.url}getall`);
  }

  getMode(ModeId: number): Observable<Mode> {
    return this.http.get<Mode>(`${this.url}getone/${ModeId}`);
  }

  addMode(mode: Mode): Observable<Mode> {
    return this.http.post<Mode>(`${this.url}create`,mode);
  }

  updateMode(mode: Mode): Observable<Object> {
    return this.http.post<Object>(`${this.url}update/${mode.id}`,mode);
  }

  deleteMode(ModeId: number): Observable<Object> {
    return this.http.post<Object>(`${this.url}clean/${ModeId}`,null);
  }
}

