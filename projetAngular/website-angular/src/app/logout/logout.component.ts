import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.scss']
})
export class LogoutComponent implements OnInit {

  constructor(private router :Router) {

   }

  ngOnInit(): void {
    
    window.sessionStorage.clear();
    this.reloadPage();
    this.router.navigate(['']);
 
   
   
  }

    
  reloadPage(): void {
    
    if (!localStorage.getItem('foo')) { 
      localStorage.setItem('foo', 'no reload') 
      location.reload() 
    } else {
      localStorage.removeItem('foo') 
    }
  
  }
}
