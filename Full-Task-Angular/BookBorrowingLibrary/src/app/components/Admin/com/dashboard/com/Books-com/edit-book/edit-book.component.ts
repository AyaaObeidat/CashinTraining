import { CommonModule, DOCUMENT } from '@angular/common';
import { Component, Inject, Renderer2 } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { AdminHeaderComponent } from '../../../../admin-header/admin-header.component';
import { AdminDashboardComponent } from '../../../admin-dashboard/admin-dashboard.component';

@Component({
  selector: 'app-edit-book',
  standalone: true,
  imports: [AdminHeaderComponent, AdminDashboardComponent,CommonModule,FormsModule],
  templateUrl: './edit-book.component.html',
  styleUrl: './edit-book.component.css',
})
export class EditBookComponent {
  bookData: any;
  newTitle = '';
  newAuthor = '';
  newPublisher = '';
  newPublicationYear = '';
  newNumberOfAvailableCopies = 0;
  newTotalNumberOfCopies = 0;
  constructor(
    private router: Router,
    private render: Renderer2,
    @Inject(DOCUMENT) private document: Document
  ) {
    const navigation = this.router.getCurrentNavigation();
    if (navigation?.extras.state) {
      this.bookData = navigation.extras.state['editBook'];
      console.log(this.bookData);
    }
  }
  ngOnInit(): void {
    this.render.setStyle(this.document.body, 'backgroundColor', '#313b31');
  }
  ngOnDestroy(): void {
    this.render.removeStyle(this.document.body, 'backgroundColor');
  }
}
