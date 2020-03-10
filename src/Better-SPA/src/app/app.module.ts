import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { HttpClientModule } from '@angular/common/http';
import { ErrorInterceptorProvider } from 'src/app/_services/error.interceptor';
import { JwtModule } from '@auth0/angular-jwt';
import { AuthService } from 'src/app/_services/auth.service';
import { MatchesListComponent } from './matches-list/matches-list.component';
import { MatchCardComponent } from './match-card/match-card.component';
import { MatchDetailComponent } from './match-detail/match-detail.component';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { MatchDetailResolver } from 'src/app/_resolvers/match-detail.resolver';
import { MatchesListResolver } from 'src/app/_resolvers/matches-list.resolver';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';

export function tokenGetter() {
   return localStorage.getItem('token');
}

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      MatchesListComponent,
      MatchCardComponent,
      MatchDetailComponent,
      HomeComponent,
      RegisterComponent
   ],
   imports: [
      BrowserAnimationsModule,
      BsDropdownModule.forRoot(),
      RouterModule.forRoot(appRoutes),
      BrowserModule,
      FormsModule,
      HttpClientModule,
      ReactiveFormsModule,
      JwtModule.forRoot({
         config: {
            tokenGetter: tokenGetter,
            whitelistedDomains: ['localhost:5000'],
         }
      })
   ],
   providers: [
      AuthService,
      ErrorInterceptorProvider,
      MatchDetailResolver,
      MatchesListResolver
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
