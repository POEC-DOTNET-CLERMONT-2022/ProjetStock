import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthService } from 'src/services/service-auth/auth.service';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { LogoutComponent } from './logout/logout.component';
import { NavbarComponent } from './navbar/navbar/navbar.component';
import { UserComponentComponent } from './users/user-component/user-component.component';
import { TokenStorageService } from 'src/services/service-auth/token-storage.service';
import { RegisterComponent } from './register/register.component';
import { MyGuard } from './helpers/auth.guard';
import { ProfilComponentComponent } from './profil/profil-component/profil-component.component';

const routes: Routes = [
  { path : NavbarComponent.pathlogin, component: LoginComponent,},
  { path  : NavbarComponent.pathuser, component: UserComponentComponent, canActivate: [MyGuard],data: {roles: ['user']}},
  { path  : NavbarComponent.pathlogOut, component:LogoutComponent},
  {path : NavbarComponent.pathregister, component: RegisterComponent},
  {path : NavbarComponent.pathProfile,component: ProfilComponentComponent, canActivate: [MyGuard],data: {roles: ['user']}}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [MyGuard]
})
export class AppRoutingModule { }
