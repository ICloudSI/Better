import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Match } from '../_models/match';
import { MatchService } from '../_services/match.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-match-detail',
  templateUrl: './match-detail.component.html',
  styleUrls: ['./match-detail.component.css']
})
export class MatchDetailComponent implements OnInit {
  match: Match;
  sumaBet: number;
  procentageOnTeam1: number;
  procentageOnTeam2: number;
  constructor(private matchService: MatchService, private alertify: AlertifyService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.match = data['match'];
    });
    this.sumaBet = this.match.betOnTeam1 + this.match.betOnTeam2;
    this.procentageOnTeam1 = this.match.betOnTeam1 / this.sumaBet * 100;
    this.procentageOnTeam2 = this.match.betOnTeam2 / this.sumaBet * 100;
  }

}
