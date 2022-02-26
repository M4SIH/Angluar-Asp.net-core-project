import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BackendService {
server='https://localhost:5001/api/'
  constructor(private http:HttpClient) { }
  post(api,data):Observable<any>{
    return this.http.post(this.server+api,data);
  }
  get(api):Observable<any>{
    return this.http.get(this.server+api);
  }
  securePost(api,data):Observable<any>{
    const httpOptions = {
      headers : new HttpHeaders({
        'Authorization': 'Bearer ' + sessionStorage['token']
      })
    };
    return this.http.post(this.server+api,data,httpOptions);
  }
  secureGet(api):Observable<any>{
    const httpOptions = {
      headers : new HttpHeaders({
        'Authorization': 'Bearer ' + sessionStorage['token']
      })
    };
    return this.http.get(this.server+api,httpOptions);
  }
}
