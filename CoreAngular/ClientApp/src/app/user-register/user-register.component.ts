import { Component, OnInit, Inject } from '@angular/core';
import { User } from './user';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html'
})
export class UserRegisterComponent implements OnInit {
  user = new User();
  _baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {
    this._baseUrl = baseUrl;
  }

  ngOnInit() {
  }

  register(user: User): void {
    this.http.post<Boolean>(this._baseUrl + 'api/User/RegisterUser', user).subscribe(result => {
      if (result) {
        user.password = "";
        user.username = "";

        alert("Successfully register new user");
      }
      else {
        alert("Sorry, we are experience technical difficaulty");
      }
    }, error => console.error(error));
  }

}
