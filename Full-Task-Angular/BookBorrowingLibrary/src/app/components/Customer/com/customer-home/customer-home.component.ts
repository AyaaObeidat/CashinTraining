import { CommonModule, DOCUMENT } from '@angular/common';
import {
  Component,
  Inject,
  Input,
  OnDestroy,
  OnInit,
  Renderer2,
} from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { CustomerHeaderComponent } from '../customer-header/customer-header.component';
import { CustomerServService } from '../../serv/customer-serv.service';
@Component({
  selector: 'app-customer-home',
  standalone: true,
  templateUrl: './customer-home.component.html',
  styleUrls: ['./customer-home.component.css'],
  imports: [CommonModule, CustomerHeaderComponent, RouterOutlet],
})
export class CustomerHomeComponent implements OnInit, OnDestroy {
  customer: any = {};
  constructor(
    private router: Router,
    private render: Renderer2,
    @Inject(DOCUMENT) private document: Document,
    private customerServ: CustomerServService
  ) {
    const navigation = this.router.getCurrentNavigation();
    if (navigation?.extras.state) {
      this.customer = navigation.extras.state['user'];
      this.customerServ.SetCustomerData(this.customer);
    }
  }
  ngOnInit() {
    this.render.setStyle(this.document.body, 'backgroundColor', '#313b31');
  }
  ngOnDestroy() {
    this.render.removeStyle(this.document.body, 'backgroundColor');
  }
}
