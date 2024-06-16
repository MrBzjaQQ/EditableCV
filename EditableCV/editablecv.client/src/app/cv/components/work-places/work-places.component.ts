import { Component, Input } from '@angular/core';
import { WorkPlace } from '../../models/work-place';
import { CommonModule } from '@angular/common';
import { orderByDateDescending } from "../../helpers/ordering.helper";
import { dateFormat } from '../../constants/date.constants';

@Component({
  selector: 'work-places',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './work-places.component.html',
  styleUrl: './work-places.component.scss'
})
export class WorkPlacesComponent {
  @Input() workPlaces?: WorkPlace[] | null = [];

  dateFormat = dateFormat;
  get orderedWorkPlaces(): WorkPlace[] {
    return orderByDateDescending<WorkPlace>(
      this.workPlaces,
      a => a.endWorkingDate
    )
  }
}
