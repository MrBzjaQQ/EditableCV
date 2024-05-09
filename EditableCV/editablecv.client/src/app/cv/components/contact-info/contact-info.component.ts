import { Component, Input } from '@angular/core';
import { ContactInfo } from '../../models/contact-info';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'contact-info',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './contact-info.component.html',
  styleUrl: './contact-info.component.scss'
})
export class ContactInfoComponent {
  @Input() contactInfo?: ContactInfo | null = {};
}
