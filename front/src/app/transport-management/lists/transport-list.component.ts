import { Component, OnInit } from '@angular/core';
import { TransportListItem } from '../models/transport-list-item';
import { TransportService } from '../services/transport.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-transport-list',
  templateUrl: './transport-list.component.html',
  styleUrls: ['./transport-list.component.css']
})
export class TransportListComponent implements OnInit {

  transports: TransportListItem[];
  fileToUpload: File = null;

  constructor(
    private transportService: TransportService,
    private toastr: ToastrService
    ) { }

  ngOnInit() {
    this.getTransports();
    this.toastr.info("Katla-sport trabsports list");
  }

  getTransports() {
    this.transportService.getTransports().subscribe(h => this.transports = h);
  }

  onDelete(transportId: number) {
    var transport = this.transports.find(h => h.id == transportId);
    this.transportService.deleteTransport(transportId).subscribe(c => this.getTransports());
  }

  uploadFile(transportId:number) {
    this.transportService.updateInformation(transportId,this.fileToUpload).subscribe(data => { },
      error => {
        console.log(error);
      });
    }

  fileHandler(transportId:number, files: FileList) {
    this.fileToUpload = files.item(0);
    this.uploadFile(transportId)
  }
}
