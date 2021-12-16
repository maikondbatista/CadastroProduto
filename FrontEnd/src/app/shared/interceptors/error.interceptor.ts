import {
    HttpInterceptor,
    HttpRequest,
    HttpHandler,
    HttpEvent,
  } from '@angular/common/http/http';
  import { catchError } from 'rxjs/operators';
  import { Observable, throwError } from 'rxjs';
  import { Injectable } from '@angular/core';
import { LoadingService } from '../services/loading/loading.service';
import { ToastrService } from 'ngx-toastr';
  
  @Injectable()
  export class ErrorInterceptor implements HttpInterceptor {
    intercepted: number = 0;
    constructor( private toastr: ToastrService) {}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
      return next.handle(req).pipe(
        catchError((err) => {
          if(err.error?.errors)
          {
            Object.keys(err.error.errors).forEach(key => {
                this.toastr.error(err.error.errors[key]);
            })
          }
          else {
          this.toastr.error(err.error);
        }
          return throwError(() => err);
        })
      );
    }
  }
  