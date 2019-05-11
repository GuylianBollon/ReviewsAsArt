import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormGroup, Validators, FormBuilder, ValidatorFn } from '@angular/forms';
import { AuthenticationService } from '../authentication.service';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.sass']
})
export class RegisterComponent implements OnInit {

  public user: FormGroup;
  public errorMg: string;

  constructor(
    private authService: AuthenticationService,
    private router: Router,
    private fb: FormBuilder
  ) { }

  ngOnInit() {
    this.user = this.fb.group({
      username: ['', [Validators.required],
        serverSideValidateUsername(this.authService.checkUserNameAvailability)],
      passwordGroup: this.fb.group(
        {
          password: ['', [Validators.required, Validators.minLength(8)]],
          confirmPassword: ['', Validators.required]
        },
        { validator: comparePasswords }
      ),
      emailGroup: this.fb.group(
        {
          email: ['', [Validators.required, Validators.email],
            serverSideValidateUsername(this.authService.checkEmailAvailability)]
        }
      )
    });
  }
}

function comparePasswords(control: AbstractControl): { [key: string]: any } {
  const password = control.get('password');
  const confirmPassword = control.get('confirmPassword');
  return password.value === confirmPassword.value ? null
    : { 'passwordsDiffer': true };
}

function serverSideValidateUsername(
  checkAvailabilityFn: (n: string) => Observable<boolean>
): ValidatorFn {
  return (control: AbstractControl): Observable<{ [key: string]: any }> => {
    return checkAvailabilityFn(control.value).pipe(
      map(available => {
        if (available) {
          return null;
        }
        return { userAlreadyExists: true };
      })
    )
  }
}