import { BookServService } from '../../../ser/book-ser/book-serv.service';
import { CommonModule, DOCUMENT } from '@angular/common';
import { Component, Inject, Renderer2, ɵsetEnsureDirtyViewsAreAlwaysReachable } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { AdminHeaderComponent } from '../../../../admin-header/admin-header.component';
import { AdminDashboardComponent } from '../../../admin-dashboard/admin-dashboard.component';

@Component({
  selector: 'app-edit-book',
  standalone: true,
  imports: [
    AdminHeaderComponent,
    AdminDashboardComponent,
    CommonModule,
    FormsModule,
  ],
  templateUrl: './edit-book.component.html',
  styleUrl: './edit-book.component.css',
})
export class EditBookComponent {
  bookData: any;
  toEdit = false;
  toBuy = false;
  newTitle = '';
  newAuthor = '';
  newPublisher = '';
  newPublicationYear = '';
  newNumberOfAvailableCopies = 0;
  newTotalNumberOfCopies = 0;
  constructor(
    private router: Router,
    private render: Renderer2,
    private bookService: BookServService,
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
  Edit() {
    this.toEdit = true;
  }
  Save() {
    debugger
    this.toEdit = false;
    return this.bookService
      .ModifyBookData({
        id: this.bookData?.id,
        newTitle: this?.newTitle,
        newAuthor: this?.newAuthor,
        newPublisher: this?.newPublisher,
        newPublicationYear: this?.newPublicationYear,
        newNumberOfAvailableCopies: this?.newNumberOfAvailableCopies,
        newTotalNumberOfCopies: this?.newTotalNumberOfCopies,
      })
      .subscribe(
        (res) => {
          if (this.newTitle !== '') this.bookData.title = this.newTitle;
          else if (this.newAuthor !== '')
            this.bookData.author = this.newAuthor;
          else if (this.newPublisher !== '')
            this.bookData.publisher = this.newPublisher;
          else if (this.newPublicationYear !== '')
            this.bookData.publicationYear = this.newPublicationYear;
          else{
            this.bookData.numberOfAvailableCopies = this.bookData.numberOfAvailableCopies + this.newNumberOfAvailableCopies;
            this.bookData.totalNumberOfCopies = this.bookData.totalNumberOfCopies + this.newNumberOfAvailableCopies;
          }
          this.newTitle = '';
          this.newAuthor = '';
          this.newPublisher = '';
          this.newPublicationYear = '';
          this.newNumberOfAvailableCopies = 0;
        },
        (err) => {}
      );
  }
  BuyNewCopies(){
  this.toBuy = true;
  }
}
