import { Injectable } from "@angular/core";
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

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

    create(pojazd: any) {
        return this.http.post('/api/pojazdy', pojazd)
            .map(res => res.json());
    }

    getPojazd(id: number) {
        return this.http.get('/api/pojazdy/' + id)
            .map(res => res.json());
    }
}