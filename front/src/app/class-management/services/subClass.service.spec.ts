import { TestBed, inject } from '@angular/core/testing';

import { SubClassService } from './subclass.service';

describe('SubClassService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
        providers: [SubClassService]
    });
  });

    it('should be created', inject([SubClassService], (service: SubClassService) => {
    expect(service).toBeTruthy();
  }));
});
