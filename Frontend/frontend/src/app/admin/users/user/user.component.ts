import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { BackendService } from 'src/app/services/backend.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {
  entity:any;
  constructor(public dialogRef: MatDialogRef<UserComponent>,private backend:BackendService,
    @Inject(MAT_DIALOG_DATA) public data: any) {
      this.entity=data.entity;
    }

  ngOnInit(): void {
    // this.entity={};
    // this.entity.account={};

  }
  ok(){
    if (this.data.action=='create') {
      this.entity.account.username=this.entity.accountUsername;
      this.backend.post('users/create', this.entity).subscribe(result=>{
        this.dialogRef.close();
      },
      error=>{

      });
    }
    else if(this.data.action=='edit') {
      this.entity.account.username=this.entity.accountUsername;
      this.backend.post('users/update/'+this.entity.accountUsername, this.entity).subscribe(result=>{
        this.dialogRef.close();
      },
      error=>{

      });
    }
    else if(this.data.action=='delete') {
      this.entity.account.username=this.entity.accountUsername;
      this.backend.get('users/delete/'+this.entity.accountUsername).subscribe(result=>{
        this.dialogRef.close();
      },
      error=>{

      });
    }
  }
}
