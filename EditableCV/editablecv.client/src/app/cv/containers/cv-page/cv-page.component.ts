import { Component } from '@angular/core';
import { ApiService } from '../../services/api-service/api.service';
import { Observable, map, shareReplay } from 'rxjs';
import { CommonInfoComponent } from '../../components/common-info/common-info.component';
import { ContactInfoComponent } from '../../components/contact-info/contact-info.component';
import { EducationComponent } from '../../components/education/education.component';
import { SkilsComponent } from '../../components/skills/skills.component';
import { WorkPlacesComponent } from '../../components/work-places/work-places.component';
import { CommonModule } from '@angular/common';
import { CommonInfo } from '../../models/common-info';
import { ContactInfo } from '../../models/contact-info';
import { Institution } from '../../models/institution';
import { WorkPlace } from '../../models/work-place';
import { Skill } from '../../models/skill';
import { CvModule } from '../../cv.module';

@Component({
  selector: 'app-cv-page',
  standalone: true,
  imports: [
    CvModule,
    CommonModule,
    CommonInfoComponent,
    ContactInfoComponent,
    EducationComponent,
    SkilsComponent,
    WorkPlacesComponent
  ],
  templateUrl: './cv-page.component.html',
  styleUrl: './cv-page.component.scss'
})
export class CvPageComponent {
  $commonInfo: Observable<CommonInfo | undefined>;
  $contactInfo: Observable<ContactInfo | undefined>;
  $education: Observable<Institution[] | undefined>;
  $skills: Observable<Skill[] | undefined>;
  $workPlaces: Observable<WorkPlace[] | undefined>;

  constructor(apiService: ApiService) {
    const cv = apiService.getLandingData().pipe(shareReplay(1));
    this.$commonInfo = cv.pipe(map(cvdata => cvdata.commonInfo));
    this.$contactInfo = cv.pipe(map(cvdata => cvdata.contactInfo));
    this.$education = cv.pipe(map(cvdata => cvdata.education));
    this.$skills = cv.pipe(map(cvdata => cvdata.skills));
    this.$workPlaces = cv.pipe(map(cvdata => cvdata.workPlaces));
  }
}
