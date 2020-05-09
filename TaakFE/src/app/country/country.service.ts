import { Injectable } from '@angular/core';
import { BehaviorSubject, of, Observable, ReplaySubject } from 'rxjs';
import { switchMap, distinctUntilChanged, map, startWith } from 'rxjs/operators';

const beschikbareLanden = {
  'Nederland': [
    'Amsterdam', 'Rotterdam', 'Utrecht'
  ],
  'Duitsland': [
    'Berlijn', 'Hamburg', 'Osnabrück'
  ]
} as const;

export type AvailableCountries = keyof typeof beschikbareLanden;
export type CitiesForCountry<T extends AvailableCountries> = (typeof beschikbareLanden)[T];
export type AnyCity = CitiesForCountry<AvailableCountries>[number];

@Injectable()
export class CountryService {
  readonly availableCountries$ = of(Object.keys(beschikbareLanden) as Array<AvailableCountries>)
  readonly country$ = new ReplaySubject<AvailableCountries>(1);
  readonly availableCities$ = this.country$.pipe(
    switchMap(value => this.callToApi(value))
  )
  readonly city$ = new BehaviorSubject<AnyCity>('Amsterdam');
  readonly isStep2Available$ = this.country$.pipe(map(() => true), startWith(false))

  constructor() {
    this.country$.pipe(distinctUntilChanged()).subscribe(newCountry => {
      this.city$.next(beschikbareLanden[newCountry][0])
    })
  }

  setCountry(country: AvailableCountries): void {
    this.country$.next(country);
  }

  private callToApi<T extends AvailableCountries>(country: T): Observable<CitiesForCountry<T>> {
    return of(beschikbareLanden[country]);
  }
}
