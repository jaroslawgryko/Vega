import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

@Injectable()
export class PhotoService {

constructor(private http: Http) { }

upload(pojazdId: number, photo: any) {
    var formData = new FormData();
    formData.append('file', photo);
    return this.http.post(`/api/pojazdy/${pojazdId}/photos`, formData)
        .map(res => res.json());
}

getPhotos(pojazdId: number) {
    return this.http.get(`/api/pojazdy/${pojazdId}/photos`)
        .map(res => res.json());
}
}