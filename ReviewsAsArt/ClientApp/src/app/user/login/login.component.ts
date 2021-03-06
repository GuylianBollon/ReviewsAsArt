import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../user/authentication.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.sass']
})

export class LoginComponent implements OnInit {
    private user: FormGroup;
    private errorMsg: string;

    constructor(private authService: AuthenticationService, private router: Router, private fb: FormBuilder) { }

    ngOnInit() {
        this.user = this.fb.group({
            username: ['', Validators.required],
            password: ['', Validators.required],
        })
    }

    onSubmit() {
        this.authService.login(this.user.value.username, this.user.value.password).subscribe(val => {
            if (val) {
                if (this.authService.redirectUrl) {
                    this.router.navigateByUrl(this.authService.redirectUrl);
                    this.authService.redirectUrl = undefined;
                } else {
                    this.router.navigate(['']);
                }
            } else {
                this.errorMsg = "Could not login";
            }
        },
            (err: HttpErrorResponse) => {
                console.log(err);
                if (err.error instanceof Error) {
                    this.errorMsg = `Error while trying to login user ${
                        this.user.value.username
                        } : ${err.error.message}`
                } else {
                    this.errorMsg = `Error ${err.status} while trying to login user ${
                        this.user.value.username
                        } : ${err.error}`
                }
            });
    }

}
