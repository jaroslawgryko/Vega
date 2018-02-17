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

  query: any = {};

  columns = [
    { title: 'Id' },
    { title: 'Kontakt', key: 'kontktNazwa', isSortable: true },
    { title: 'Marka', key: 'marka', isSortable: true },
    { title: 'Model', key: 'model', isSortable: true },
    { title: ''}
  ]

  constructor(private pojazdyService: PojazdService) { }

  ngOnInit() {
    this.pojazdyService.getMarki()
      .subscribe(marki => this.marki = marki);

    this.populatePojazdy();
  }

  private populatePojazdy() {
    this.pojazdyService.getPojazdy(this.query)
      .subscribe(pojazdy => this.pojazdy = pojazdy);    
  }

  onFilterChange(){

    this.populatePojazdy();
  }

  resetFilter() {
    this.query = {};
    this.onFilterChange();
  }

  sortBy(columnName: string) {
    if (this.query.sortBy === columnName) {
      this.query.isSortAscending = !this.query.isSortAscending;
    } else {
      this.query.sortBy = columnName;
      this.query.isSortAscending = true;
    }

    this.populatePojazdy();
  }
}
