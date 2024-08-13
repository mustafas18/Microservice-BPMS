import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class JwTokenInterceptor implements HttpInterceptor {

  constructor() {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (typeof localStorage !== 'undefined') {
      const token = localStorage.getItem('access_token');
      //const token="eyJhbGciOiJSUzI1NiIsImtpZCI6IkY3MzgzQTBFRDdDRDk2MEVGNDczRkQyODUxODAzOTM4IiwidHlwIjoiYXQrand0In0.eyJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo1MjQzIiwibmJmIjoxNzIyNjAxMzUxLCJpYXQiOjE3MjI2MDEzNTEsImV4cCI6MTcyMjYwNDk1MSwic2NvcGUiOlsiYnBtcy5jcmVhdGUiLCJicG1zLnJlYWQiLCJicG1zLnVwZGF0ZSJdLCJhbXIiOlsicHdkIl0sImNsaWVudF9pZCI6ImJwbXNzd2FnZ2VydWkiLCJzdWIiOiIyNjhmYThhOS05ODEyLTRkMTktYWIwMS0zNTc5MWFmYTMyMzEiLCJhdXRoX3RpbWUiOjE3MjI1NDI1ODksImlkcCI6ImxvY2FsIiwicHJlZmVycmVkX3VzZXJuYW1lIjoiYWxpY2UiLCJ1bmlxdWVfbmFtZSI6ImFsaWNlIiwibmFtZSI6IkFsaWNlIiwibGFzdF9uYW1lIjoiU21pdGgiLCJlbWFpbCI6IkFsaWNlU21pdGhAZW1haWwuY29tIiwiZW1haWxfdmVyaWZpZWQiOnRydWUsInBob25lX251bWJlciI6IjEyMzQ1Njc4OTAiLCJwaG9uZV9udW1iZXJfdmVyaWZpZWQiOmZhbHNlLCJzaWQiOiI5NTdDMDQ3MDlCRkRDQzYxOTk2MUU5NkI1M0JDMTlGRCIsImp0aSI6IjBCNjAyREEwRjFFOUFFOTdBNzU1MDNERDNFNDI3RkQwIn0.FO2iW5owNfGJC2tqDzls6A-KpwXLRPAyislyHjJ7owMA-V1x4vHTW0_qbCwJAz4YduQLiKSyxpBFNGk6qP4DYxE_LddV89O6ARq0du4VevvQgsleJ0R1RijSxevsD6mp2WJjAaAxlHqlaVgznnhF7E20BAMe5MyXSV0_FRUhaIwU51FHNrDoUEnZAOrC4IA_6XoO82ztc-muwQNnCXQiLomLWT88OmttXK3aNN4AmiEtYnsZ6Sl9gYHC58dWUGagCPwYiezBn4mWbpgTN9LuVN91nW24-liFNCBm5tn90ArzizN-uExg5TaEIzRuIIrQyiMOUBXmYjQacx9IxWGdqQ";
      if (token) {
        request = request.clone({
          setHeaders: {
            'Authorization': "Bearer "+ token
          }
        })
      }
    }
    return next.handle(request);
  }

}