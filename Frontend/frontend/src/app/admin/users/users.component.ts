import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { BackendService } from 'src/app/services/backend.service';
import { UserComponent } from './user/user.component';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {
  // data:any[];
  // count:number=0;
  // page=0;
  // pageSize=10;
  // filter:any;
  gridReload:boolean=false;
  constructor(private backend:BackendService , public dialog: MatDialog ) { }

  gridColumns=[
    {
      title:'نام و نام خانوادگی',
      field:'fullname'
    },
    {
      title:'نام کاربری',
      field:'accountUsername'
    }
  ];

  ngOnInit(): void {

  }
  // loadData(){
  //   this.backend.post('users/list',{page:this.page,pageSize:this.pageSize,filter:this.filter}).subscribe(result=>{
  //     this.data=result.data;
  //     this.count=result.count;
  //   });
  // }
  // reloadData(){
  //   this.page=0;
  //   this.loadData();
  // }
  createDialog(): void {
    var user:any={};
    user.account={};
    const dialogRef = this.dialog.open(UserComponent, {
      data:{entity:user, action:'create'}
    });

    dialogRef.afterClosed().subscribe(result => {
      // this.loadData();
      this.gridReload=!this.gridReload;
    });
  }
  editDialog(username): void {
    console.log(username);
    this.backend.get('users/get/'+username).subscribe(result=>{
      console.log(result);
      var user:any=result;

      const dialogRef = this.dialog.open(UserComponent, {
        data:{entity:user , action:'edit'}
      });

      dialogRef.afterClosed().subscribe(result => {
        // this.loadData();
        this.gridReload=!this.gridReload;
      });
    });

  }
  deleteDialog(username): void {
    console.log(username);
    this.backend.get('users/get/'+username).subscribe(result=>{
      console.log(result);
      var user:any=result;

      const dialogRef = this.dialog.open(UserComponent, {
        data:{entity:user , action:'delete'}
      });

      dialogRef.afterClosed().subscribe(result => {
        // this.loadData();
        this.gridReload=!this.gridReload;
      });
    });

  }
  // nextPage(){
  //   this.page++;
  //   this.loadData();
  // }
  // prevPage(){
  //   this.page--;
  //   this.loadData();
  // }
  // pageSizeChange(){
  //   this.loadData();
  // }
  edit(row){
    this.editDialog(row.accountUsername);
  }
  remove(row){
    this.deleteDialog(row.accountUsername);
  }
  add(){
    this.createDialog();
  }
}

