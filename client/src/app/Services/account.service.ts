import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import jwtDecode from 'jwt-decode';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  constructor(private http:HttpClient) { 
    if (localStorage.getItem('user')!=null) {
      this.SaveCurrentUser();
    }
  }
baseurl='https://localhost:5001/';
currentUser=new BehaviorSubject(null);

SaveCurrentUser(){
  let token:any=localStorage.getItem('user');
  this.currentUser.next(jwtDecode(token));
  console.log(this.currentUser);
}

  login(model:any):Observable<any>{
    return this.http.post(this.baseurl + "api/Account/login",model);
  }
  register(model:any):Observable<any>{
    return this.http.post(this.baseurl + "api/Account/register",model);
  }
}
