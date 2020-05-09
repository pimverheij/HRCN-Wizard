import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CountryComponent } from './country/country.component';

const routes: Routes = [
  {
    path: '',
    component: CountryComponent
  }
]
@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ]
})
export class CountryRoutingModule {

}