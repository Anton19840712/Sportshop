import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TransportService } from '../services/transport.service';
import { Transport } from '../models/transport';

@Component({
  selector: 'app-transport-form',
  templateUrl: './transport-form.component.html',
  styleUrls: ['./transport-form.component.css']
})
export class TransportFormComponent implements OnInit {

  transport = new Transport(0, "", 0, 0, 0);
  existed = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private transportService: TransportService
  ) { }

  ngOnInit() {
    this.route.params.subscribe(p => {
      if (p['id'] === undefined) return;
      this.transportService.getTransport(p['id']).subscribe(h => this.transport = h);
      this.existed = true;
    });
  }

  navigateToTransports() {
    this.router.navigate(['/transports']);
  }

  onCancel() {
    this.navigateToTransports();
  }

  onSubmit() {
    if (this.existed)
    {
      this.transportService.updateTransport(this.transport).subscribe(p => this.navigateToTransports());
    }
    else
    {
      this.transportService.addTransport(this.transport).subscribe(p => this.navigateToTransports());
    }
  }

  onDelete() {
    this.transportService.deleteTransport(this.transport.id).subscribe(p => this.navigateToTransports());
  }
}
