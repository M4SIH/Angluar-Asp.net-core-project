import { ThisReceiver } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { LoginComponent } from '../login/login.component';
import { AuthenticationService } from '../services/authentication.service';
import { BackendService } from '../services/backend.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {

  constructor(private backend:BackendService , public auth:AuthenticationService , public dialog: MatDialog , private router: Router) { }

  courses:any[];


  ngOnInit(): void {
    this.backend.secureGet("shop/courseList").subscribe(result=>
      {
        this.courses=result;
        console.log(result);
      })
  }
  subscribe(id){
    if(!this.auth.loggedIn()){
      const dialogRef = this.dialog.open(LoginComponent,{
        width: '300px',
        height:'500px'
      });
    }
    if (this.auth.loggedIn() && this.auth.getCurrentUser().user) {
      this.router.navigate(['shopContext']);
    }
    this.backend.securePost('shop/subscribe/'+id,{}).subscribe(result=>
      {
        this.courses.filter(c=>c.id==id)[0].canSubscribe=false;
        console.log(result);
      });
  }
  // courseContext(item){
  //   console.log(item);
  // }



}
