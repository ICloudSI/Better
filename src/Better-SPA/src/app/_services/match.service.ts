import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Match } from '../_models/match';

@Injectable({
  providedIn: 'root'
})
export class MatchService {
baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getMatches(): Observable<Match[]> {
    return this.http.get<Match[]>(this.baseUrl + 'match');
  }
  getMatch(id): Observable<Match> {
    return this.http.get<Match>(this.baseUrl + 'match/' + id);
  }
}
