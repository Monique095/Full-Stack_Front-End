import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Advert } from '@app/models';
import { AdvertsService } from '@app/services';

@Component({
  templateUrl: './home-for-sale-detail.component.html',
  styleUrls: ['./home-for-sale-detail.component.css']
})

export class HomeForSaleDetailComponent implements OnInit {

    errorMessage = '';
    advert: Advert | undefined;

    constructor(private route: ActivatedRoute,
                private router: Router,
                private advertService: AdvertsService) {}

    ngOnInit(): void {
        const param = this.route.snapshot.paramMap.get('id');
        if (param) {
            const id = +param;
            this.getAdvert(id);
        } else {
            this.errorMessage = "No Data"
        }
    }

    getAdvert(id: number): void {
        this.advertService.getAdvert(id).subscribe({
            next: advertInfo => {
                this.advert = advertInfo
            },
            error: err => {
                this.errorMessage = err;
            }
        });
    }

    goBack(): void {
        this.router.navigate(['/adverts']);
    }
}