import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-reintegratie-test-taak',
  templateUrl: './reintegratie-test-taak.component.html',
  styleUrls: ['./reintegratie-test-taak.component.scss']
})
export class ReintegratieTestTaakComponent implements OnInit {
  reintegratie: Reintegratie = {};
  constructor() { }

  ngOnInit(): void {
  }

}


export interface Reintegratie {
  opmerking? : string
  startdatum? : Date
  einddatum? : Date
  opmerking1? : string
}   