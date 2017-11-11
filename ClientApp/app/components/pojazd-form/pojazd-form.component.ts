import { Component, OnInit } from '@angular/core';
import { PojazdService } from '../app/services/pojazd.service';

@Component({
  selector: 'app-pojazd-form',
  templateUrl: './pojazd-form.component.html',
  styleUrls: ['./pojazd-form.component.css']
})
export class PojazdFormComponent implements OnInit {

  marki: any[];
  pojazd: any = {
    atrybuty: [],
    kontakt: {}
  };
  modele: any[];
  atrybuty: any[];

  constructor(private pojazdService: PojazdService) { }

  ngOnInit() {
    this.pojazdService.getMarki()
      .subscribe(marki => {
        this.marki = marki;
        console.log("Marki:", this.marki);
      });
    this.pojazdService.getAtrybuty()
      .subscribe(atrybuty => this.atrybuty = atrybuty);    
  }
  
  onMarkaChange(){
    console.log("Pojazd: ", this.pojazd);
    var selectedMarka =  this.marki.find(m => m.id == this.pojazd.markaId);
    this.modele = selectedMarka ? selectedMarka.modele : [];
    delete this.pojazd.modelId;
  }  

  onAtrybutToggle(atrybutId: number, $event: any) {
    if( $event.target.checked)
      this.pojazd.atrybuty.push(atrybutId);
    else {
      var index = this.pojazd.atrybuty.indexOf(atrybutId);
      this.pojazd.atrybuty.splice(index, 1);
    }
  }

  submit() {
    this.pojazdService.create(this.pojazd)
      .subscribe(x => console.log(x));
  }
}
