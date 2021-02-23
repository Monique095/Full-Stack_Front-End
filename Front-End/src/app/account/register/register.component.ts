import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { AccountService } from '@app/services';
import { MustMatch } from '@app/other/must-match.validator';

@Component({ 
    templateUrl: 'register.component.html',
    styleUrls: ['./register.component.css'],
 })

export class RegisterComponent implements OnInit {

    registerform: FormGroup;
    submitted = false;
    successMessage : string;
    errorMessage : string;

    constructor(private formBuilder: FormBuilder,
                private route: ActivatedRoute,
                private router: Router,
                private accountService: AccountService) { }

    ngOnInit() {
        this.registerform = this.formBuilder.group({
            firstName: ['',[ Validators.required, Validators.minLength(1), Validators.maxLength(100)]],
            lastName:  ['',[ Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
            username:  ['',[ Validators.required, Validators.email, Validators.minLength(6), Validators.maxLength(100)]],

            password: ['',[ Validators.required, Validators.minLength(8), Validators.maxLength(100)]],
            confirmPassword: ['',[ Validators.required]]
        },{
            validator: MustMatch('password', 'confirmPassword')        
        });
    }

    get f() { 
        return this.registerform.controls; 
    }

    onSubmit(): void {
        this.submitted = true;
        // stop here if form is invalid
        if (this.registerform.invalid) {
            return;
        }

        this.accountService.register(this.registerform.value)
            .pipe(first())
            .subscribe({
                next: () => {
                    this.successMessage = "Registration successful, Please log in!";
                },
                error: error => {
                    this.errorMessage = "There was an Error saving your request!!";
                }
        });
    }  
}

