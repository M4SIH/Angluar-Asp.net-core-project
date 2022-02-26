import { Component, EventEmitter, Inject, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { BackendService } from 'src/app/services/backend.service';
import { UserComponent } from '../../users/user/user.component';


@Component({
  selector: 'app-datagrid',
  templateUrl: './datagrid.component.html',
  styleUrls: ['./datagrid.component.scss']
})
export class DatagridComponent implements OnInit , OnChanges {

  @Input() columns:any[];
  @Input() source:string;
  @Input() needReload:boolean=false;
  @Output() onEdit:EventEmitter<any>=new EventEmitter();
  @Output() onRemove:EventEmitter<any>=new EventEmitter();
  @Output() onAdd:EventEmitter<any>=new EventEmitter();

  filter:any;
  data:any[];
  count:number=0;
  page=0;
  pageSize=10;

  constructor(private backend:BackendService) { }
  ngOnChanges(changes: SimpleChanges): void {
    if(changes.needReload){
      this.loadData();
    }
  }

  ngOnInit(): void {
    this.filter={};
    // this.loadData();
  }
  loadData(){
    this.backend.post(this.source,{page:this.page,pageSize:this.pageSize,filter:this.filter}).subscribe(result=>{
      this.data=result.data;
      this.count=result.count;
    });
  }
  reloadData(){
    this.page=0;
    this.loadData();
  }
  nextPage(){
    this.page++;
    this.loadData();
  }
  prevPage(){
    this.page--;
    this.loadData();
  }
  pageSizeChange(){
    this.loadData();
  }
  edit(row){
    // console.log(row);
    this.onEdit.emit(row);
  }
  remove(row){
    // console.log(row);
    this.onRemove.emit(row);
  }
  add(){
    this.onAdd.emit();
  }

}
