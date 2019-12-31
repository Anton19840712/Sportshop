import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ClientService } from '../services/client.service';
import { Client } from '../models/client';
import { ToastrService } from 'ngx-toastr';
//import Swal from 'sweetalert2';

@Component({
  selector: 'app-client-form',
  templateUrl: './client-form.component.html',
  styleUrls: ['./client-form.component.css']
})
export class ClientFormComponent implements OnInit {

  client = new Client(0, "", "", "", 0);
  existed = false;


  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private clientService: ClientService,
    private toastr: ToastrService
  ) { }

  ngOnInit() {
    this.route.params.subscribe(p => {
      if (p['id'] === undefined) return;
      this.clientService.getClient(p['id']).subscribe(h => this.client = h);
      this.existed = true;
    });
  }

  navigateToClients() {
    this.router.navigate(['/clients']);
  }

  onCancel() {
    this.navigateToClients();
    this.toastr.success("Operation aborted")
  }
  
  onSubmit() {
    if (this.existed) {
      this.clientService.updateClient(this.client).subscribe(c => this.navigateToClients());
    } else {
      this.clientService.addClient(this.client).subscribe(c => this.navigateToClients());
    }
  }

  onDelete() {
    this.clientService.deleteClient(this.client.sportNutritionClientID).subscribe(c => this.navigateToClients());
    this.toastr.success("CLient's record was deleted successfully")
  }
}
