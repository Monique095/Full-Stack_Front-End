import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { AccountService } from '@app/services';

@Component({ 
    templateUrl: 'login.component.html' ,
    styleUrls: ['./login.component.css'],
})

export class LoginComponent implements OnInit {
    
    loginForm: FormGroup;
    loading = false;
    submitted = false;
    errorMessage : string;

    constructor(private formBuilder: FormBuilder,
                private route: ActivatedRoute,
                private router: Router,
                private accountService: AccountService ) { }

    ngOnInit(): void {
        this.loginForm = this.formBuilder.group({
            username: ['', Validators.required],
            password: ['', Validators.required]
        });
    }

    get f(){ 
        return this.loginForm.controls; 
    }

    onSubmit(): void{
        this.submitted = true;
        // stop here if form is invalid
        if (this.loginForm.invalid) {
            return;
        }
        this.loading = true;
        this.accountService.login(this.f.username.value, this.f.password.value)
            .pipe(first())
            .subscribe({
                next: () => {
                    this.router.navigate(['/my-adverts']);
                },
                error: error => {
                    this.errorMessage = "Username or Password was Incorrect!";
                    this.ClearForm();
                    this.loading = false;
                }
        });
    }

    ClearForm(): void{
        this.loginForm.controls['password'].reset();
    }
}