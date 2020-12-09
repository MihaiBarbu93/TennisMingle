import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TennisClubDetailComponent } from './tennis-club-detail.component';

describe('TennisClubDetailComponent', () => {
  let component: TennisClubDetailComponent;
  let fixture: ComponentFixture<TennisClubDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TennisClubDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TennisClubDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
