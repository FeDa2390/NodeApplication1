import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Candidate } from 'src/app/_models/candidate';
import { CandidateParams } from 'src/app/_models/candidateParams';
import { AccountService } from 'src/app/_services/account.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-candidates',
  templateUrl: './candidates.component.html',
  styleUrls: ['./candidates.component.css']
})
export class CandidatesComponent implements OnInit {
  candidates: Candidate[];
  candidateParams: CandidateParams;
  candidates1: any;

  constructor(private http: HttpClient, private accountService: AccountService) { }

  ngOnInit() {
    this.loadCandidate();
  }

  // loadCandidates1() {
  //   this.accountService.getCandidates1().subscribe(response => {
  //     this.candidates1 = response;
  //   })
  // }

  loadCandidate() {
    this.accountService.setCandidateParams(this.candidateParams);
    this.accountService.getCandidates(this.candidateParams).subscribe(response => {
      this.candidates = response.result;
    })
  }

  resetFilters() {
    this.candidateParams = this.accountService.resetCandidateParams();
    this.loadCandidate();
  }

}
