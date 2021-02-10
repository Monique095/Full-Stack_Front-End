import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdvertsAddEditComponent } from './adverts/my-adverts-add_edit.component';
import { MyAdvertsComponent } from './adverts/my-adverts.component';
import { HomeComponent } from './home';
import { AuthGuard } from './_helpers';
import { ProductEditCreateGuard } from './_guards/add-edit.guard';
import { AdvertListComponent } from './adverts/advert.list.component';

const accountModule = () => import('./account/account.module').then(x => x.AccountModule);

const routes: Routes = [
    { path: '', component: HomeComponent, canActivate: [AuthGuard] },
    // { path: 'users', loadChildren: usersModule, canActivate: [AuthGuard] },
    { path: 'account', loadChildren: accountModule },
    { path: 'home', component: HomeComponent},
    { path: 'my-products', component: MyAdvertsComponent },
    { path: 'products/:id/edit', component: AdvertsAddEditComponent, canDeactivate: [ProductEditCreateGuard] }, 
    { path: 'products ', component: AdvertListComponent},
    
    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }