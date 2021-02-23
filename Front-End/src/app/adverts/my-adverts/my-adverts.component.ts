import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Advert } from '@app/models/advert';
import { AccountService, AdvertsService } from '@app/services';

@Component({ 
  templateUrl: 'my-adverts.component.html',
  styleUrls: ['./my-adverts.component.css'],
})

export class MyAdvertsComponent implements OnInit{

  pageTitle = 'Welcome ' + this.accountService.userValue.firstName + ' ' + this.accountService.userValue.lastName;
  errorMessage : string;  
  adverts: Advert[];
  myAdvertForm: FormGroup;

  constructor(private advertService: AdvertsService,
              private accountService : AccountService) {}
  
  ngOnInit(): void {
    this.advertService.getAdertById().subscribe({
      next: advertInfo => {
        this.adverts = advertInfo;
      },
      error: err => {
        this.errorMessage = err;
      }
    });
  }

}                      