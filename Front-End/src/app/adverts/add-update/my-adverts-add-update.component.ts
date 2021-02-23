import { Component, OnInit, AfterViewInit, OnDestroy, ViewChildren, ElementRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControlName } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, Subscription, fromEvent, merge } from 'rxjs';
import { debounceTime } from 'rxjs/operators';
import { GenericValidator } from '../../other/generic-validator'
import { Advert, City, Provinces } from '@app/models';
import { AccountService, AdvertsService, ProvinceCitiesService } from '@app/services';

@Component({
  templateUrl: './my-adverts-add-update.component.html',
  styleUrls: ['./my-adverts-add-update.component.css'],
})

export class AdvertsAddUpdateComponent implements OnInit, AfterViewInit, OnDestroy {
  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  pageTitle = 'Advert Edit';
  errorMessage: string;
  successMessage: string;
  myAdvertForm: FormGroup;
  
  adverts: Advert;
  private sub: Subscription;
  provinces: Provinces[];  
  cities: City[];  

  // Use with the generic validation message class
  displayMessage: { [key: string]: string } = {};
  private validationMessages: { [key: string]: { [key: string]: string } };
  private genericValidator: GenericValidator;

  constructor(private fb: FormBuilder,
              private route: ActivatedRoute,
              private advertService: AdvertsService,
              private accountService: AccountService,
              private provincesAndCitiesService: ProvinceCitiesService) {

    this.validationMessages = {
      advertHeadlineText: {
        required: 'Advert Headline text is required.',
        minlength: 'Advert Headline text must be at least 10 characters.',
        maxlength: 'Advert Headline text cannot exceed 100 characters.'
      },
      advertDetail: {
        required: 'Advert Details is required.',
        minlength:  'Advert Details must be at least 10 characters.',
        maxlength: 'Advert Details cannot exceed 1000 characters.'
      },
      status : {
        required : "It's Required to choose your Advert Status."
      },
      price : {
        required : "Price is Required.",
        min: "Price must be at least 10000.",
        max: "Price cannot exceed 100000000."
      },
      province : {
        required : "Province is Required."
      },
      city: {
        required: "City is Required." 
     }     
    };
    this.genericValidator = new GenericValidator(this.validationMessages);  
  }

  ngOnInit(): void {
    this.myAdvertForm = this.fb.group({
      advertHeadlineText: ['', [Validators.required,  Validators.minLength(10), Validators.maxLength(100)]],
      advertDetail: ['',[Validators.required, Validators.minLength(10), Validators.maxLength(1000)]],
      status : ['', [Validators.required]],
      price : ['',[Validators.required, Validators.min(10000), Validators.max(100000000)]],
      provinceId : ['',Validators.required],
      cityId : ['',Validators.required]
    });

    this.sub = this.route.paramMap.subscribe(
      params => {
        const id = +params.get('id');
        this.getMyAdvert(id);
      }
    );

    this.provincesAndCitiesService.getProvinces().subscribe(
      (res : Provinces[]) => {
        this.provinces = res;
      },
      errorMessage => {
        this.errorMessage = 'Something went wrong';
      }
    );  
  }

  onSelect(provinceId): void {
    this.provincesAndCitiesService.getCities(provinceId).subscribe(
      (res : City[]) => {
        this.cities = res;
      },
      errorMessage => {
        this.errorMessage = 'Something went wrong';
      }
    )          
  }
  
  ngAfterViewInit(): void  {
    const controlBlurs: Observable<any>[] = this.formInputElements
      .map((formControl: ElementRef) => fromEvent(formControl.nativeElement, 'blur'));
       merge(this.myAdvertForm.valueChanges, ...controlBlurs).pipe(
       debounceTime(800)
       ).subscribe(value => {
       this.displayMessage = this.genericValidator.processMessages(this.myAdvertForm);
    });
  }

  getMyAdvert(id: number): void  {
    this.advertService.getAdvert(id)
      .subscribe({
        next: (advert: Advert) => {
          this.displayAdvert(advert)
        },
        error: err => {
          this.errorMessage = err
        }
      });
  }

  displayAdvert(advert: Advert): void {
    if (this.myAdvertForm) {
      this.myAdvertForm.reset();
    }
    this.adverts = advert;

    if (this.adverts.id === 0) {
      this.pageTitle = 'Add a new Advert';
    } else {
      this.pageTitle = `Edit Advert: ${this.adverts.advertHeadlineText}`;
    }

    // Update the data on the form
    this.myAdvertForm.patchValue({
      advertHeadlineText: this.adverts.advertHeadlineText,
      advertDetail: this.adverts.advertDetail,
      price: this.adverts.price,
      status : this.adverts.status,
      userId : this.adverts.userId,
      provinceId : this.adverts.provinceId,
      cityId : this.adverts.cityId,
    });
  }

  deleteMyAdvert(): void {
    if (this.adverts.id === 0) {
      this.onSaveComplete();
    } else {   
      this.advertService.deleteAdvert(this.adverts.id)
        .subscribe({
          next: () => {
            this.onSaveComplete();
            this.successMessage = "Deleted Successfully! "
          },
            error: err => {
              this.errorMessage = "Error trying to Delete advert"
            }
        });
    }
  }

  saveAdvert(): void {
    if (this.myAdvertForm.valid) {

      if (this.myAdvertForm.dirty) {

        const p = { ...this.adverts, ...this.myAdvertForm.value, };

        if (p.id === 0 && this.accountService.userValue.id) {
          this.advertService.createAdvert(p)
            .subscribe({
              next: () => {
                this.successMessage = "Created Successfully! ";
              },
              error: err => this.errorMessage = "Can't Save to database"
            });
        } else {
          this.advertService.updateAdvert(p)
            .subscribe({
              next: () => {
                this.successMessage = "Updated Succesfully!";
              },
              error: err => {
                this.errorMessage = "Can't update to database";
              }
            });
         }
      } else {
        this.onSaveComplete();
        }
    } else {
      this.errorMessage = 'Please correct the validation errors.';
    }
  }

  onSaveComplete(): void  {
    this.myAdvertForm.reset();
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

}
