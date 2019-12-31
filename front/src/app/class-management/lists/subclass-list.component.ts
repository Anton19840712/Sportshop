import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SubClassListItem } from '../models/subclass-list-item';
import { ClassService } from '../services/class.service';
import { SubClassService } from '../services/subclass.service';
import { ToastrService } from 'ngx-toastr';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-subClass-list',
  templateUrl: './subClass-list.component.html',
  styleUrls: ['./subClass-list.component.css']
})
export class SubClassListComponent implements OnInit {

  classId: number;
  subClasses: Array<SubClassListItem>;
  fileToUpload : File = null;
  files : any;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private classService: ClassService, 
    private subClassService: SubClassService,
    private toastr: ToastrService
  ) { }

  ngOnInit() {
    this.route.params.subscribe(p => {
      this.classId = p['id'];
        this.classService.getSubClasses(this.classId).subscribe(s => this.subClasses = s);
    })
  }

  onDelete(subClassId: number) {
    this.subClassService.deleteSubClass(subClassId).subscribe(c => this.ngOnInit());
    Swal.fire({
      position: 'bottom-start',
      icon: 'success',
      title: 'Subclass was deleted successfully!',
      showConfirmButton: false,
      timer: 1500
    })
    this.toastr.info("Katla-sport subclass record was deleted successfully");
  }

  uploadFile(subClassId:number) {
    this.subClassService.updateImage(subClassId,this.fileToUpload).subscribe(data => { },
      error => {
        console.log(error);
      });
      Swal.fire('File uploaded!')
    }

  fileHandler(subClassId:number, files: FileList) {
    this.fileToUpload = files.item(0);
    this.uploadFile(subClassId)
  }
}