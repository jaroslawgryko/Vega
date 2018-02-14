import { Injectable } from "@angular/core";
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { SavePojazd } from "../models/pojazd";

@Injectable()
export class PojazdService {
    
    private readonly pojazdyEndpoint = '/api/pojazdy';

    constructor(private http: Http) {}

    getMarki() {
        return this.http.get('api/marki')
            .map(res => res.json());
    }

    getAtrybuty() {
        return this.http.get('api/atrybuty')
            .map(res => res.json());
    }    

    create(pojazd: SavePojazd) {
        return this.http.post(this.pojazdyEndpoint, pojazd)
            .map(res => res.json());
    }

    getPojazd(id: number) {
        return this.http.get(this.pojazdyEndpoint + '/' + id)
            .map(res => res.json());
    }

    getPojazdy(filter: any) {
        return this.http.get(this.pojazdyEndpoint + '?' + this.toQueryString(filter))
              .map(res => res.json());        
    }    

    toQueryString(obj: any) {
        var parts = [];
        for (var property in obj) {
            var value = obj[property];
            if (value != null && value != undefined)
                parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));                
        }
        return parts.join('&');
    }

    update(pojazd: SavePojazd) {
        return this.http.put(this.pojazdyEndpoint +'/' + pojazd.id, pojazd)
            .map(res => res.json());
    }

    delete(id: number) {
        return this.http.delete(this.pojazdyEndpoint + '/' + id)
            .map(res => res.json());
    }
}