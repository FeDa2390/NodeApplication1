import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CandidateDetailComponent } from './candidate-detail/candidate-detail.component';
import { CandidatesComponent } from './candidates/candidates.component';
import { HomeComponent } from './home/home/home.component';
import { VacanciesComponent } from './vacancies/vacancies.component';
const routes: Routes = [
  {path: '', component: HomeComponent},
  {
    path: '',
    children: [
      {path: 'candidates', component: CandidatesComponent},
      {path: 'candidates-detail/:username', component: CandidateDetailComponent},
      {path: 'vacancies', component: VacanciesComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
