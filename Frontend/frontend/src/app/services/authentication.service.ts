import { Injectable } from '@angular/core';
import { BackendService } from './backend.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor() { }

  loggedIn(){
    if(sessionStorage.getItem('isOk')=='true'){
      return true;
    }
    return false;
  }
  getCurrentUser(){
    if(this.loggedIn){
      return JSON.parse(sessionStorage.getItem('user'));
    }
    return {};
  }
  // getProduct(courseId){
  //   this.backend.get()
  // }

}
