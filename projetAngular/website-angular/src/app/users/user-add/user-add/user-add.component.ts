import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-add',
  templateUrl: './user-add.component.html',
  styleUrls: ['./user-add.component.scss']
})
export class UserAddComponent implements OnInit {
  form: any = {
    firstname : null,
    lastname : null,
    email: null,
    phone : null,
    siret: null,
    password :null
   };
  constructor() { }

  ngOnInit(): void {
  }

  onSubmit() : void{
    
  }

}
