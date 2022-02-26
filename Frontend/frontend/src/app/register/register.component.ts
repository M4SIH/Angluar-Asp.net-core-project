import { HttpClient} from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ErrorsDialogComponent } from '../errors-dialog/errors-dialog.component';
import { BackendService } from '../services/backend.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  user:any;
  message:string|undefined;
  done:boolean=false;
  constructor(private backend:BackendService , private router: Router, public dialog: MatDialog) { }

  ngOnInit(): void {
    this.user={}
    this.user.account={}
  }
  register(){
    this.backend.post('users/register',this.user)
      .subscribe(res=>{
        if (res['message']=='Ok') {
          this.done=true;
          // setTimeout(() => {
          //   this.router.navigate(['/register']);
          // }, 5000);
          this.router.navigate(['/main-pge']);
        }
      },error=>{
        this.message=error['error']['message'];
        this.dialog.open(ErrorsDialogComponent)
      });

  }
}
