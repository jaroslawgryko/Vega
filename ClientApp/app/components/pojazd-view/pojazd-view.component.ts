import { PhotoService } from './../app/services/photo.service';
import { PojazdService } from './../app/services/pojazd.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';

@Component({
  selector: 'app-pojazd-view',
  templateUrl: './pojazd-view.component.html',
  styleUrls: ['./pojazd-view.component.css']
})
export class PojazdViewComponent implements OnInit {

  pojazd: any;
  pojazdId: number;

  @ViewChild('fileInput') fileInput: ElementRef;
  photos: any[];

  constructor(private route: ActivatedRoute, private router: Router, 
    private pojazdService: PojazdService, private photoService: PhotoService) { 

      route.params.subscribe(p => {
        this.pojazdId = +p['id'];
        if (isNaN(this.pojazdId) || this.pojazdId <= 0) {
          router.navigate(['/pojazdy']);
          return; 
        }
      });      
    }

  ngOnInit() {
    this.photoService.getPhotos(this.pojazdId)
      .subscribe(photos => this.photos = photos);

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

  uploadPhoto () {
    var nativeElement = this.fileInput.nativeElement;

    this.photoService.upload(this.pojazdId, nativeElement.files[0])
      .subscribe(photo => {
        this.photos.push(photo);
      });
  }

}
