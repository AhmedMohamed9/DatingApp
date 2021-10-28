import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'client app';
  clients: any;
  constructor(private _HttpClient: HttpClient) { }
  ngOnInit(): void {
    this.getuser();
  }
  getuser() {
    this._HttpClient.get('https://localhost:44320/user').subscribe(data => {

      this.clients = data;
      console.log(this.clients);
      
    }, er => {
      console.log(er);

    }
    )
  }
}
