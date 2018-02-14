import { KeyValuePair } from './../app/models/pojazd';
import { PojazdService } from './../app/services/pojazd.service';
import { Component, OnInit } from '@angular/core';
import { Pojazd } from '../app/models/pojazd';

@Component({
  selector: 'app-pojazd-lista',
  templateUrl: './pojazd-lista.component.html',
  styleUrls: ['./pojazd-lista.component.css']
})
export class PojazdListaComponent implements OnInit {

  pojazdy: Pojazd[] = [];
  marki: KeyValuePair[] = [];

  filter: any = {};

  constructor(private pojazdyService: PojazdService) { }

  ngOnInit() {
    this.pojazdyService.getMarki()
      .subscribe(marki => this.marki = marki);

    this.populatePojazdy();
  }

  private populatePojazdy() {
    this.pojazdyService.getPojazdy(this.filter)
      .subscribe(pojazdy => this.pojazdy = pojazdy);    
  }

  onFilterChange(){

    this.populatePojazdy();
  }

  resetFilter() {
    this.filter = {};
    this.onFilterChange();
  }
}
