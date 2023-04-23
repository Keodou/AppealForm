import { Injectable } from '@angular/core';
import { Contact } from '../models/contact';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  private url = "Contacts";
  constructor(private http: HttpClient) { }

  public getContacts() : Observable<Contact[]> {
    return this.http.get<Contact[]>(`${environment.apiUrl}/${this.url}`);
  }

  public createContact(contact: Contact) : Observable<Contact[]> {
    return this.http.post<Contact[]>(`${environment.apiUrl}/${this.url}`, contact);
  }
}
