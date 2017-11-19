import * as _ from 'underscore';

import { Pojazd } from './../app/models/pojazd';
import { Component, OnInit } from '@angular/core';
import { PojazdService } from '../app/services/pojazd.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/Observable/forkJoin';
import { SavePojazd } from '../app/models/pojazd';

@Component({
  selector: 'app-pojazd-form',
  templateUrl: './pojazd-form.component.html',
  styleUrls: ['./pojazd-form.component.css']
})
export class PojazdFormComponent implements OnInit {

  marki: any[];
  pojazd: SavePojazd = {
    id: 0,
    markaId: 0,
    modelId: 0,
    czyZarejestrowany: false,
    atrybuty: [],
    kontakt: {
      nazwa: '',
      email: '',
      telefon: ''
    }
  };
  modele: any[];
  atrybuty: any[];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private pojazdService: PojazdService) { 

      route.params.subscribe(p => {
        this.pojazd.id = +p['id'] || 0;
      });      

    }

  ngOnInit() {

    var sources = [
      this.pojazdService.getMarki(),
      this.pojazdService.getAtrybuty()
    ];

    if (this.pojazd.id) {
      sources.push(this.pojazdService.getPojazd(this.pojazd.id));
    }

    Observable.forkJoin(sources).subscribe(data => {
      this.marki = data[0];
      this.atrybuty = data[1];
      if (this.pojazd.id) {
        

        this.setPojazd(data[2]);        
        this.populateModele();
      }
    }, err => {
        if (err.status == 404)
          this.router.navigate(['/home']);  
    });   
 
  }
  
  private setPojazd(p: Pojazd) {
    this.pojazd.id = p.id;
    this.pojazd.markaId = p.marka.id;
    this.pojazd.modelId = p.model.id;
    this.pojazd.czyZarejestrowany = p.czyZarejestrowany;
    this.pojazd.kontakt = p.kontakt;
    this.pojazd.atrybuty = _.pluck(p.atrybuty, 'id');    
  }

  onMarkaChange(){
    this.populateModele();
    delete this.pojazd.modelId;
  }  

  private populateModele() {    
    var selectedMarka =  this.marki.find(m => m.id == this.pojazd.markaId);
    this.modele = selectedMarka ? selectedMarka.modele : [];
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
    if (this.pojazd.id) {
      this.pojazdService.update(this.pojazd)
        .subscribe(x => console.log(x));
    } else {
      this.pojazdService.create(this.pojazd)
        .subscribe(x => console.log(x));
    }
  }

  delete() {
    if (confirm("Jesteś pewny?")) {
      this.pojazdService.delete(this.pojazd.id)
        .subscribe(x => {
          this.router.navigate(['/home']);
        });
    }
  }
}
