import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Match } from '../_models/match';
import { AlertifyService } from '../_services/alertify.service';
import { MatchService } from '../_services/match.service';

@Component({
  selector: 'app-matches-list',
  templateUrl: './matches-list.component.html',
  styleUrls: ['./matches-list.component.css']
})
export class MatchesListComponent implements OnInit {

  matches: Match[];
  constructor(private matchService: MatchService, private http: HttpClient,
    private alertify: AlertifyService, private route: ActivatedRoute) {}

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.matches = data['matches'];
    });
    console.log(this.matches);
  }

}
