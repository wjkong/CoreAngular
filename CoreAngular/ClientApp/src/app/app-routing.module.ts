import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { MortgageCalculatorComponent } from './mortgage-calculator/mortgage-calculator.component';
import { UserRegisterComponent } from './user-register/user-register.component';
import { OnlineRebateComponent } from './online-rebate/online-rebate.component';




const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'fetch-data', component: FetchDataComponent },
  { path: 'mortgage-calculator', component: MortgageCalculatorComponent },
  { path: 'online-rebate', component: OnlineRebateComponent },
  { path: 'user-register', component: UserRegisterComponent }
];


@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)     
  ],
  exports: [RouterModule],
  declarations: []
})
export class AppRoutingModule { }
