import { Injectable } from '@angular/core';
import { Message } from '../models/message';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MessageService {
  private url = "Messages";
  constructor(private http: HttpClient) { }

  public getMessages() : Observable<Message[]> {
    return this.http.get<Message[]>(`${environment.apiUrl}/${this.url}`);
  }

  public createMessage(message: Message) : Observable<Message[]> {
    return this.http.post<Message[]>(`${environment.apiUrl}/${this.url}`, message);
  }
}
