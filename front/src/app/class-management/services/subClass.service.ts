import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { SubClass } from '../models/subclass';
import { SubClassListItem } from '../models/subclass-list-item';

@Injectable({
  providedIn: 'root'
})
export class SubClassService {
  private url = environment.apiUrl + '/api/sportNutritionSubClasses/';

  constructor(private http: HttpClient) { }

  getSubClasses(): Observable<Array<SubClassListItem>> {
    return this.http.get<Array<SubClassListItem>>(this.url);
  }

  getSubClass(subClassId: number): Observable<SubClass> {
    return this.http.get<SubClass>(`${this.url}${subClassId}`);
  }

  addSubClass(subClass: SubClass): Observable<SubClass> {
    return this.http.post<SubClass>(this.url, subClass);
  }

  updateSubClass (subClass: SubClass): Observable<SubClass> {
    return this.http.put<SubClass>(`${this.url}${subClass.sportNutritionSubClassID}`, subClass);
  }

  deleteSubClass(subClassId: number): Observable<Object> {
    return this.http.delete<Object>(`${this.url}${subClassId}`);
  }

  // uploadImage(subClass: FormData): Observable<object> {
  //   return this.http.post<SubClass>(this.url + "upload", subClass);
  // }

  updateImage(subClassId: number,fileToUpload: File): Observable<Object> {
    const formData: FormData = new FormData();
    formData.append('fileKey', fileToUpload, fileToUpload.name);
    return this.http.patch<Object>(`${this.url}${subClassId}/upload`, formData);
  }
}
