import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-reintegratie-test-taak',
  templateUrl: './reintegratie-test-taak.component.html',
  styleUrls: ['./reintegratie-test-taak.component.scss']
})
export class ReintegratieTestTaakComponent implements OnInit {
  reintegratie: Reintegratie = {
    startdatum: undefined,
    einddatum: undefined,
    opmerking: undefined,
    werkgeverWerktMeeAanSpoor1: false,
    opmerkingPlaatsen: false
  };

  mindate: Date = new Date()
  constructor() { }

  ngOnInit(): void {
  }

}


export interface Reintegratie {
  opmerking : string
  startdatum : Date
  einddatum : Date
  werkgeverWerktMeeAanSpoor1: boolean,
  opmerkingPlaatsen: boolean
}   