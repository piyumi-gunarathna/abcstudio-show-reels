import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowReelListItemComponent } from './show-reel-list-item.component';

describe('ShowReelListItemComponent', () => {
  let component: ShowReelListItemComponent;
  let fixture: ComponentFixture<ShowReelListItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowReelListItemComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowReelListItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
