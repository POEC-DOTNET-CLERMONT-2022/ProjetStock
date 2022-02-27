import { NgModule } from '@angular/core';
import { AuthModule } from '@auth0/auth0-angular';

@NgModule({
  imports: [
    AuthModule.forRoot({
        domain: 'dev-kiw3a5n6.eu.auth0.com',
        clientId: 's4XpDitBE8QHGTMNuM3SCfJ7TbQZALwP',
        scope: 'read:current_user',
  
        httpInterceptor: {
          allowedList: [
            {
              uri: 'http://localhost:7136/*',
              tokenOptions: {
                audience: 'http://localhost:7136',
                scope: 'read:current_user'
              }
            }
          ]
        }
      })
  ],
  exports: [AuthModule],
  declarations: [],
  providers: [],
})
export class AppAuthenticationModule { }