import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CandidatesComponent } from './candidates/candidates.component';
import { HomeComponent } from './home/home/home.component';
const routes: Routes = [
  {path: '', component: HomeComponent},
  {
    path: '',
    children: [
      {path: 'candidates', component: CandidatesComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
