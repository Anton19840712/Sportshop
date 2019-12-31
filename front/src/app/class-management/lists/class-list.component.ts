import { Component, OnInit } from '@angular/core';
import { ClassListItem } from '../models/class-list-item';
import { ClassService } from '../services/class.service';
import { ToastrService } from 'ngx-toastr';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-class-list',
  templateUrl: './class-list.component.html',
  styleUrls: ['./class-list.component.css']
})
export class ClassListComponent implements OnInit {

  classes: ClassListItem[];
  
  constructor(
    private classService: ClassService,
    private toastr: ToastrService
    ) { }

  ngOnInit() {
    this.getClasses();
    this.toastr.info("Katla-sport classes list");
  }

  getClasses() {
    this.classService.getClasses().subscribe(h => this.classes = h);
  }

  onDelete(classId: number) {
    this.classService.deleteClass(classId).subscribe(c => this.ngOnInit());
    Swal.fire('Katla-sport was deleted!')
  }
}
