import { Component, OnInit } from '@angular/core';
import { JobService } from '../services/job.service';

@Component({
  selector: 'app-console',
  templateUrl: './console.component.html',
  styleUrls: ['./console.component.css']
})
export class ConsoleComponent implements OnInit {

  constructor(private http:JobService) { }

  ngOnInit() {
  }

  submit(){
    this.http.getJobApplications()
    .subscribe(e=>{
      console.log(e);
    })

    this.http.getJobPostings()
    .subscribe(e=>{
      console.log(e);
    })

    this.http.getPositionTitles()
    .subscribe(e=>{
      console.log(e);
    })

    // this.http.createJopPosition()
  }

}
