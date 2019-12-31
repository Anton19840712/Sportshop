import { Component, OnInit } from '@angular/core';
import { ProductCategoryListItem } from '../models/product-category-list-item';
import { ProductCategoryService } from '../services/product-category.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-product-category-list',
  templateUrl: './product-category-list.component.html',
  styleUrls: ['./product-category-list.component.css']
})
export class ProductCategoryListComponent implements OnInit {

  selectedProductCategory: ProductCategoryListItem;
  productCategories: ProductCategoryListItem[] = [];
  columnsToDisplay = ['id', 'name', 'code', 'productCount', 'lastUpdated', 'actionButtons'];

  constructor(
    private productCategoryService: ProductCategoryService,
    private toastr: ToastrService
    ) { }

  ngOnInit() {
    this.getProductCategories();
  }

  onSelect(productCategory: ProductCategoryListItem): void {
    this.selectedProductCategory = productCategory;
  }

  getProductCategories(): void {
    this.productCategoryService.getProductCategories().subscribe(c => {
      this.productCategories = c;
      this.toastr.info("Product categories list");
    });
  }
}
