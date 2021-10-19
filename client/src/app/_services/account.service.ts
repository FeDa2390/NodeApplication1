import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Candidate } from '../_models/candidate';
import { CandidateParams } from '../_models/candidateParams';
import { Skill } from '../_models/skill';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.apiUrl;
  candidateCache = new Map();
  candidates: Candidate[];
  candidatesParams: CandidateParams;
  candidate: Candidate;

  constructor(private http: HttpClient) { 
    this.candidatesParams = new CandidateParams();
  }

  getSkill() {
   return this.http.get<Skill>(this.baseUrl + 'skills', {observe: 'response'}).pipe(
      map(response => {
        return response;
      }));
  }

  getCandidates(candidateParams1: CandidateParams) {
    var response = this.candidateCache.get(Object.values(CandidateParams).join('-'));
    if (response) {
      return of(response);
    }

    let params = new HttpParams();

    params = params.append('minAge', candidateParams1.minAge.toString());
    params = params.append('maxAge', candidateParams1.maxAge.toString());
    for (var s in candidateParams1.skill) {
      params = params.append('skill', candidateParams1.skill[s]);
    }

    return this.http.get<Candidate>(this.baseUrl + 'candidates/filter-candidates', { observe: 'response', params }).pipe (
      map(response => {
        return response;
      })
    );
  }

  updateCandidate(candidate: Candidate) {
    return this.http.put(this.baseUrl + 'candidates', candidate).pipe(
      map(() => {
        const index = this.candidates.indexOf(candidate);
        this.candidates[index] = candidate;
      })
    )
  }

  getCandidate(username: string) {
    const candidate = [...this.candidateCache.values()]
      .reduce((arr, elem) => arr.concat(elem.result), [])
      .find((candidate: Candidate) => candidate.username === username);

    if (candidate) {
      return of(candidate);
    }

    return this.http.get<Candidate>(this.baseUrl + 'candidates/'+ username);
  }

  resetCandidateParams() {
    this.candidatesParams = new CandidateParams();
    return this.candidatesParams;
  }

  setCandidateParams (params: CandidateParams) {
    this.candidatesParams = params;
  }

  getDetailCandidate(username: string) {
    // let params = new HttpParams();
    // params = params.append('username', username);
    return this.http.get<Candidate>(this.baseUrl + 'candidates/' + username);
  }
}
