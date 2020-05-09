import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ReintegratieTestTaakComponent } from './reintegratie-test-taak/reintegratie-test-taak.component';


const routes: Routes = [{
  path: 'country',
  loadChildren: () => import('./country/country.module').then(m => m.CountryModule)
},
{
  path: 'reintegratietesttaak',
  component: ReintegratieTestTaakComponent
}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
