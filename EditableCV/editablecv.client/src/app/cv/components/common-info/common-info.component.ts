import { Component, Input } from '@angular/core';
import { CommonInfo } from '../../models/common-info';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'common-info',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './common-info.component.html',
  styleUrl: './common-info.component.scss'
})
export class CommonInfoComponent {
  @Input() commonInfo?: CommonInfo | null = {
    firstName: '',
    lastName: '',
    age: 0,
    patronymicName: '',
    photoUrl: undefined,
    salary: 0
  };

  get fullName(): string {
    return `${this.commonInfo?.lastName} ${this.commonInfo?.firstName} ${this.commonInfo?.patronymicName}`;
  }

  get age(): string | null {
    if (!this.commonInfo?.age) {
      return null;
    }

    switch(this.commonInfo.age) {
      case 1: return `${this.commonInfo.age} год`;
      case 2: case 3: case 4: return `${this.commonInfo.age} года`;
      default: return `${this.commonInfo.age} лет`;
    }
  }
}
