import { PojazdService } from './../app/services/pojazd.service';
import { ToastyService } from 'ng2-toasty';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-pojazd-view',
  templateUrl: './pojazd-view.component.html',
  styleUrls: ['./pojazd-view.component.css']
})
export class PojazdViewComponent implements OnInit {

  pojazd: any;
  pojazdId: number;

  constructor(private route: ActivatedRoute, private router: Router,
              private toasty: ToastyService, private pojazdService: PojazdService) { 

      route.params.subscribe(p => {
        this.pojazdId = +p['id'];
        if (isNaN(this.pojazdId) || this.pojazdId <= 0) {
          router.navigate(['/pojazdy']);
          return; 
        }
      });      
    }

  ngOnInit() {
    this.pojazdService.getPojazd(this.pojazdId)
      .subscribe(
        p => this.pojazd = p,
        err => {
          if (err.status == 404) {
            this.router.navigate(['/pojazdy']);
            return; 
          }
        });    
  }

  delete() {
    if (confirm("Jesteś pewny?")) {
      this.pojazdService.delete(this.pojazd.id)
        .subscribe(x => {
          this.router.navigate(['/pojazdy']);
        });
    }
  }  

}
