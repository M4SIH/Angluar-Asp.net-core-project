import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { BackendService } from '../services/backend.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  username:any;
  password:any;
  keepMe:boolean=false;
  constructor(private backend:BackendService, public dialogRef: MatDialogRef<LoginComponent>) { }

  ngOnInit(): void {
  }
  check(){
    this.backend.post('authentication/Login',{username:this.username,password:this.password})
      .subscribe(res=>{
          sessionStorage.setItem('isOk','true');
          const account=res.account;
          const token=res.token;
          sessionStorage.setItem('user',JSON.stringify(account));
          sessionStorage.setItem('token',token);
          if(this.keepMe){
            localStorage.setItem('isOk','true');
            localStorage.setItem('user',JSON.stringify(account));
            sessionStorage.setItem('token',token);
          }
          this.dialogRef.close();
      },error=>{
        console.log(error);
      });

  }
}
