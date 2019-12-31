import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { Image } from '../models/image';
import { ImageListItem } from '../models/image-list-item';

@Injectable({
  providedIn: 'root'
})
export class ImageService {
  private url = environment.apiUrl + '/api/sportNutritionProductImages/';
                                // POST /api/sportNutritionProductImages/upload

  constructor(private http: HttpClient) { }

  getImages(): Observable<Array<ImageListItem>> {
    return this.http.get<Array<ImageListItem>>(this.url);
  }

  getImage(imageId: number): Observable<Image> {
    return this.http.get<Image>(`${this.url}${imageId}`);
  }

  updateImage(myimage: Image): Observable<Object> {
    return this.http.put<Object>(`${this.url}${myimage.sportNutritionProductImageID}`, myimage);
  }

  deleteImage(imageId: number): Observable<Object> {
    return this.http.delete<Object>(`${this.url}${imageId}`);
  }

  uploadImage(image: FormData): Observable<object> {
    return this.http.post<Image>(this.url + "upload", image);
  }

}
