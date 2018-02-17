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
  
  private readonly PAGE_SIZE = 3; 

  queryResult: any = {};
  marki: KeyValuePair[] = [];
  
  query: any = {
    pageSize: this.PAGE_SIZE
  };

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
      .subscribe(result => this.queryResult = result);    
  }

  onFilterChange(){
    this.query.page = 1;
    
    this.populatePojazdy();
  }

  resetFilter() {
    this.query = {
      page: 1,
      pageSize: this.PAGE_SIZE
    };
    this.populatePojazdy();
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

  onPageChange(page: number) {
    this.query.page = page; 
    this.populatePojazdy();
  }  
}
