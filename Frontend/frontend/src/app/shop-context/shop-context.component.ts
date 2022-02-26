import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BackendService } from '../services/backend.service';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-shop-context',
  templateUrl: './shop-context.component.html',
  styleUrls: ['./shop-context.component.scss']
})
export class ShopContextComponent implements OnInit {
  product:any[];
  productid;
  sub:any;
  ara:any[];
  constructor(private _ActivatedRoute:ActivatedRoute, private _router:Router ,
      private _productService:ProductService , private backend:BackendService) {}

  ngOnInit(): void {
    this._ActivatedRoute.paramMap.subscribe(params => {
      console.log(params)
      this.productid = params.get('id');
      this.backend.get("shop/get/"+this.productid).subscribe(result=>
        {
          this.product=result;
          console.log(this.product);
        })
    });

   };

}
