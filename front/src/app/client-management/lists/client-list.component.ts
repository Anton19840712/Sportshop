import { Component, OnInit } from '@angular/core';
import { ClientListItem } from '../models/client-list-item';
import { ClientService } from '../services/client.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-client-list',
  templateUrl: './client-list.component.html',
  styleUrls: ['./client-list.component.css']
})
export class ClientListComponent implements OnInit {

  selectedClient: ClientListItem;
  clients: ClientListItem[] = [];
  columnsToDisplay = ['sportNutritionClientID', 'sportNutritionСlientName', 'sportNutritionСlientCity', 'sportNutritionСlientGender', 'sportNutritionСlientAge', 'actionButtons'];


  constructor(
    private clientService: ClientService,
    private toastr: ToastrService
    ) 
    { }

  ngOnInit() {
    this.getClients();
  }

  onSelect(client: ClientListItem): void {
    this.selectedClient = client;
  }

  getClients() {
    this.clientService.getClients().subscribe(h => this.clients = h);
    this.toastr.info("Katla-sport client's list");
  }

  onDelete(clientId: number) {
    this.clientService.deleteClient(clientId).subscribe(c => this.ngOnInit());
    this.toastr.success("Katla-sport client's record deleted successfully!");
  }
}
