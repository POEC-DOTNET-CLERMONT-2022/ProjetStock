import { Component, NgModule } from '@angular/core';
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
import { ApiComponent } from './api/api.component';
import { UserModifyComponent } from './users/user-modify/user-modify/user-modify.component';
import { OrdersComponent } from './orders/orders.component';
import { MarketsComponent } from './markets/markets.component';
import { UserAddComponent } from './users/user-add/user-add/user-add.component';
import { MarketAddComponent } from './markets/market-add/market-add.component';
import { MarketUpdateComponent } from './markets/market-update/market-update.component';
import { OrdersModifyComponent } from './orders/orders-modify/orders-modify.component';
import { NotifsComponentComponent } from './notifs/notifs-component/notifs-component.component';
import { NotifsModifyComponent } from './notifs/notifs-modify/notifs-modify.component';
import { NotifsAddComponent } from './notifs/notifs-add/notifs-add.component';
import { NotifsDeleteComponent } from './notifs/notifs-delete/notifs-delete.component';
import { UserDeleteComponent } from './users/user-delete/user-delete/user-delete.component';
import { MarketDeleteComponent } from './markets/market-delete/market-delete.component';
import { OrdersDelteComponent } from './orders/orders-delte/orders-delte.component';
import { StocksDeleteComponent } from './stocks/stocks-delete/stocks-delete.component';
import { StocksAddComponent } from './stocks/stocks-add/stocks-add.component';
import { StocksUpdateComponent } from './stocks/stocks-update/stocks-update.component';
import { StocksComponentComponent } from './stocks/stocks-component/stocks-component.component';
import { LoginAuthComponent } from './login-auth/login-auth.component';
const routes: Routes = [
  {path : NavbarComponent.pathloginauth,component:LoginAuthComponent},
  { path : NavbarComponent.pathlogin, component: LoginComponent,},
  { path  : NavbarComponent.pathuser, component: UserComponentComponent, canActivate: [MyGuard],data: {roles: ['user']}},
  { path  : NavbarComponent.pathlogOut, component:LogoutComponent},
  { path : NavbarComponent.pathregister, component: RegisterComponent},
  { path : NavbarComponent.pathProfile,component: ProfilComponentComponent, canActivate: [MyGuard],data: {roles: ['user']}},
  { path : NavbarComponent.pathApi, component:ApiComponent, canActivate: [MyGuard],data: {roles: ['user']}},
  { path:NavbarComponent.pathAjoutUser,component:UserAddComponent,canActivate:[MyGuard], data:{roles: ['user']}},
  {path : NavbarComponent.pathModifUsers + '/:id',component:UserModifyComponent,canActivate:[MyGuard],data:{roles:['user']}},
  {path : NavbarComponent.pathModifOrder + '/:id',component:OrdersModifyComponent,canActivate:[MyGuard],data:{roles:['user']}},
  { path:NavbarComponent.pathAjoutMarket,component:MarketAddComponent,canActivate:[MyGuard], data:{roles: ['user']}},
  {path: NavbarComponent.pathOrders,component:OrdersComponent,canActivate:[MyGuard],data:{roles:['user']}},
  {path : NavbarComponent.pathmarket,component:MarketsComponent,canActivate:[MyGuard],data:{roles:['user']}},
  {path : NavbarComponent.pathUpdateMarket + '/:id',component:MarketUpdateComponent,canActivate:[MyGuard],data:{roles:['user']}},
  { path  : NavbarComponent.pathNotifs, component: NotifsComponentComponent, canActivate: [MyGuard],data: {roles: ['user']}},
  {path : NavbarComponent.pathModifNotif + '/:id',component:NotifsModifyComponent,canActivate:[MyGuard],data:{roles:['user']}},
  {path : NavbarComponent.pathAjoutNotifs ,component:NotifsAddComponent,canActivate:[MyGuard],data:{roles:['user']}},
  {path : NavbarComponent.pathSupNotif + '/:id' , component:NotifsDeleteComponent,canActivate:[MyGuard],data:{roles:['user']}},
  {path: NavbarComponent.pathSupUser + '/:id',component: UserDeleteComponent,canActivate:[MyGuard],data:{roles : ['user']}},
  {path:NavbarComponent.pathDeleteMarket + '/:id', component:MarketDeleteComponent,canActivate:[MyGuard],data : {roles : ['user']}},
  {path:NavbarComponent.pathSupOrder + '/:id',component:OrdersDelteComponent,canActivate:[MyGuard],data : {roles :['user']}},
  {path:NavbarComponent.pathSupStock +'/:id',component:StocksDeleteComponent,canActivate:[MyGuard],data : {roles :['user']}},
  {path:NavbarComponent.pathStockAdd,component:StocksAddComponent,canActivate:[MyGuard],data : {roles :['user']}},
  {path:NavbarComponent.pathModStock +'/:id',component:StocksUpdateComponent,canActivate:[MyGuard],data : {roles :['user']}},
  {path:NavbarComponent.pathStock,component:StocksComponentComponent,canActivate:[MyGuard],data : {roles :['user']}}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [MyGuard]
})
export class AppRoutingModule { }
