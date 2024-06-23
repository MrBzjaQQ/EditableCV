import { Component, Input } from '@angular/core';
import { Project } from '../../models/project';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'projects',
  templateUrl: './projects.component.html',
  standalone: true,
  styleUrl: './projects.component.scss',
  imports: [CommonModule],
})
export class ProjectsComponent {
  @Input() projects?: Project[] | null = [];
}
