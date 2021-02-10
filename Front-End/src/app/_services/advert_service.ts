import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Product } from '../_models/product';
import { Observable, of, throwError } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import { environment } from '@environments/environment';

@Injectable({
    providedIn: 'root'
  })
  
  export class AdvertsService 
  {
    constructor(public http: HttpClient) { }

  getProducts(): Observable<Product[]> 
  {
    return this.http.get<Product[]>(`${environment.apiUrl}/adverts`)
      .pipe(
        tap(data => console.log(JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  getProduct(id: number) : Observable<Product> 
  {
    if (id === 0) {
      return of(this.initializeProduct());
    }
    return this.http.get<Product>(`${environment.apiUrl}/adverts/${id}`)
      .pipe(
        tap(data => console.log('getProduct: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  
  createProduct(post)
  { 
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<Product>(`${environment.apiUrl}/adverts/createProduct`, post, {headers})
      .pipe(
        tap(data => console.log('createProduct: ' + JSON.stringify(data))),
        map(res => res), 
        catchError(this.handleError)
      );
  }


  deleteProduct(id: number): Observable<{}> 
  {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${environment.apiUrl}/adverts/${id}`
    return this.http.delete<Product>(url, { headers })
      .pipe(
        tap(data => console.log('deleteProduct: ' + id)),
        catchError(this.handleError)
      );
  }

  updateProduct(product: Product): Observable<Product> 
  {
    const url = `${environment.apiUrl}/adverts/${product.id}`;
    return this.http.put<Product>(url, product,)
      .pipe(
        tap(() => console.log('updateProduct - Id: ' + product.id)),
        catchError(this.handleError)
      );
  }
    
  public handleError(err): Observable<never> 
  {
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
  
  public initializeProduct(): Product 
    {
      return {
        id: 0,
        advertHeadlineText: null,
        province: null,
        city: null,
        advertDetail: null,
        price: null,
        status: null,

      };
    }
    
  }