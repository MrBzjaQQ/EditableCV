import { Component, Input } from '@angular/core';
import { Institution } from '../../models/institution';
import { CommonModule } from '@angular/common';
import { orderByDateDescending } from '../../helpers/ordering.helper';
import { dateFormat } from '../../constants/date.constants';

@Component({
  selector: 'education',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './education.component.html',
  styleUrl: './education.component.scss'
})
export class EducationComponent {
  @Input() institutions?: Institution[] | null = [];

  dateFormat = dateFormat;
  get orderedInstitutions() {
    return orderByDateDescending<Institution>(
      this.institutions,
      a => a.endDate
    );
  }
}
