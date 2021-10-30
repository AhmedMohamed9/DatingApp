import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  users: any;
  constructor(private _HttpClient: HttpClient) { }
  registermode: boolean = false;

  ngOnInit(): void {
    this.getuser()
  }
  changeMode() {
    this.registermode = true;
  }
  getuser() {
    this._HttpClient.get('https://localhost:5001/api/user').subscribe(data => {

      this.users = data;
      console.log(this.users);
    }, er => {
      console.log(er);

    }
    )
  }
  cancelRegisterMode(event: boolean) {
    this.registermode = event
  }
}
