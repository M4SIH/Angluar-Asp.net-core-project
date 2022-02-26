import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminGuard } from './admin.guard';
import { MainPgeComponent } from './main-pge/main-pge.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { RegisterComponent } from './register/register.component';
import { ShopContextComponent } from './shop-context/shop-context.component';
import { ShopComponent } from './shop/shop.component';

const routes: Routes = [
  {path:'shop', component:ShopComponent,
    children:[]},
  {path:'shopContext/:id',component:ShopContextComponent},
  {path:'register' , component:RegisterComponent},
  {path:'main-pge',component:MainPgeComponent},
  {path: '', redirectTo: '/main-pge', pathMatch: 'full'},
  {path: 'admins',canLoad:[AdminGuard], loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule) },
  {path:'**',component:PageNotFoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
