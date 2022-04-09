import { TestBed } from '@angular/core/testing';

import { RecordingserviceService } from './recordingservice.service';

describe('RecordingserviceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: RecordingserviceService = TestBed.get(RecordingserviceService);
    expect(service).toBeTruthy();
  });
});
