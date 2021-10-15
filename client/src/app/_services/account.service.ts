import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Candidate } from '../_models/candidate';
import { CandidateParams } from '../_models/candidateParams';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.apiUrl;
  candidateCache = new Map();
  candidates: Candidate[] = [];

  constructor(private http: HttpClient) { }

  getCandidates(candidateParams: CandidateParams) {
    var response = this.candidateCache.get(Object.values(CandidateParams).join('-'));
    if (response) {
      return of(response);
    }

    let params = new HttpParams();

    params = params.append('minAge', candidateParams.minAge.toString());
    params = params.append('maxAge', candidateParams.maxAge.toString());
    params = params.append('country', candidateParams.country);
    params = params.append('city', candidateParams.city);
    params = params.append('skill', candidateParams.skill);
    params = params.append('grade', candidateParams.grade);
    
    let candidatesResponse: any;
    return this.http.get<Candidate>(this.baseUrl, { observe: 'response', params }).pipe (
      map(response => {
        candidatesResponse = response;
        this.candidateCache.set(Object.values(candidateParams).join('-'), response);
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
}
