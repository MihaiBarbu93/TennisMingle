import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TennisClubCardComponent } from './tennis-club-card.component';

describe('TennisClubCardComponent', () => {
  let component: TennisClubCardComponent;
  let fixture: ComponentFixture<TennisClubCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TennisClubCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TennisClubCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
