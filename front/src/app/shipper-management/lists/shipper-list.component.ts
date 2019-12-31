import { Component, OnInit } from '@angular/core';
import { ShipperListItem } from '../models/shipper-list-item';
import { ShipperService } from '../services/shipper.service';
import { OrderService } from '../../client-management/services/order.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-shipper-list',
  templateUrl: './shipper-list.component.html',
  styleUrls: ['./shipper-list.component.css']
})
export class ShipperListComponent implements OnInit {

  shippers: ShipperListItem[];
  clientId: number;
  orderId: number;
  
  
  constructor(
    private route: ActivatedRoute,
    private shipperService: ShipperService,
    private orderService: OrderService,
    private toastr: ToastrService
    ) { }

  ngOnInit() {

      this.route.params.subscribe(p => {
      this.clientId = p['mid'];
      this.orderId = p['gid'];
      this.getShippers();
    });
  }
  
  getShippers() {
    this.orderService.getShippers(this.orderId).subscribe(h => this.shippers = h);

  }

  onDelete(shipperId: number) {
    this.shipperService.deleteShipper(shipperId).subscribe(c => this.ngOnInit());
    this.toastr.success("Katla-sport shipper's record deleted successfully!");
  }
}
