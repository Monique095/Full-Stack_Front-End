import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdvertsAddUpdateComponent } from './adverts/add-update/my-adverts-add-update.component';
import { MyAdvertsComponent } from './adverts/my-adverts/my-adverts.component';
import { AuthGuard } from './helpers';
import { HomeForSaleComponent } from './homes-for-sale/home/home-for-sale.component';
import { HomeForSaleDetailComponent } from './homes-for-sale/detail/home-for-sale-detail.component';

const accountModule = () => import('./account/routing-module/account.module').then(x => x.AccountModule);

const routes: Routes = [
    { path: '', component: HomeForSaleComponent, canActivate: [AuthGuard] },
    { path: 'account', loadChildren: accountModule },
    { path: 'adverts', component: HomeForSaleComponent},
    { path: 'my-adverts', component: MyAdvertsComponent },
    { path: 'adverts/:id/edit', component: AdvertsAddUpdateComponent }, 
    { path: 'adverts/:id', component: HomeForSaleDetailComponent },

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }