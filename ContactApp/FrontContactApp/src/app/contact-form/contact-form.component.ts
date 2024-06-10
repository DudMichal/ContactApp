import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ContactService } from '../contact.service';

@Component({
  selector: 'app-contact-form',
  templateUrl: './contact-form.component.html',
  styleUrls: ['./contact-form.component.css']
})
export class ContactFormComponent {

  contact: any = {};
  contactCategories: string[] = ['Business', 'Personal', 'Other'];

  constructor(private contactService: ContactService, private router: Router) { }

  save() {
    this.contactService.createContact(this.contact).subscribe(
      () => this.router.navigate(['/contacts']),
      error => console.error('Failed to create contact', error)
    );
  }
}
