import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { AuthenticationService } from './services/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'frontend';
  currentUser:any;
  constructor(public dialog: MatDialog , private router: Router , public auth:AuthenticationService) {}

  ngOnInit(): void {
    if(localStorage.getItem('isOk')=='true'){
      sessionStorage.setItem('isOk','true');
      sessionStorage.setItem('user',localStorage.getItem('user'));
      this.currentUser=JSON.parse(sessionStorage.getItem('user'));
    }
    if(this.auth.loggedIn){
      this.currentUser=JSON.parse(sessionStorage.getItem('user'));
    }
  }
  openDialog() {
    const dialogRef = this.dialog.open(LoginComponent, {
      width: '300px',
      height:'500px',
      data: {}
    });
    dialogRef.afterClosed().subscribe(result => {
      if(this.auth.loggedIn){
        this.currentUser=JSON.parse(sessionStorage.getItem('user'));
      }
    });
  }

  signOut(){
    sessionStorage.clear();
    localStorage.clear();
    this.currentUser=undefined;
    this.router.navigate(['/main-pge']);
  }
  // display(){
  //   const user:any=JSON.parse(sessionStorage.getItem('user'));
  //   console.log(user.manager);
  //   if(user.user){
  //     return user.intern.fullname+('خروج');
  //   }
  //   if(user.Writer){
  //     return user.Writer.fullname;
  //   }
  //   if(user.manager){
  //     return user.manager.fullname;
  //   }
  //   return 'ناشناس';
  // }
}
