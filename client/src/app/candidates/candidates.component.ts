import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Candidate } from 'src/app/_models/candidate';
import { CandidateParams } from 'src/app/_models/candidateParams';
import { AccountService } from 'src/app/_services/account.service';
import { observable, Observable, Observer } from 'rxjs';
import { Skill } from '../_models/skill';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-candidates',
  templateUrl: './candidates.component.html',
  styleUrls: ['./candidates.component.css']
})
export class CandidatesComponent implements OnInit {
  candidates: Candidate[];
  candidateParams: CandidateParams;
  skillList: Skill[];

  constructor(private http: HttpClient, private accountService: AccountService) { }

  ngOnInit() {
    this.candidateParams = new CandidateParams;
    this.loadSkills();
    this.loadCandidate();
  }

  loadCandidate() {
    this.accountService.setCandidateParams(this.candidateParams);
    this.accountService.getCandidates(this.candidateParams).subscribe(response => {
      this.candidates = response.body;
    })
  }

  resetFilters() {
    this.candidateParams = this.accountService.resetCandidateParams();
    this.loadCandidate();
  }

  loadSkills() {
    this.accountService.getSkill().subscribe(response => {
      this.skillList = response.body;
    })
  }

}
