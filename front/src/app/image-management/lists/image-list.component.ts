import { Component, OnInit } from '@angular/core';
import { ImageListItem } from '../models/image-list-item';
import { ImageService } from '../services/image.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-image-list',
  templateUrl: './image-list.component.html',
  styleUrls: ['./image-list.component.css']
})
export class ImageListComponent implements OnInit {

  images: ImageListItem[];
  imageUrl : string = "/assets/img/deafault-image.png";

  fileToUpload : File = null;

  constructor(
    private imageService: ImageService,
    private toastr: ToastrService
    ) { }

  ngOnInit() {
    this.getImages();
    this.toastr.info("Katla-sport files list")
  }

  handleFileInput(file: FileList) {
    this.fileToUpload = file.item(0);

    //Show image preview
    var reader = new FileReader();
    reader.onload = (event:any) => {
      this.imageUrl = event.target.result;
    }
    reader.readAsDataURL(this.fileToUpload);
  }
  
  getImages() {
    this.imageService.getImages().subscribe(h => this.images = h);
  }

  onDelete(imageId: number) {
    this.imageService.deleteImage(imageId).subscribe(c => this.ngOnInit());
    this.toastr.success("Katla-sport file record was deleted successfully!")
  }
}
