import { Component } from '@angular/core';

import { AccountService } from './services';
import { User } from './models';

@Component({ selector: 'app', templateUrl: 'app.component.html' })
export class AppComponent {

    user: User;
    loggedInUser: string;
    errorMessage : string;

    constructor(private accountService: AccountService) {
        this.accountService.user.subscribe(x => this.user = x);
    }

    logout() {
        this.accountService.logout();
    }

    loggedIn(){
        //Get User to display their email
        this.loggedInUser = localStorage.getItem('user');
        return this.loggedInUser;
    }
}