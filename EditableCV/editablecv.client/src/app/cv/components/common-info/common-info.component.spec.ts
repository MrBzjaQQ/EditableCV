import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CommonInfoComponent } from './common-info.component';

describe('CommonInfoComponent', () => {
  let component: CommonInfoComponent;
  let fixture: ComponentFixture<CommonInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CommonInfoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CommonInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
