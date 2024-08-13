import { NgModule } from "@angular/core";
import { AuthModule, LogLevel } from "angular-auth-oidc-client";

@NgModule({
    // ...
    imports: [
      AuthModule.forRoot({
        config: {
          authority: 'https://localhost:5243/connect/authorize',
          redirectUrl: window.location.origin,
          postLogoutRedirectUri: window.location.origin,
          clientId: 'bpmsswaggerui',
          scope: 'bpms.create bpms.read',
          responseType: 'code',
          silentRenew: true,
          useRefreshToken: true,
          logLevel: LogLevel.Debug,
        },
      }),
    ],
  })
  export class IdentityServerModule {}