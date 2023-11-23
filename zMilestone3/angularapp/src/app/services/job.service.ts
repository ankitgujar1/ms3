import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { JobApplication } from 'src/models/job-application.model';
import { JobPosition } from 'src/models/job-position.model';

@Injectable({
  providedIn: 'root'
})
export class JobService {

  constructor(private http:HttpClient) { }

  getJobPostings():Observable<JobPosition[]>{
    let header:HttpHeaders=new HttpHeaders({
      Accept:"application/json"
    })

    return this.http.get<JobPosition[]>("https://8080-abbcbfeabdfabcaaaceeafebeccaddbefddaf.premiumproject.examly.io/api/Job/positions",{headers:header});
  }

  getJobApplications():Observable<JobApplication[]>{
    let header:HttpHeaders=new HttpHeaders({
      Accept:"application/json"
    })

    return this.http.get<JobApplication[]>("https://8080-abbcbfeabdfabcaaaceeafebeccaddbefddaf.premiumproject.examly.io/api/Job/applications",{headers:header});
  }

  getPositionTitles():Observable<JobPosition[]>{
    let header:HttpHeaders=new HttpHeaders({
      Accept:"application/json"
    })

    return this.http.get<JobPosition[]>("https://8080-abbcbfeabdfabcaaaceeafebeccaddbefddaf.premiumproject.examly.io/api/Job/position_title",{headers:header});
  }


}
