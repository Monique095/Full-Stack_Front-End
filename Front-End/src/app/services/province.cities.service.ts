import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, tap } from 'rxjs/operators';
import { environment } from '@environments/environment';
import { City, Provinces } from '@app/models';

@Injectable({
    providedIn: 'root'
  })
  
export class ProvinceCitiesService {
  
  constructor(private http: HttpClient) {}

  getProvinces() {
    return this.http.get<Provinces[]>(`${environment.apiUrl}/province`)
    .pipe(
      tap(data => console.log(JSON.stringify(data))),
    );
  }

  getCities(provinceId : number) {
    return this.http.get<City[]>(`${environment.apiUrl}/city`)
    .pipe(
      tap(data => console.log(JSON.stringify(data))),
        map(result =>
          result.filter(one => one.provinceId === provinceId)
    ))
  }
}