import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { JwtInterceptor, ErrorInterceptor } from './_helpers';
import { AppComponent } from './app.component';
import { AlertComponent } from './_components';
import { HomeComponent } from './home';
import { MyAdvertsComponent } from './adverts/my-adverts.component';
import { AdvertsAddEditComponent } from './adverts/my-adverts-add_edit.component';
import { SelectService } from './_services';
import { AdvertListComponent } from './adverts/advert.list.component';

@NgModule({
    imports: [
        BrowserModule,
        ReactiveFormsModule,
        HttpClientModule,
        AppRoutingModule,
    ],
    declarations: [
        AppComponent,
        AlertComponent,
        HomeComponent,
        MyAdvertsComponent,
        AdvertsAddEditComponent,
        AdvertListComponent

    ],
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
        
        SelectService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { };