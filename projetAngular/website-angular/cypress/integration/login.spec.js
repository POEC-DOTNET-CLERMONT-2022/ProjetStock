//login.spec.js
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



      cy.visit("http://localhost:4200/market");
      cy.pause();
  
      cy.get('button[class="btn btn-success text-center"]').click()
      cy.get('input[ng-reflect-name="name"]').type('test');
     
  
      
    //   cy.get('input[ng-reflect-name="openingDate"]').invoke('val').then((text) => {
    //     expect('08/05/2019');
    // });
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

  cy.visit("http://localhost:4200/api");
  cy.pause();

  cy.visit("http://localhost:4200/profile");

  cy.pause();
  cy.visit("http://localhost:4200/logout");


    });
  });


  