import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainPageComponent } from 'app/main-page/main-page.component';
import { HiveFormComponent } from './hive-management/forms/hive-form.component';
import { HiveSectionFormComponent } from './hive-management/forms/hive-section-form.component';
import { HiveListComponent } from './hive-management/lists/hive-list.component';
import { HiveSectionListComponent } from './hive-management/lists/hive-section-list.component';
import { ProductCategoryFormComponent } from './product-management/forms/product-category-form.component';
import { ProductFormComponent } from './product-management/forms/product-form.component';
import { ProductCategoryListComponent } from './product-management/lists/product-category-list.component';
import { ProductCategoryProductListComponent } from './product-management/lists/product-category-product-list.component';
import { ProductListComponent } from './product-management/lists/product-list.component';

import { ClassListComponent } from './class-management/lists/class-list.component';
import { ClassFormComponent } from './class-management/forms/class-form.component';
import { SubClassListComponent } from './class-management/lists/subclass-list.component';
import { SubClassFormComponent } from './class-management/forms/subClass-form.component';

import { ClientListComponent } from './client-management/lists/client-list.component';
import { ClientFormComponent } from './client-management/forms/client-form.component';

import { OrderListComponent } from './client-management/lists/order-list.component';
import { OrderFormComponent } from './client-management/forms/order-form.component';

import { ImageListComponent } from './image-management/lists/image-list.component';
import { ImageFormComponent } from './image-management/forms/image-form.component';


import { ShipperListComponent } from './shipper-management/lists/shipper-list.component';
import { ShipperFormComponent } from './shipper-management/forms/shipper-form.component';

import { TransportFormComponent } from './transport-management/forms/transport-form.component';
import { TransportListComponent } from './transport-management/lists/transport-list.component';
import { ModeListComponent } from './mode-management/lists/mode-list.component';
import { ModeFormComponent } from './mode-management/forms/mode-form.component';

const routes: Routes = [
  { path: '', redirectTo: '/main', pathMatch: 'full' },
  { path: 'main', component: MainPageComponent },
  { path: 'categories', component: ProductCategoryListComponent },
  { path: 'category', component: ProductCategoryFormComponent },
  { path: 'category/:id', component: ProductCategoryFormComponent },
  { path: 'category/:id/products', component: ProductCategoryProductListComponent },
  { path: 'products', component: ProductListComponent },
  { path: 'product/:id', component: ProductFormComponent },
  { path: 'category/:categoryId/product/:id', component: ProductFormComponent },
  { path: 'hives', component: HiveListComponent },
  { path: 'hive', component: HiveFormComponent },
  { path: 'hive/:id', component: HiveFormComponent },
  { path: 'hive/:id/sections', component: HiveSectionListComponent },
  { path: 'hive/:hiveId/section', component: HiveSectionFormComponent },
  { path: 'hive/:hiveId/section/:id', component: HiveSectionFormComponent },
  { path: 'classes', component: ClassListComponent },
  { path: 'subclasses', component: SubClassListComponent },
  { path: 'class', component: ClassFormComponent },
  { path: 'subclass', component: SubClassFormComponent },
  { path: 'class/:id', component: ClassFormComponent },
  { path: 'class/:id/subclasses', component: SubClassListComponent },
  { path: 'class/:sid/subclass', component: SubClassFormComponent },
  { path: 'class/:sid/subclass/:id', component: SubClassFormComponent},
  
  { path: 'clients', component: ClientListComponent },
  { path: 'order', component: OrderFormComponent },
  { path: 'orders', component: OrderListComponent },
  { path: 'client', component: ClientFormComponent },
  { path: 'client/:id', component: ClientFormComponent },
  { path: 'client/:id/orders', component: OrderListComponent },
  { path: 'client/:sid/order', component: OrderFormComponent },
  { path: 'client/:sid/order/:id', component: OrderFormComponent},
  { path: 'image', component: ImageFormComponent },
  { path: 'images', component: ImageListComponent },
  { path: 'image/:id', component: ImageFormComponent },
  { path: 'shipper', component: ShipperFormComponent },
  { path: 'shippers', component: ShipperListComponent },
  { path: 'shipper/:id', component: ShipperFormComponent },
  { path: 'client/:clientId/order/:orderId/shipper/:shipperId', component: ShipperFormComponent },
  { path: 'client/:clientId/order/:orderId/shipper', component: ShipperFormComponent },
  { path: 'client/:mid/order/:gid/shippers', component: ShipperListComponent },
  { path: 'transports', component: TransportListComponent},
  { path: 'transport', component: TransportFormComponent},
  { path: 'transports/:id', component: TransportFormComponent},
  { path: 'modes', component: ModeListComponent},
  { path: 'mode', component: ModeFormComponent},
  { path: 'modes/:id', component: ModeFormComponent},
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule { }
