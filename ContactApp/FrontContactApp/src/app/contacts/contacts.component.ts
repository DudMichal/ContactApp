import { Component, OnInit } from '@angular/core';
import { ContactService } from '../contact.service';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.css']
})
export class ContactsComponent implements OnInit{

  contacts: any[] = [];

  constructor(private contactService: ContactService) { }

  ngOnInit(): void {
    this.contactService.getContacts().subscribe(
      data => this.contacts = data,
      error => console.error('Failed to fetch contacts', error)
    );
  }

  deleteContact(id: number): void {
    this.contactService.deleteContact(id).subscribe(
      () => this.contacts = this.contacts.filter(contact => contact.id !== id),
      error => console.error('Failed to delete contact', error)
    );
  }
}
