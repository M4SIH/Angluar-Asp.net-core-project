import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { FormsModule } from '@angular/forms';

import {MatGridListModule} from '@angular/material/grid-list';
import {MatButtonModule} from '@angular/material/button';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatDialogModule} from '@angular/material/dialog';
import {MatInputModule} from '@angular/material/input';
import {MatDividerModule} from '@angular/material/divider';
import {MatIconModule} from '@angular/material/icon';
import {MatSelectModule} from '@angular/material/select';

import { UsersComponent } from './users/users.component';
import { UserComponent } from './users/user/user.component';
import { DatagridComponent } from './shared/datagrid/datagrid.component';
import { ManagersComponent } from './managers/managers.component';
import { CoursesComponent } from './courses/courses.component';




@NgModule({
  declarations: [
    AdminComponent,
    UsersComponent,
    UserComponent,
    DatagridComponent,
    ManagersComponent,
    CoursesComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    AdminRoutingModule,
    MatGridListModule,
    MatButtonModule,
    MatFormFieldModule,
    MatDialogModule,
    MatInputModule,
    MatDividerModule,
    MatIconModule,
    MatSelectModule
  ]
})
export class AdminModule { }
