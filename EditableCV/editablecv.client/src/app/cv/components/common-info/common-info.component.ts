import { Component, Input } from '@angular/core';
import { CommonInfo } from '../../models/common-info';

@Component({
  selector: 'common-info',
  standalone: true,
  imports: [],
  templateUrl: './common-info.component.html',
  styleUrl: './common-info.component.scss'
})
export class CommonInfoComponent {
  @Input() commonInfo?: CommonInfo | null = {
    firstName: '',
    lastName: '',
    age: 0,
    patronymicName: ''
  };

  get fullName(): string {
    return `${this.commonInfo?.lastName} ${this.commonInfo?.firstName} ${this.commonInfo?.patronymicName}`;
  }
}
