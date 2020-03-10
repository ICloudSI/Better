import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { Match } from '../_models/match';

@Component({
  selector: 'app-match-card',
  templateUrl: './match-card.component.html',
  styleUrls: ['./match-card.component.css']
})
export class MatchCardComponent implements OnInit {
  @Input() match: Match;
  sumaBet: number;
  procentageOnTeam1: number;
  procentageOnTeam2: number;
  constructor(private router: Router) { }

  ngOnInit() {
    console.log(this.match);
    this.sumaBet = this.match.betOnTeam1 + this.match.betOnTeam2;
    this.procentageOnTeam1 = this.match.betOnTeam1 / this.sumaBet * 100;
    this.procentageOnTeam2 = this.match.betOnTeam2 / this.sumaBet * 100;
  }

}
