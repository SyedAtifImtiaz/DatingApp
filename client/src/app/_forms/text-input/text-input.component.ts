import { Component, Input, Self } from '@angular/core';
import { ControlValueAccessor, FormControl, NgControl } from '@angular/forms';

@Component({
  selector: 'app-text-input',
  templateUrl: './text-input.component.html',
  styleUrls: ['./text-input.component.css']
})
export class TextInputComponent implements ControlValueAccessor {

  // when we inject something into constructor its check if it's been used recently
  // if it has, it's going to reuse that thing and kept in memory
  // in order to make sure ngControl is unique to inputs that we're updating in DOM, 
  // we use Self() decorator

  @Input() label = '';
  @Input() type = 'text';


  constructor(@Self() public ngControl: NgControl) {
    this.ngControl.valueAccessor = this;
  }

  writeValue(obj: any): void {
  }

  registerOnChange(fn: any): void {
  }

  registerOnTouched(fn: any): void {
  }

  get control() : FormControl {
    return this.ngControl.control as FormControl
  }

}
