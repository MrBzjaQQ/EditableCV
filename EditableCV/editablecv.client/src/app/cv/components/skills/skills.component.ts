import { Component, Input } from '@angular/core';
import { Skill } from '../../models/skill';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'skils',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './skills.component.html',
  styleUrl: './skills.component.scss'
})
export class SkilsComponent {
  @Input() skills?: Skill[] | null = [];
}
