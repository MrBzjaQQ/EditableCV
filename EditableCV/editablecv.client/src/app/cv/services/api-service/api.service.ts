import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CvData } from '../../models/cv-data';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private client: HttpClient) { }

  public getLandingData(): Observable<CvData> {
    return this.client.get<CvData>('/api/landing');
  }
}
