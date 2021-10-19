import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { map, switchMap } from 'rxjs/operators';
import { Candidate } from '../_models/candidate';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-candidate-detail',
  templateUrl: './candidate-detail.component.html',
  styleUrls: ['./candidate-detail.component.css']
})
export class CandidateDetailComponent implements OnInit {
  username: string;
  candidate: Candidate;

  constructor(private accountService: AccountService, private route: ActivatedRoute, private router: Router) {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
  }

  ngOnInit() : void {
    this.route.paramMap.subscribe(params => {
      console.log(params);
      this.username = params.get('username');
      console.log(this.username);
      this.accountService.getDetailCandidate(this.username).subscribe(candidate => {
        this.candidate = candidate;
      })
    })
    // this.route.paramMap.subscribe(params => {
    //   this.candidate.username = params.get('username');
    // })
    // this.route.data.subscribe(data => {
    //   this.candidate = data.candidate;
    // })
    
    //console.log(this.candidate.username);
    //this.getCandidateDetail(this.candidate.username);
  }

  // getCandidateDetail(username: string) {
  //   this.accountService.getDetailCandidate(username).subscribe(candidate => {
  //     this.candidate = candidate;
  //   })
  // }

}
