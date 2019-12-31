import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ClassService } from '../services/class.service';
import { Class } from '../models/class';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-class-form',
  templateUrl: './class-form.component.html',
  styleUrls: ['./class-form.component.css']
})
export class ClassFormComponent implements OnInit {

  class = new Class(0, "");
  existed = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private classService: ClassService,
    private toastr: ToastrService
  ) { }


  ngOnInit() {
    this.route.params.subscribe(p => {
      if (p['id'] === undefined) return;
      this.classService.getClass(p['id']).subscribe(h => this.class = h);
      this.existed = true;
      this.toastr.info("Katla-sport class editor")
    });
  }

  navigateToClasses() {
    this.router.navigate(['/classes']);
  }

  onCancel() {
    this.navigateToClasses();
  }
  
  onSubmit() {
    if (this.existed) {
      this.classService.updateClass(this.class).subscribe(c => this.navigateToClasses());
    } else {
      this.classService.addClass(this.class).subscribe(c => this.navigateToClasses());
    }
  }

  onDelete() {
    this.classService.deleteClass(this.class.sportNutritionClassID).subscribe(c => this.navigateToClasses());
    this.toastr.success("Katla-sport class was deleted successfully!")
  }
}
