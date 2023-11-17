import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, catchError, finalize, throwError } from 'rxjs';
import { LoaderService } from './loader.service';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class LoaderInterceptor implements HttpInterceptor {

  
  constructor(
    private loaderService: LoaderService,
    private toastr: ToastrService) {}
  
  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    this.loaderService.showLoader();
    return next.handle(req)
    .pipe(
      
      catchError((error: HttpErrorResponse) => {
        console.log("here!!!!");
        // Handle error and show Toastr message
        this.handleErrorResponse(error);
        return throwError(error);
      }),
      finalize(() =>
        this.loaderService.hideLoader()
      )
    );
  }

  private handleErrorResponse(error: HttpErrorResponse): void {
    // Customize this method based on your Toastr implementation
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred
      console.log('An error occurred:', error.error.message);
      // Display Toastr message for client-side errors
      this.toastr.error('An error occurred: ' + error.error.message);
    } else {
      // The backend returned an unsuccessful response code
      
      console.log(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`
      );
      // Display Toastr message for server-side errors
      this.toastr.error(`Backend returned code ${error.status}`);
    }
  }
}
