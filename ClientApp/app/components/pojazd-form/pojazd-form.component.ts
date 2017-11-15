import { Component, OnInit } from '@angular/core';
import { PojazdService } from '../app/services/pojazd.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/Observable/forkJoin';

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

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private pojazdService: PojazdService) { 

      route.params.subscribe(p => {
        this.pojazd.id = +p['id'];
      });      

    }

  ngOnInit() {

    var sources = [
      this.pojazdService.getMarki(),
      this.pojazdService.getAtrybuty()
    ];

    if (this.pojazd.id)
      sources.push(this.pojazdService.getPojazd(this.pojazd.id));

    Observable.forkJoin(sources).subscribe(data => {
      this.marki = data[0];
      this.atrybuty = data[1];
      if (this.pojazd.id)
        this.pojazd = data[2];
    }, err => {
        if (err.status == 404)
          this.router.navigate(['/home']);  
    });   
 
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
