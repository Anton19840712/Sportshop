import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Order } from '../models/order';
import { OrderService } from '../services/order.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-order-form',
  templateUrl: './order-form.component.html',
  styleUrls: ['./order-form.component.css']
})
export class OrderFormComponent implements OnInit {
 public order = new Order(0, 0, 0, 0, 0, "","","","");
  public existed = false;
  public clientId : number;

   constructor(
    private route: ActivatedRoute,
    private router: Router,
    private orderService: OrderService,
    private toastr: ToastrService
  ) { }

   ngOnInit() : void {
    this.route.params.subscribe(p => {
      if (p['id'] === undefined) {
        this.order.sportNutritionClientID = p['sid'];
        return;
      }
       this.orderService.getOrder(p['id']).subscribe(h => {
        this.clientId = p['sid'];
        this.order = h;
       });

      this.existed = true;
    });  
  }

   navigateToOrders() : void {

    this.router.navigate([`/client/${this.order.sportNutritionClientID }/orders`]);
  }

   onCancel() : void {
    this.navigateToOrders();
  }

   onSubmit() : void {
    if (this.existed) {
      this.orderService.updateOrder(this.order).subscribe(p => this.navigateToOrders());
    } else {
      this.orderService.addOrder(this.order).subscribe(p => this.navigateToOrders());
    }
  }

   onDelete() : void {
    this.orderService.deleteOrder(this.order.sportNutritionOrderID).subscribe(s => this.navigateToOrders());
    this.toastr.info("Katla-sport order deleted");
  }
}
