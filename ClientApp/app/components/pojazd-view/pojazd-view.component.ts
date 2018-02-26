import { ProgressService } from './../app/services/progress.service';
import { PhotoService } from './../app/services/photo.service';
import { PojazdService } from './../app/services/pojazd.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit, ElementRef, ViewChild, NgZone } from '@angular/core';

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

  progress: any;

  constructor(
    private zone: NgZone,
    private route: ActivatedRoute, private router: Router, 
    private pojazdService: PojazdService, private photoService: PhotoService,
    private progressService: ProgressService) { 

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
    
    this.progressService.startTracking()
      .subscribe(progress => {
          console.log(progress);
          this.zone.run(() => {
            this.progress = progress;
          });        
        },      
        () => {this.progress = null}
      );
  
    var nativeElement = this.fileInput.nativeElement;
    var file = nativeElement.files[0];
    nativeElement.value = '';

    this.photoService.upload(this.pojazdId, file)
      .subscribe(photo => {
        this.photos.push(photo);
      });
  }

}
