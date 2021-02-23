import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { JwtInterceptor, ErrorInterceptor } from './helpers';
import { AppComponent } from './app.component';
import { MyAdvertsComponent } from './adverts/my-adverts/my-adverts.component';
import { AdvertsAddUpdateComponent } from './adverts/add-update/my-adverts-add-update.component';
import { HomeForSaleComponent } from './homes-for-sale/home/home-for-sale.component';
import { HomeForSaleDetailComponent } from './homes-for-sale/detail/home-for-sale-detail.component';

@NgModule({
    imports: [
        BrowserModule,
        ReactiveFormsModule,
        HttpClientModule,
        AppRoutingModule,
 
    ],
    declarations: [
        AppComponent,
        MyAdvertsComponent,
        AdvertsAddUpdateComponent,
        HomeForSaleComponent,
        HomeForSaleDetailComponent

    ],
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
        
    ],
    bootstrap: [AppComponent]
})
export class AppModule { };