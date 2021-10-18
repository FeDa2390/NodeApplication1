import { Component, OnInit } from '@angular/core';
import { Candidate } from '../_models/candidate';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-candidate-detail',
  templateUrl: './candidate-detail.component.html',
  styleUrls: ['./candidate-detail.component.css']
})
export class CandidateDetailComponent implements OnInit {
  candidate: Candidate;

  constructor(private accountService: AccountService) { 
  }

  ngOnInit() {
  }

  getCandidateDetail(username: string) {
    this.accountService.getDetaiCandidate(username).subscribe(candidate => {
      this.candidate = candidate;
    })
  }

}
