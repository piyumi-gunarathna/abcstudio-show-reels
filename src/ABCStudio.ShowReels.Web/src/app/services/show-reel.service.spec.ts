import { TestBed } from '@angular/core/testing';

import { ShowReelService } from './show-reel.service';

describe('ShowReelService', () => {
  let service: ShowReelService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ShowReelService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
