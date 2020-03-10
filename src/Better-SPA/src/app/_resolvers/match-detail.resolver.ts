import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { MatchService } from 'src/app/_services/match.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { catchError } from 'rxjs/operators';
import { of, Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { Match } from '../_models/match';

@Injectable()
export class MatchDetailResolver implements Resolve<Match> {
    constructor(private matchService: MatchService, private router: Router,
        private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Match> {
        return this.matchService.getMatch(route.params['id']).pipe(
            catchError(error => {
                this.alertify.error('Problem retrieving data');
                this.router.navigate(['/match']);
                return of(null);
            })
        );
    }
}
