import { Component, OnInit } from '@angular/core';
import { CountryService, AvailableCountries } from '../country.service';

@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  styleUrls: ['./country.component.scss']
})
export class CountryComponent implements OnInit {
  constructor(
    readonly countryService: CountryService
  ) { }

  ngOnInit(): void {
  }

  onInput(event: InputEvent) {
    const newValue = (event.target as HTMLSelectElement).value as AvailableCountries;
    if (newValue) {
      this.countryService.setCountry(newValue);
    }
  }

}
