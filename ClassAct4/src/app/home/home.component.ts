import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  users: object;
  keyboards : object;

  constructor(private data: DataService) { }

  ngOnInit() {
   this.data.getUsers().subscribe(data => {
      this.users = data
      console.log(this.users)
    });

    this.data.getKeyboards().subscribe(data => {
      this.keyboards = data
      console.log(this.keyboards)
    });
  }

}
