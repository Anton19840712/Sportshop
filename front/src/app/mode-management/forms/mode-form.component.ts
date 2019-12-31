import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ModeService } from '../services/mode.service';
import { Mode } from '../models/mode';

@Component({
  selector: 'app-mode-form',
  templateUrl: './mode-form.component.html',
  styleUrls: ['./mode-form.component.css']
})
export class ModeFormComponent implements OnInit {

  mode = new Mode(0, "");
  exists = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private modeService: ModeService
  ) { }

  ngOnInit() {
    this.route.params.subscribe(p => {
      if (p['id'] === undefined) return;
      this.modeService.getMode(p['id']).subscribe(h => this.mode = h);
      this.exists = true;
    });
  }

  navigateToModes() {
    this.router.navigate(['/modes']);
  }

  onCancel() {
    this.navigateToModes();
  }

  onSubmit() {
    if (this.exists) {
      this.modeService.updateMode(this.mode).subscribe(c => this.navigateToModes());
    } else {
      this.modeService.addMode(this.mode).subscribe(c => this.navigateToModes());
    }

  }
  onDelete() {
    this.modeService.deleteMode(this.mode.id).subscribe(p => this.navigateToModes());
  }
}
