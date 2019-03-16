import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, observable } from 'rxjs';


export interface Brand {
 
}

export class Brand {
  brandID :number;
  brandName: string;
}

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
    'Authorization': 'my-auth-token',
    "Access-Control-Allow-Origin": '*'
  })
};

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http: HttpClient) { }
  
  firstClick(){
    return alert('Clicked');
  }

  getUsers(){
    return this.http.get('https://reqres.in/api/users');
  }

  getKeyboards(){
    return this.http.get('http://localhost:57791/api/Keyboards/getAllKeyboards');
  }

  setBrand(brand : Brand) : Observable<Brand> {
  return this.http.post<Brand>("http://localhost:57791/api/Keyboards/addBrandWithKeyboards", brand, httpOptions);
  }
}
