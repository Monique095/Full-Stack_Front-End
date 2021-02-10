import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from '@app/_models';
import { AdvertsService } from '../_services/advert_service';

@Component({
  templateUrl: './advert.list.component.html'
})
export class AdvertListComponent implements OnInit {
    pageTitle = 'Browse All Adverts';
    loggedInUser: string;
    errorMessage = '';

    filteredProducts: Product[] = [];
    products: Product[] = [];
  
    constructor(private productService: AdvertsService,
                private router: Router) { }
                
                ngOnInit(): void 
                {
                  this.productService.getProducts().subscribe({
                    next: products => {
                      this.products = products;
                      this.filteredProducts = this.products;
                    },
                    error: err => this.errorMessage = err
                  });
                }
}