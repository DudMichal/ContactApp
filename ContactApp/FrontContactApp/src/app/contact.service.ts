import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  private apiUrl = 'https://localhost:7153/api/Contacts'; // Ustaw URL backend

  constructor(private http: HttpClient) { }

  getContacts(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  getContact(id: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/${id}`);
  }

  createContact(contact: any): Observable<any> {
    contact.category = this.mapCategoryEnum(contact.category);
    return this.http.post<any>(this.apiUrl, contact);
  }

  updateContact(id: number, contact: any): Observable<any> {
    contact.category = this.mapCategoryEnum(contact.category);
    return this.http.put<any>(`${this.apiUrl}/${id}`, contact);
  }

  deleteContact(id: number): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/${id}`);
  }
  private mapCategoryEnum(category: string): number {
    switch (category) {
      case 'Business':
        return 0;
      case 'Personal':
        return 1;
      case 'Other':
        return 2;
      default:
        return -1; // obsługa błędu
    }
  }
}
