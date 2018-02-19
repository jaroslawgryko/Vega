/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { PojazdViewComponent } from './pojazd-view.component';

describe('PojazdViewComponent', () => {
  let component: PojazdViewComponent;
  let fixture: ComponentFixture<PojazdViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PojazdViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PojazdViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
