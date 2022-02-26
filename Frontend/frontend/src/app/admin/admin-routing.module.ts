import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AdminComponent } from './admin.component';
import { CoursesComponent } from './courses/courses.component';
import { ManagersComponent } from './managers/managers.component';
import { UsersComponent } from './users/users.component';

const routes: Routes = [
  { path: '', component: AdminComponent , children:[
  ]},
  {path:'usersList' , component:UsersComponent},
  {path:'managersList' , component:ManagersComponent},
  {path:'coursesList', component:CoursesComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
