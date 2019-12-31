import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ImageService } from '../services/image.service';
import { Image } from '../models/image';
import { Observable } from 'rxjs';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-image-form',
  templateUrl: './image-form.component.html',
  styleUrls: ['./image-form.component.css']
})

export class ImageFormComponent  {

  image = new Image(0, "", "", "");
  existed = false;
  fileToUpload : File = null;
  files : any;

  constructor(
    private router: Router,
    private imageService: ImageService,
    private httpService: HttpClient

  ) { }

  onSubmit() {
    if (this.files) {
      let files :FileList = this.files;
      const formData = new FormData();
      for(let i = 0; i < files.length; i++){
           formData.append('photo', files[i]);
      }
      this.imageService.uploadImage(formData).subscribe(p => this.navigateToImages());
    }
  }

  navigateToImages() {
    this.router.navigate(['/images']);
  }

  addPhoto(event) {
    let target = event.target || event.srcElement;
    this.files = target.files;
  }

}
