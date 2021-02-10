import { Injectable } from '@angular/core';
import { CanDeactivate } from '@angular/router';
import { Observable } from 'rxjs';
import { AdvertsAddEditComponent } from '../adverts/my-adverts-add_edit.component';

@Injectable({
  providedIn: 'root'
})

export class ProductEditCreateGuard implements CanDeactivate<AdvertsAddEditComponent> 
{
  canDeactivate(component: AdvertsAddEditComponent): Observable<boolean> | Promise<boolean> | boolean 
  {
    if (component.productForm.dirty) 
    {
      const advertHeadlineText = component.productForm.get('advertHeadlineText').value || 'New Product';
      return confirm(`Navigate away and lose all changes to ${advertHeadlineText}?`);
    }
    return true;
  }
}
