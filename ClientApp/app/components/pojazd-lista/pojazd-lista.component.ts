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

  constructor(private pojazdyService: PojazdService) { }

  ngOnInit() {
    this.pojazdyService.getPojazdy()
      .subscribe(pojazdy => this.pojazdy = pojazdy);
  }

}
