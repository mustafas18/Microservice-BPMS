import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private httpClient:HttpClient) { }
  private readonly oidcSecurityService = inject(OidcSecurityService);

  login() {
    this.oidcSecurityService.authorize();
  }
getToken(){
  this.oidcSecurityService.getAccessToken().subscribe(resp=>console.log(resp));
}
getSub():Observable<any>{
  return this.httpClient.get("https://localhost:7185/api/bpms/identity?api-version=1.0");
}
}
