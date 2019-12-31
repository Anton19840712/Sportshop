import { Component, OnInit } from '@angular/core';
import { ModeListItem } from '../models/mode-list-item';
import { ModeService } from '../services/mode.service';

@Component({
  selector: 'app-mode-list',
  templateUrl: './mode-list.component.html',
  styleUrls: ['./mode-list.component.css']
})
export class ModeListComponent implements OnInit {

  modes: ModeListItem[];
  fileToUpload: File = null;

  constructor(private modeService: ModeService) { }

  ngOnInit() {
    this.getModes();
  }

  getModes() {
    this.modeService.getModes().subscribe(h => this.modes = h);
  }

  onDelete(modeId: number) {
    var mode = this.modes.find(h => h.id == modeId);
    this.modeService.deleteMode(modeId).subscribe(c => this.getModes());
  }

}
