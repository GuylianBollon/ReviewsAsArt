import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from './../user/authentication.service';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-main-nav',
  templateUrl: './main-nav.component.html',
  styleUrls: ['./main-nav.component.sass']
})
export class MainNavComponent implements OnInit {

  loggedInUser$ = this._authenticationService.user$;
  constructor(
    private _authenticationService: AuthenticationService
  ) { }

  logout() {
    this._authenticationService.logout();
  }

  ngOnInit() {
  }

}
