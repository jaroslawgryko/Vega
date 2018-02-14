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

  pojazdy: Pojazd[];
  marki: KeyValuePair[];

  allPojazdy: Pojazd[];

  filter: any = {};

  constructor(private pojazdyService: PojazdService) { }

  ngOnInit() {
    this.pojazdyService.getMarki()
      .subscribe(marki => this.marki = marki);

    this.pojazdyService.getPojazdy()
      .subscribe(pojazdy => this.pojazdy = this.allPojazdy = pojazdy);
  }

  onFilterChange(){
    var pojazdy = this.allPojazdy;

    if (this.filter.markaId)
      pojazdy = pojazdy.filter(p => p.marka.id == this.filter.markaId);
    
    if (this.filter.modelId)
      pojazdy = pojazdy.filter(p => p.model.id == this.filter.modelId);

    this.pojazdy = pojazdy;
  }

  resetFilter() {
    this.filter = {};
    this.onFilterChange();
  }
}
