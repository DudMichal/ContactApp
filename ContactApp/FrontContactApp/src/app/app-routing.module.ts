import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactsComponent } from './contacts/contacts.component';
import { ContactDetailComponent } from './contact-detail/contact-detail.component';
import { ContactFormComponent } from './contact-form/contact-form.component';

const routes: Routes = [
  { path: 'contacts', component: ContactsComponent },
  { path: 'contact-detail/:id', component: ContactDetailComponent },
  { path: 'contact-form', component: ContactFormComponent },
  { path: '', redirectTo: '/contacts', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
