import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { LoadingService } from './shared/services/loading/loading.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit, OnDestroy{
  title = 'Cadastro Produto';
  isLoading: boolean = false;
  subscription!: Subscription;
  constructor(public route: ActivatedRoute, private loadingService: LoadingService) {
  }


  ngOnInit() {
    setTimeout(() => {
      this.subscription =  this.loadingService.showLoadSubject.subscribe((data) => {
        this.isLoading = data;
      });  
    }, 10);
    
  }
    ngOnDestroy(): void {
      if(this.subscription)
        this.subscription.unsubscribe();
    }
}
