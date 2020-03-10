import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  photoUrl: string;

  constructor(public authService: AuthService, private alertify: AlertifyService/*, private router: Router*/) { }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.model).subscribe(next => {
      console.log('Udało sie');
      console.log(this.authService.currentUser.username);
      this.alertify.success('logged in successfully');
    }, error => {
      console.log('Nie udalo sie');
      console.log(error);
      this.alertify.error(error);
    }, () => {
      //this.router.navigate(['/members']);
    });
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    this.authService.decodedToken = null;
    //this.authService.currentUser = null;
    //this.alertify.message('logged out');
    //this.router.navigate(['/home']);
  }
}
