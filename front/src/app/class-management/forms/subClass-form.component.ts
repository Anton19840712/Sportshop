import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SubClass } from '../models/subclass';
import { SubClassService } from '../services/subclass.service';
import { ToastrService } from 'ngx-toastr';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-subclass-form',
  templateUrl: './subclass-form.component.html',
  styleUrls: ['./subclass-form.component.css']
})
export class SubClassFormComponent implements OnInit {
 public subClass = new SubClass(0, 0, "", 0, 0, 0, "");
  public existed = false;
  public classId : number;

   constructor(
    private route: ActivatedRoute,
    private router: Router,
    private subClassService: SubClassService,
    private toastr: ToastrService
  ) { }

   ngOnInit() : void {
    this.route.params.subscribe(p => {
      if (p['id'] === undefined) {
        this.subClass.sportNutritionClassID = p['sid'];
        return;
      }
       this.subClassService.getSubClass(p['id']).subscribe(h => {
         this.subClass = h;
         this.subClass.sportNutritionClassID  = p['sid'];
       });
      this.existed = true;
      this.toastr.info("Katla-sport sub class list loaded")
    });  
  }

   navigateToSubClasses() : void {

    this.router.navigate([`/class/${this.subClass.sportNutritionClassID }/subclasses`]);
  }

   onCancel() : void {
    this.navigateToSubClasses();
  }

   onSubmit() : void {
    if (this.existed) {
      this.subClassService.updateSubClass(this.subClass).subscribe(p => this.navigateToSubClasses());
      Swal.fire({
        position: 'bottom-start',
        icon: 'success',
        title: 'Subclass edited successfully!',
        showConfirmButton: false,
        timer: 1500
      })

    } else {
      this.subClassService.addSubClass(this.subClass).subscribe(p => this.navigateToSubClasses());
    }
    this.toastr.success("Katla-sport sublass-list was added successfully!")
  }

   onDelete() : void {
    this.subClassService.deleteSubClass(this.subClass.sportNutritionSubClassID).subscribe(s => this.navigateToSubClasses());
    this.toastr.success("Katla-sport subclass was deleted successfully!");
  }
}
