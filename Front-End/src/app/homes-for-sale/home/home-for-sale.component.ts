import { Component } from '@angular/core';
import { Advert } from '@app/models';
import { AdvertsService } from '@app/services';

@Component({ 
  templateUrl: 'home-for-sale.component.html',
  styleUrls: ['./home-for-sale.component.css']
})

export class HomeForSaleComponent {

  pageTitle = 'Property for Sale';
  errorMessage = '';
  adverts: Advert[] = [];
  
  constructor(private advertService: AdvertsService) { }
                
  ngOnInit(): void {
    this.advertService.getAdverts().subscribe({
      next: advertInfo => {
      this.adverts = advertInfo;
      },
      error: err => this.errorMessage = err
      }
    );

    this.adverts = this.adverts.sort((low, high) => low.price - high.price);
  }

//For the Prices to Short from High - Low || From Low - High

  sort(event: any) {
    switch (event.target.value) {
      case "Low": {
        this.adverts = this.adverts.sort((low, high) => low.price - high.price);
        break;
      }         
      case "High": {
        this.adverts = this.adverts.sort((low, high) => high.price - low.price);
        break;
      }                    
      default: {
        this.adverts = this.adverts.sort((low, high) => low.price - high.price);
        break;
      }   
    }
      return this.adverts;            
  }                            
}