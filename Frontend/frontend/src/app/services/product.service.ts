import { Injectable } from '@angular/core';
import { BackendService } from './backend.service';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private backend:BackendService) { }

  products:any[];
  product;

  public getProducts(){
    this.backend.get("shop/courseList").subscribe(result=>
      {
        this.products=result;
      })
    
  }
  public getProductId(id){
    this.backend.get("shop/get/"+id).subscribe(result=>
      {
        this.product=result;
        return this.product;
      })


  }
}
