import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.scss']
})
export class CoursesComponent implements OnInit {

  gridReload:boolean=false;

  constructor() { }

  gridColumns=[
    {
      title:'نام دوره',
      field:'title'
    },
    {
      title:'توضیحات دوره',
      field:'description'
    },
    {
      title:'مدت زمان عملی',
      field:'practicalTime'
    },
    {
      title:'مدت زمان تئوری',
      field:'theoryTime'
    }
  ];

  ngOnInit(): void {
  }

}
