import { Component } from '@angular/core';
import { LoginResponse, OidcSecurityService } from 'angular-auth-oidc-client';
import { IdentityServerModule } from '../../../modules/identity-server.module';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [IdentityServerModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  /**
   *
   */
  constructor(private oidcSecurityService: OidcSecurityService,private authService:AuthService) {

    
  }
  ngOnInit() {
    this.oidcSecurityService
      .checkAuth()
      .subscribe((loginResponse: LoginResponse) => {
        //const { isAuthenticated, userData, accessToken, idToken, configId } =
        //  loginResponse;

        console.log(JSON.stringify(loginResponse));
      });
  }
  getToken(){
    this.oidcSecurityService.getAccessToken().subscribe(resp=>console.log(resp));
  }
  login(){
    this.oidcSecurityService.authorize();
  }
  getSub(){
    this.authService.getSub().subscribe(resp=>console.log(resp));
  }
}
