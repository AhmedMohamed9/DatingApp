import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { AccountService } from 'src/app/Services/account.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Input() userFromHomeComponent: any;
  @Output() cancelRegister = new EventEmitter()
  model: any = {}
  constructor(private account: AccountService) {
  }

  ngOnInit(): void {
  }
  register() {
    this.account.register(this.model).subscribe(data => {
      
      if (data) { localStorage.setItem("user", data.token) }
      this.account.SaveCurrentUser();
      this.cancel();
    })

  }
  cancel() {
    this.cancelRegister.emit(false);
  }
}
