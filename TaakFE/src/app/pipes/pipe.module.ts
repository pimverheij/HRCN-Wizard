import { NgModule } from '@angular/core';
import { LogPipe } from './log.pipe';
import { CamelCaseToSpacePipe } from './camel-case-to-space-pipe.pipe';
import { HumanizeValuePipe } from './humanize-value.pipe';
import { DatePipe } from '@angular/common';

@NgModule({
  declarations: [LogPipe, CamelCaseToSpacePipe, HumanizeValuePipe],
  exports: [LogPipe, CamelCaseToSpacePipe, HumanizeValuePipe] ,
  providers: [DatePipe]
})
export class PipeModule { }
