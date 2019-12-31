import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Shipper } from '../models/shipper';
import { ShipperService } from '../services/shipper.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-shipper-form',
  templateUrl: './shipper-form.component.html',
  styleUrls: ['./shipper-form.component.css']
})
export class ShipperFormComponent implements OnInit {
 public shipper = new Shipper(0, "","", 0, 0);
  public existed = false;
  public clientId : number;
  public orderId : number;

   constructor(
    private route: ActivatedRoute,
    private router: Router,
    private shipperService: ShipperService,
    private toastr: ToastrService
  ) { }

   ngOnInit() : void {
    this.route.params.subscribe(p => {
      this.clientId = p['clientId'];

      this.orderId = p['orderId'];
      if (p['shipperId'] === undefined) {

        this.shipper.sportNutritionOrderID = p['orderId'];
        return;
      }
       this.shipperService.getShipper(p['shipperId']).subscribe(h => {
         this.shipper = h;
         this.shipper.shipperID  = p['shipperId'];

       });
      this.existed = true;
    });  
  }

   navigateToShippers() : void {

    this.router.navigate([`/client/${this.clientId}/order/${this.shipper.sportNutritionOrderID}/shippers`]);
  }

   onCancel() : void {
    this.navigateToShippers();
  }

   onSubmit() : void {
    if (this.existed) {
      this.shipperService.updateShipper(this.shipper).subscribe(p => this.navigateToShippers());
    } else {
      this.shipperService.addShipper(this.shipper).subscribe(p => this.navigateToShippers());
    }
  }

   onDelete() : void {
    this.shipperService.deleteShipper(this.shipper.shipperID).subscribe(s => this.navigateToShippers());
    this.toastr.success("Katla-sport shipper's record deleted successfully!");
  }
}
