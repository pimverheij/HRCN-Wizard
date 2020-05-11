import { Pipe, PipeTransform } from '@angular/core';
import { DatePipe } from '@angular/common'

@Pipe({
  name: 'humanizevalue'
})
export class HumanizeValuePipe implements PipeTransform {

  constructor(private datepipe: DatePipe){}

  transform(value: any) {
    if(!value) {
      return value;
    }

    if (typeof value === 'boolean') {
      let typedValue = <boolean> value;
      return typedValue ? 'Ja' : 'Nee';
    }
    else if (value instanceof Date) {
      let typedValue = <Date> value;
      return this.datepipe.transform(typedValue, 'dd-MM-yyyy');
    }

    return value;
  }

}
