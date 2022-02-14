//login.spec.js

var id ='53ebb220-54e8-59d9-68f1-00680afe7b8b';
var id_market ='b0b97bce-f5e5-61fb-f565-06a4ab52e3cf';
var id_stocks ='ed8a0a93-de41-4f97-ae54-08d9eef7287e';


describe("First test", () => {
    it("should visit login page", () => {

      cy.visit("http://localhost:4200/register");
      cy.get('input[ng-reflect-name="username"]').type('test');

      cy.get('input[ng-reflect-name="firstname"]').type('text');
      cy.get('input[ng-reflect-name="email"]').type('cypress_email@gmail.fr');
      cy.get('input[ng-reflect-name="password"]').type('test');
      cy.get('input[ng-reflect-name="password_confirm"]').type('test');


      cy.pause();
      cy.visit("http://localhost:4200/login");
      cy.get('input[name="email"]').type('oui@voiture.fr');
      cy.get('input[name="password"]').type('test');
      cy.get('button[class="btn btn-primary btn-block"]').click()

      cy.pause();
      cy.visit("http://localhost:4200/users");

      cy.pause();
      cy.get('button[class="btn btn-success text-right"]').click()
      cy.get('input[ng-reflect-name="firstName"]').type('test');
      cy.get('input[ng-reflect-name="lastName"]').type('test');
      cy.get('input[ng-reflect-name="text"]').type('text');
      cy.get('input[ng-reflect-name="email"]').type('cypress_email@gmail.fr');
      cy.get('input[ng-reflect-name="password"]').type('test');
      cy.get('input[ng-reflect-name="siret"]').type('test');

      cy.get('button[class="btn btn-primary"]').click();
      cy.pause();

      cy.visit("http://localhost:4200/modify_user/"+id.toString());
      cy.get('input[ng-reflect-name="firstName"]').type('test');
      cy.get('input[ng-reflect-name="lastName"]').type('test');
      cy.get('input[ng-reflect-name="text"]').type('text');
      cy.get('input[ng-reflect-name="email"]').type('cypress_email@gmail.fr');
      cy.get('input[ng-reflect-name="siret"]').type('test');

      cy.get('button[class="btn btn-primary"]').click();
      cy.pause();



      cy.visit("http://localhost:4200/delete_user/"+id.toString());
      cy.pause();

      cy.visit("http://localhost:4200/market");
      cy.pause();
  
      cy.get('button[class="btn btn-success text-center"]').click()
      cy.get('input[ng-reflect-name="name"]').type('test');
     
  
      
      cy.get('input[ng-reflect-name="openingDate"]').invoke('val').then((text) => {
        expect('08/05/2019');
    });
    
    cy.get('button[class="btn btn-primary"]').click();
    cy.pause();
    cy.visit("http://localhost:4200/modifier_market/"+id_market.toString());
    cy.get('input[ng-reflect-name="name"]').type('test');
     
  
      
      cy.get('input[ng-reflect-name="openingDate"]').invoke('val').then((text) => {
        expect('08/05/2019');
    });
    
    cy.get('button[class="btn btn-primary"]').click();
    cy.pause();
    
    cy.visit("http://localhost:4200/notifs");
    cy.pause();
  
    cy.get('button[class="btn btn-success text-center"]').click()
    cy.get('input[ng-reflect-name="textrappel"]').type('test');
   

    
  //   cy.get('input[ng-reflect-name="sendAt"]').invoke('val').then((text) => {
  //     expect('08/05/2019');
  // });
  cy.get('button[class="btn btn-primary"]').click();
  cy.pause();
  

  cy.visit("http://localhost:4200/stocks");
  cy.pause();
  cy.get('button[class="btn btn-success text-right"]').click()
  cy.get('input[ng-reflect-name="name"]').type('test');
  cy.get('input[ng-reflect-name="entreprisename"]').type('test');
  cy.get('input[ng-reflect-name="_value"]').type('12');
  cy.get('button[class="btn btn-primary"]').click();
  cy.pause();
  
  cy.visit("http://localhost:4200/modify_stocks/"+id_stocks.toString());
  cy.get('button[class="btn btn-success text-right"]').click()
  cy.get('input[ng-reflect-name="name"]').type('test');
  cy.get('input[ng-reflect-name="entreprisename"]').type('test');
  cy.get('input[ng-reflect-name="_value"]').type('12');

      cy.get('button[class="btn btn-primary"]').click();
      cy.pause();



      cy.visit("http://localhost:4200/delete_stocks/"+id_stocks.toString());
      cy.pause();

  cy.visit("http://localhost:4200/api");
  cy.pause();

  cy.visit("http://localhost:4200/profile");

  cy.pause();
  cy.visit("http://localhost:4200/logout");


    });
  });


  