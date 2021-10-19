import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Candidate } from 'src/app/_models/candidate';
import { CandidateParams } from 'src/app/_models/candidateParams';
import { AccountService } from 'src/app/_services/account.service';
import { observable, Observable, Observer } from 'rxjs';
import { Skill } from '../_models/skill';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { AnimationGroupPlayer } from '@angular/animations/src/players/animation_group_player';
import { concatMapTo } from 'rxjs/operators';

@Component({
  selector: 'app-candidates',
  templateUrl: './candidates.component.html',
  styleUrls: ['./candidates.component.css']
})
export class CandidatesComponent implements OnInit {
  candidates: Candidate[];
  candidateParams: CandidateParams;
  skillList: Skill[] = [];

  constructor(private accountService: AccountService) {

  }

  ngOnInit() {
    this.loadSkills();
    this.candidateParams = new CandidateParams;
    this.loadCandidate();
  }

  loadCandidate() {
    this.candidateParams.skill = [];
    console.log(this.skillList);
    if (this.skillList !== null){
      for (let sl in this.skillList){
        if (this.skillList[sl].isChecked === true)
          this.candidateParams.skill.push(this.skillList[sl].skillName);
      }
    }
    this.accountService.setCandidateParams(this.candidateParams);
    this.accountService.getCandidates(this.candidateParams).subscribe(response => {
      this.candidates = response.body;
    })
  }

  resetFilters() {
    this.candidateParams = this.accountService.resetCandidateParams();
    this.skillList.forEach(s => {
      s.isChecked = false;
    })
    this.loadCandidate();
  }

  loadSkills() {
    this.accountService.getSkill().subscribe(response => {
      for ( var data in response.body ) {
        let newSkill = new Skill();
        newSkill.id = response.body[data].id;
        newSkill.isChecked = false;
        newSkill.skillName  = response.body[data].skillName ;

        this.skillList.push( newSkill );

        console.log ( response.body[data] ); 
      }
      
    })
  }

}
