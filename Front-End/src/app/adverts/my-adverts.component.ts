import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '@app/_models/product';
import { AdvertsService } from '@app/_services';

@Component({ templateUrl: 'my-adverts.component.html' })
export class MyAdvertsComponent
{
  pageTitle = 'My Adverts';
  errorMessage : string;  
  filteredProducts: Product[] = [];
  products: Product[] = [];

  successMessage: string;
  productForm: FormGroup;
  product: Product;

  constructor(private productService: AdvertsService,
              private router: Router,
              private route: ActivatedRoute) {}
  

  ngOnInit(): void 
  {
    this.productService.getProducts().subscribe({
      next: products => {
        this.products = products;
       
      },
      error: err => this.errorMessage = err
    });    
  }
 
    addAdvert() : void
    {
      this.router.navigate(['/products/0/edit']);
    }
    
    //For the SUB LIST OF Buttons
    showDiv = 
    {
      previous : false,
    }
 
}