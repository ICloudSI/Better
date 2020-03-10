import { Routes, RouterModule } from '@angular/router';
import { MatchesListComponent } from './matches-list/matches-list.component';
import { MatchDetailComponent } from './match-detail/match-detail.component';
import { MatchDetailResolver } from 'src/app/_resolvers/match-detail.resolver';
import { MatchesListResolver } from 'src/app/_resolvers/matches-list.resolver';
import { HomeComponent } from './home/home.component';

export const appRoutes: Routes =  [
  { path: '', component: HomeComponent},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    children: [
        { path: 'match', component: MatchesListComponent, resolve: {matches: MatchesListResolver}},
        { path: 'match/:id', component: MatchDetailComponent,
          resolve: {match: MatchDetailResolver}}
    ]
  },
 // { path: '**', redirectTo: '', pathMatch: 'full'}
];
