import { HttpClient, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from 'app/app-routing.module';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from 'app/app.component';
import { HiveFormComponent } from 'app/hive-management/forms/hive-form.component';
import { HiveSectionFormComponent } from 'app/hive-management/forms/hive-section-form.component';
import { HiveListComponent } from 'app/hive-management/lists/hive-list.component';
import { HiveSectionListComponent } from 'app/hive-management/lists/hive-section-list.component';
import { HiveSectionService } from 'app/hive-management/services/hive-section.service';
import { HiveService } from 'app/hive-management/services/hive.service';
import { MainPageComponent } from 'app/main-page/main-page.component';
import { ProductCategoryFormComponent } from 'app/product-management/forms/product-category-form.component';
import { ProductFormComponent } from 'app/product-management/forms/product-form.component';
import { ProductCategoryListComponent } from 'app/product-management/lists/product-category-list.component';
import { ProductCategoryProductListComponent } from 'app/product-management/lists/product-category-product-list.component';
import { ProductListComponent } from 'app/product-management/lists/product-list.component';
import { ProductCategoryService } from 'app/product-management/services/product-category.service';
import { ProductService } from 'app/product-management/services/product.service';

// Angular Material
import { MatSliderModule } from '@angular/material/slider';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { ClassFormComponent } from './class-management/forms/class-form.component';
import { ClassListComponent } from './class-management/lists/class-list.component';
import { SubClassListComponent } from './class-management/lists/subclass-list.component';
import { ClassService } from './class-management/services/class.service';
import { SubClassFormComponent } from './class-management/forms/subClass-form.component';

import { ClientListComponent } from './client-management/lists/client-list.component';
import { ClientFormComponent } from './client-management/forms/client-form.component';
import { ClientService } from './client-management/services/client.service';

import { OrderListComponent } from './client-management/lists/order-list.component';
import { OrderFormComponent } from './client-management/forms/order-form.component';

import { ImageListComponent } from './image-management/lists/image-list.component';
import { ImageFormComponent } from './image-management/forms/image-form.component';

import { ShipperListComponent } from './shipper-management/lists/shipper-list.component';
import { ShipperFormComponent } from './shipper-management/forms/shipper-form.component';

import { TransportListComponent } from './transport-management/lists/transport-list.component';
import { TransportService } from './transport-management/services/transport.service';
import { TransportFormComponent } from './transport-management/forms/transport-form.component';
import { ModeFormComponent } from './mode-management/forms/mode-form.component';
import { ModeListComponent } from './mode-management/lists/mode-list.component';
import { ModeService } from './mode-management/services/mode.service';

const appRoutes: Routes = [
  {

  }
]
@NgModule({
  declarations: [
    AppComponent,
    MainPageComponent,
    ProductCategoryListComponent,
    ProductCategoryFormComponent,
    ProductCategoryProductListComponent,
    ProductListComponent,
    ProductFormComponent,
    HiveListComponent,
    HiveFormComponent,
    HiveSectionFormComponent,
    HiveSectionListComponent,
    ClassListComponent,
	  ClassFormComponent,
    SubClassListComponent,
    SubClassFormComponent,
	  ShipperListComponent,
	  ShipperFormComponent,
	  ClientListComponent,
    ClientFormComponent,
	  OrderListComponent,
    OrderFormComponent,
	  ImageListComponent,
    ImageFormComponent,
    TransportFormComponent,
    TransportListComponent,
    ModeFormComponent,
    ModeListComponent,
  ],
  imports: [
    MatSliderModule,
    MatToolbarModule,
    MatButtonModule,
    MatTableModule,
    BrowserModule,
    FormsModule,
    NgbModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule,BrowserAnimationsModule,  
    ToastrModule.forRoot({
      timeOut: 1600,
      positionClass: 'toast-bottom-right',
      preventDuplicates: false,
    }), // ToastrModule added
  ],
  providers: [
    // Angular providers
    HttpClient,
    // Application providers
    ProductService,
    ProductCategoryService,
    HiveService,
    HiveSectionService,
    ClassService,
    ClientService,
    TransportService,
    ModeService,
  ],
  bootstrap: [AppComponent]
}) 
export class AppModule { }
