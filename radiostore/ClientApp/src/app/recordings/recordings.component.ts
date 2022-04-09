import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, Inject, OnInit, ViewChild } from '@angular/core';
import { Recording } from '../Recording';
import { RecordingserviceService } from '../recordingservice.service';
@Component({
  selector: 'app-recordings',
  templateUrl: './recordings.component.html',
  styleUrls: ['./recordings.component.css']
})


export class RecordingsComponent implements OnInit {
 
 

  public RecordingList: Recording[] = [];
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    console.log("Going to do " + baseUrl + 'api/recording');
    http.get<Recording[]>(baseUrl + 'api/recording').subscribe(result => {
      console.log(result.toString());
      this.RecordingList = result;
      for (var rec of result) {
        console.log("Its ");
        console.log(rec.recordingDate);
      }

      console.log("dONE");
    }, error => console.error(error));
  }


 
  /*
  GetRecordings(): void {
    this.RecordService.GetRecordings()
      .subscribe(RecordingList => this.RecordingList = RecordingList);
  }
  */


  ngOnInit() {


  }

}
