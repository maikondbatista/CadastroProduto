import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent,
} from '@angular/common/http/http';
import { finalize } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { LoadingService } from '../services/loading/loading.service';

@Injectable()
export class LoadingInterceptor implements HttpInterceptor {
  intercepted: number = 0;
  constructor(private loadingService: LoadingService) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    this.loadingService.show();
    this.intercepted++;
    return next.handle(req).pipe(
      finalize(() => {
        this.intercepted--;
        if (this.intercepted == 0) this.loadingService.hide();
      })
    );
  }
}
