import { AuthService } from './components/app/services/auth.service';

import { PojazdViewComponent } from './components/pojazd-view/pojazd-view.component';
import { NgModule, ErrorHandler } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule, BrowserXhr } from '@angular/http';
import { RouterModule } from '@angular/router';

import { PojazdService } from './components/app/services/pojazd.service';
import { PhotoService } from './components/app/services/photo.service';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { PojazdFormComponent } from './components/pojazd-form/pojazd-form.component';
import { PojazdListaComponent } from './components/pojazd-lista/pojazd-lista.component';
import { PaginationComponent } from './components/shared/pagination.component';
import { BrowserXhrWithProgress, ProgressService } from './components/app/services/progress.service';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        PojazdFormComponent,
        PojazdListaComponent,
        PaginationComponent,
        PojazdViewComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'pojazdy', pathMatch: 'full' },
            { path: 'pojazdy/new', component: PojazdFormComponent },           
            { path: 'pojazdy/edit/:id', component: PojazdFormComponent }, 
            { path: 'pojazdy/:id', component: PojazdViewComponent },            
            { path: 'pojazdy', component: PojazdListaComponent },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        {provide: BrowserXhr, useClass: BrowserXhrWithProgress},
        AuthService,
        PojazdService,
        PhotoService,
        ProgressService
    ]
})
export class AppModuleShared {
}
