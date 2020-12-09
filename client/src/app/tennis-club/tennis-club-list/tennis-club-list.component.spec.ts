import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TennisClubListComponent } from './tennis-club-list.component';

describe('TennisClubListComponent', () => {
  let component: TennisClubListComponent;
  let fixture: ComponentFixture<TennisClubListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TennisClubListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TennisClubListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
