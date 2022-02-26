import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-managers',
  templateUrl: './managers.component.html',
  styleUrls: ['./managers.component.scss']
})
export class ManagersComponent implements OnInit {

  gridReload:boolean=false;
  
  constructor() { }

  gridColumns=[
    {
      title:'نام و نام خانوادگی',
      field:'fullname'
    },
    {
      title:'نام کاربری',
      field:'accountUsername'
    },
    {
      title:'سمت',
      field:'type'
    }
  ];

  ngOnInit(): void {
  }

}
