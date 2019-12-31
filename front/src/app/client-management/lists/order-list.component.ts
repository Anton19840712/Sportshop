import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { OrderListItem } from '../models/order-list-item';
import { ClientService } from '../services/client.service';
import { OrderService } from '../services/order.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent implements OnInit {

  clientId: number;
  orders: Array<OrderListItem>;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private clientService: ClientService, 
    private orderService: OrderService,
    private toastr: ToastrService
  ) { }

  ngOnInit() {
    this.route.params.subscribe(p => {
      this.clientId = p['id']; //беру айди из роута
        this.clientService.getOrders(this.clientId).subscribe(s => this.orders = s);

    })
  }

  onDelete(orderId: number) {
    this.orderService.deleteOrder(orderId).subscribe(c => this.ngOnInit());
    this.toastr.success("Katla-sport order's record deleted successfully!");
  }
}
