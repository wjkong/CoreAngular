import { Component, OnInit } from '@angular/core';
import { User } from './user';

@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html'
})
export class UserRegisterComponent implements OnInit {
  user = new User();

  constructor() { }

  ngOnInit() {
  }

  register(user: User): void {
    console.log(user);
  }

}
