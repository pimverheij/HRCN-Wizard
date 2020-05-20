import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class TaakService {
  baseUrl: string = 'https://localhost:44333/api';
  constructor(private http: HttpClient) { }

  public slaTaakOp(id: number, taakContent: any) : void {
    this.http.put(`${this.baseUrl}/taak/${id}`, taakContent).subscribe(r => r);
  }

  public getTaak(id: number) : Observable<Taak> {
    return this.http.get<Taak>(`${this.baseUrl}/taak/${id}`)
      .pipe(map(data => { 
        data.taakData = JSON.parse(data.taakData);
        return data;
      }));
  }
}

export interface Taak {
  id: number;
  type: TaakType,
  hoortBijEntiteitId: number;
  hoortBijEntiteitType: EntiteitType;
  taakomschrijving: string;
  startdatum: Date;
  vervaldatum?: Date;
  taakData: any;
}

export enum TaakType {
  ReintegratieTestTaak = 1
}

export enum EntiteitType {
  Reintegratie = 1
}
