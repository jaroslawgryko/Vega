import { Injectable } from "@angular/core";
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { SavePojazd } from "../models/pojazd";

@Injectable()
export class PojazdService {
    
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
        return this.http.post('/api/pojazdy', pojazd)
            .map(res => res.json());
    }

    getPojazd(id: number) {
        return this.http.get('/api/pojazdy/' + id)
            .map(res => res.json());
    }

    update(pojazd: SavePojazd) {
        return this.http.put('api/pojazdy/' + pojazd.id, pojazd)
            .map(res => res.json());
    }

    delete(id: number) {
        return this.http.delete('/api/pojazdy/' + id)
            .map(res => res.json());
    }
}