import { Injectable } from '@angular/core';
import { Recording } from './Recording';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class RecordingserviceService {
  private RecordingDir = 'api/Recording/';
  constructor(private http: HttpClient,) {
    this.GetRecordings();
  }

  GetRecordings(): Observable<Recording[]> {

    

    return this.http.get<Recording[]>(this.RecordingDir)
  }


  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      console.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }





}
