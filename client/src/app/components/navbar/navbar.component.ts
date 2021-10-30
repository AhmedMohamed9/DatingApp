import { Component, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { AccountService } from 'src/app/Services/account.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  model: any = {};
  loggedin: boolean = false;

  constructor(private _account: AccountService) {
   
    _account.currentUser.subscribe(()=>{
      if (_account.currentUser.getValue()!=null) {
        this.loggedin=true;
      }else{this.loggedin=false}
    })
  }


  ngOnInit(): void {

  };
  login() {
    this._account.login(this.model).subscribe(
      data => {


        if (data) { localStorage.setItem("user", data.token) }
        this._account.SaveCurrentUser();
        this.loggedin = true;
      },
      error => {
        console.log(error);
      }
    );


  }
  logout() {
    this.loggedin = false;
    localStorage.removeItem("user");
  }


}
