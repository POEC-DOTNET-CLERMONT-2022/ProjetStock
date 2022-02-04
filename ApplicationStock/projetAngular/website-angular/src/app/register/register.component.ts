import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/services/service-auth/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  form: any = {
    firstName: null,
    lastName: null,
    email: null,
    password: null,
    password_confirm : null
  };
  isSuccessful = false;
  isSignUpFailed = false;
  isEmail : boolean = false;
  errorMessage = '';

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
  }

  
  onSubmit(): void {
    const { firstName,lastName, email, password, password_confirm } = this.form;
    const regularExpression = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    this.isEmail = regularExpression.test(String(email).toLowerCase());
      this.authService.register(lastName,firstName, email, password).subscribe(
        data => {
      
          if(password_confirm != password || this.isEmail == false || lastName == null || firstName == null)
          {
          
              this.isSignUpFailed = true;
              this.errorMessage = " Don't send. Inputs not valids";
              this.reloadPage();
          
          }
          else{

            console.log(data);
            this.isSuccessful = true;
            this.isSignUpFailed = false;
          }
         
        }
       
      );
    
  }
   
  reloadPage(): void {
    setTimeout(() => {
  window.location.reload();
  },
  7000);
  }
}