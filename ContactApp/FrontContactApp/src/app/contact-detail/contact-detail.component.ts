import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ContactService } from '../contact.service';

@Component({
  selector: 'app-contact-detail',
  templateUrl: './contact-detail.component.html',
  styleUrls: ['./contact-detail.component.css']
})
export class ContactDetailComponent implements OnInit {

  contact: any = {};
  contactCategories: string[] = ['Business', 'Personal', 'Other'];

  constructor(
    private route: ActivatedRoute,
    private contactService: ContactService,
    private router: Router
  ) { }

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam !== null) {
      const id = +idParam;
      this.contactService.getContact(id).subscribe(
        data => {
          data.birthDate = data.birthDate.split('T')[0];
          this.contact = data;
        },
        error => console.error('Failed to fetch contact details', error)
      );
    } else {
      console.error('ID parameter is null');
    }
  }

  save() {
    this.contactService.updateContact(this.contact.id, this.contact).subscribe(
      () => this.router.navigate(['/contacts']),
      error => console.error('Failed to update contact', error)
    );
  }
}
