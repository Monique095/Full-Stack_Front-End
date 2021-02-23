import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Advert } from '../models/advert';
import { Observable, of, throwError } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import { environment } from '@environments/environment';
import { AccountService } from './account.service';

@Injectable({
    providedIn: 'root'
  })
  
export class AdvertsService {
  
  constructor(public http: HttpClient, private accountService : AccountService) { }

  getAdverts(): Observable<Advert[]> {
    return this.http.get<Advert[]>(`${environment.apiUrl}/adverts`)
      .pipe(
        tap(data => console.log(JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  getAdertById(): Observable<Advert[]> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.get<Advert[]>(`${environment.apiUrl}/adverts/myads`, {headers})
      .pipe(
        tap(data => console.log(JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  getAdvert(id: number) : Observable<Advert> {
    if (id === 0) {
      return of(this.initializeAdvert());
    }
    return this.http.get<Advert>(`${environment.apiUrl}/adverts/${id}`)
      .pipe(
        tap(data => console.log('Get Advert: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }
  
  createAdvert(post) { 
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<Advert>(`${environment.apiUrl}/adverts`, post, {headers})
      .pipe(
        tap(data => console.log('Create Advert: ' + JSON.stringify(data))),
        map(res => res), 
        catchError(this.handleError)
      );
  }

  deleteAdvert(id: number): Observable<{}> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${environment.apiUrl}/adverts/${id}`
    return this.http.delete<Advert>(url, { headers })
      .pipe(
        tap(data => console.log('Delete Advert: ' + id)),
        catchError(this.handleError)
      );
  }
    
  updateAdvert(advert) {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${environment.apiUrl}/adverts/${advert.id}`;
    return this.http.put<Advert>(url, advert, { headers })
      .pipe(
        tap(() => console.log('Update Advert - Id: ' + advert.id)),
        map(() => advert),
        catchError(this.handleError)
      );
  }

  public handleError(err): Observable<never>  {
    let errorMessage: string;
    if (err.error instanceof ErrorEvent) 
    {
      errorMessage = `An error occurred: ${err.error.message}`;
    } else 
    {
      errorMessage = `Backend returned code ${err.status}: ${err.body.error}`;
    }
    console.error(err);
    return throwError(errorMessage);
  }
  
  public initializeAdvert(): Advert {
      return {
        id: 0 ,
        advertHeadlineText: null,
        advertDetail: null,
        provinceId : null,
        cityId : null,   
        price: null,
        status: null,
        userId: this.accountService.userValue.id, 
      };
  }
  
}