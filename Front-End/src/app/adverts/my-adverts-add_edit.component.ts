import { Component, OnInit, AfterViewInit, OnDestroy, ViewChildren, ElementRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControlName } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, Subscription, fromEvent, merge } from 'rxjs';
import { debounceTime } from 'rxjs/operators';
import { Product } from '../_models/product';
import { AdvertsService } from '../_services/advert_service';
import { GenericValidator } from '../_other/generic-validator';
import { Provinces } from '@app/_models';
import { AlertService, SelectService } from '@app/_services';
import { removeSpaces } from '@app/account/register.component';

@Component({
  templateUrl: './my-adverts-add_edit.component.html',
})

export class AdvertsAddEditComponent implements OnInit, AfterViewInit, OnDestroy {
  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  pageTitle = 'Advert Edit';
  errorMessage: string;
  successMessage: string;
  productForm: FormGroup;

  product: Product;
  private sub: Subscription;
  provinces: Provinces[];
  cities: {};
  selectedCountry: Provinces = new Provinces(2, 'Brazil');

  // Use with the generic validation message class
  displayMessage: { [key: string]: string } = {};
  private validationMessages: { [key: string]: { [key: string]: string } };
  private genericValidator: GenericValidator;

  constructor(private fb: FormBuilder,
              private route: ActivatedRoute,
              private productService: AdvertsService,
              private router: Router,
              private selectService : SelectService ) {

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
      price :
      {
        maxlength: 'Price cannot exceed 100000000 characters.'
      },
     province : {
       required : "It's Required to select a Province"
     },
     city : {
       required: "It's Required to select a City"
     },
     status : {
       required : "It's Required to choose your Advert Status"
     }
     
    };
    this.genericValidator = new GenericValidator(this.validationMessages);
  }

  ngOnInit(): void 
  {
    this.productForm = this.fb.group({
      advertHeadlineText: ['', [Validators.required,  Validators.minLength(10), Validators.maxLength(100)]],
      advertDetail: ['',[Validators.required, Validators.minLength(10), Validators.maxLength(1000)]],
      price: ['',[Validators.maxLength(100000000), removeSpaces]],
      province : ['', [Validators.required]],
      city : ['', [Validators.required]],
      status : ['', [Validators.required]],
     
    });

    this.sub = this.route.paramMap.subscribe(
      params => {
        const id = +params.get('id');
        this.getProduct(id);
      }
    );

    //Drop Down List 
    this.provinces = this.selectService.getProvinces();
    this.onSelect(this.selectedCountry.id);

    }

    onSelect(provincename) {
      this.cities = this.selectService.getCities().filter((item) => item.provincename == provincename);
    }

  ngOnDestroy(): void 
  {
    this.sub.unsubscribe();
  }

  ngAfterViewInit(): void 
  {
    const controlBlurs: Observable<any>[] = this.formInputElements
      .map((formControl: ElementRef) => fromEvent(formControl.nativeElement, 'blur'));
       merge(this.productForm.valueChanges, ...controlBlurs).pipe(
       debounceTime(800)
       ).subscribe(value => {
       this.displayMessage = this.genericValidator.processMessages(this.productForm);
    });
  }


  getProduct(id: number): void 
  {
    this.productService.getProduct(id)
      .subscribe({
        next: (product: Product) => this.displayProduct(product),
        error: err => this.errorMessage = err
      });
  }

  displayProduct(product: Product): void
  {
    if (this.productForm) {
      this.productForm.reset();
    }
    this.product = product;

    if (this.product.id === 0) {
      this.pageTitle = 'Add a new Advert';
    } else {
      this.pageTitle = `Edit Advert: ${this.product.advertHeadlineText}`;
    }

    // Update the data on the form
    this.productForm.patchValue({
      advertHeadlineText: this.product.advertHeadlineText,
      advertDetail: this.product.advertDetail,
      province: this.product.province,
      city: this.product.city,
      price: this.product.price,
      status : this.product.status
    });
  }

  deleteProduct(): void 
  {
    if (this.product.id === 0) 
    {
      this.onSaveComplete();
    } 
    else 
    {
      if (confirm(`Are you sure you want to delete ${this.product.advertHeadlineText} Advert? This cannot be undone, are you sure you want to continue? `)) 
      {
        this.productService.deleteProduct(this.product.id)
          .subscribe({
            next: () => this.successMessage = "Deleted Successfully! ",
            error: err => this.errorMessage = "Error trying to Delete advert"
          });
      }
    }
  }

  saveProduct(): void 
  {
    if (this.productForm.valid) 
    {
      if (this.productForm.dirty) 
      {
        const p = { ...this.product, ...this.productForm.value };

        if (p.id === 0) 
        {
          this.productService.createProduct(p)
            .subscribe({
              next: () => this.successMessage = "Created Successfully! ",
              error: err => this.errorMessage = "Can't Save to database"
            });
        } 
        else 
        {
          this.productService.updateProduct(p)
            .subscribe({
              next: () => this.successMessage = "Updated Succesfully!",
              error: err => this.errorMessage = "Can't update to database"
            });
        }
      } 
      else 
      {
        this.onSaveComplete();
      }
    } 
    else 
    {
      this.errorMessage = 'Please correct the validation errors.';
    }
  }

  onSaveComplete(): void 
  {
    // Reset the form to clear the flags
    this.productForm.reset();
    this.router.navigate(['/my-products']);
  }

  //For the Price
  numberOnly(event): boolean {
    const charCode = (event.which) ? event.which : event.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
      return false;
    }
    return true;
  }


}
