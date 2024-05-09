import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CvPageComponent } from './cv/containers/cv-page/cv-page.component';

const routes: Routes = [
  {
    path: '',
    component: CvPageComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
