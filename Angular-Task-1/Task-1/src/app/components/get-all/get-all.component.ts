import { Component } from '@angular/core';
import { GetAllService } from '../../services/get-all.service';
import { HeaderComponent } from "../header/header.component";
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-get-all',
  standalone: true,
  imports: [HeaderComponent,CommonModule],
  templateUrl: './get-all.component.html',
  styleUrl: './get-all.component.css'
})
export class GetAllComponent {

  users : any[] = [];
  private readonly _getAllService : GetAllService;
  constructor(getAllService : GetAllService)
  {
     this._getAllService = getAllService;
     this._getAllService.GetAll().subscribe
    (
      res => {
        this.users = res;
      },
    );
    console.log(this.users);
  }

  

}
