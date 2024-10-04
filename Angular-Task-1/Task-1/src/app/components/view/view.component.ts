import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ViewService } from '../../services/viewService/view.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css'],
  imports: [CommonModule],
  standalone: true,
})
export class ViewComponent implements OnInit {
  userId: any;
  user: any = null;
 
  constructor(private _route: ActivatedRoute,private _viewService: ViewService) {}

  ngOnInit(): void {
    this._route.paramMap.subscribe((params) => {
      const idParam = params.get('id');
      if (idParam !== null) {
        this.userId = idParam;
        this.getUserDetails();
      } else {
        alert('No ID parameter found in the URL');
      }
    });
  }

  getUserDetails(): void {
    if (this.userId) {
      this._viewService.GetById(this.userId).subscribe(
        (res) => {
          this.user = res;
        },
        (err) => {
          alert('User not found');
        }
      );
    }
  }
}
