import { NgModule } from '@angular/core';
import { AuthModule } from '@auth0/auth0-angular';

@NgModule({
  imports: [
    AuthModule.forRoot({
        domain: '',
        clientId: '',
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