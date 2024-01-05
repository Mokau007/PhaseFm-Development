import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ParentService {

  apiUrl= "https://localhost:7070/api/"
  constructor(private http:HttpClient) { }

  get<T>(serviceEndpoint:string, id?: number) : Observable<T> {
    let url= `${this.apiUrl}${serviceEndpoint}`;
    if(id){
      url += `/${id}`
    }
    return this.http.get<T>(url);

  };

  create<T>(serviceEndpoint: string,item:T) : Observable<object>{
    return this.http.post(`${this.apiUrl}${serviceEndpoint}`, item);
  }

  delete<T>(serviceEndpoint: string): Observable<T>{
    return this.http.delete<T>(`${this.apiUrl}${serviceEndpoint}`)
  }

  update<T>(serviceEndpoint: string,item:T) : Observable<object>{
    return this.http.put(`${this.apiUrl}${serviceEndpoint}`, item);
  }
}
