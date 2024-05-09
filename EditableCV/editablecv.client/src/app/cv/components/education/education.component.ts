import { Component, Input } from '@angular/core';
import { Institution } from '../../models/institution';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'education',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './education.component.html',
  styleUrl: './education.component.scss'
})
export class EducationComponent {
  @Input() institutions?: Institution[] | null = [];
}
