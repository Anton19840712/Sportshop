import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { Class } from '../models/class';
import { ClassListItem } from '../models/class-list-item';
import { SubClassListItem } from '../models/subclass-list-item';

@Injectable({
  providedIn: 'root'
})
export class ClassService {
  private url = environment.apiUrl + 'api/sportNutritionClasses/';

  constructor(private http: HttpClient) { }

  getClasses(): Observable<Array<ClassListItem>> {
    return this.http.get<Array<ClassListItem>>(this.url);
  }

  getClass(classId: number): Observable<Class> {
    return this.http.get<Class>(`${this.url}${classId}`);
  }

  getSubClasses(classId: number): Observable<Array<SubClassListItem>> {
    return this.http.get<Array<SubClassListItem>>(`${this.url}${classId}/subclasses`);
  }

  addClass(myclass: Class): Observable<Class> {
    return this.http.post<Class>(`${this.url}`, myclass);
  }

  updateClass(myclass: Class): Observable<Object> {
    return this.http.put<Object>(`${this.url}${myclass.sportNutritionClassID}`, myclass);
  }

  deleteClass(classId: number): Observable<Object> {
    return this.http.delete<Object>(`${this.url}${classId}`);
  }

  setClassStatus(classId: number, deletedStatus: boolean): Observable<Object> {
    return this.http.put<Class>(`${this.url}${classId}/status/${deletedStatus}`, null);
  }
}
