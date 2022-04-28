import { TestBed } from '@angular/core/testing';

import { RegistrationErrorCatchingInterceptor } from './registration-error-catching.interceptor';

describe('RegistrationErrorCatchingInterceptor', () => {
  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      RegistrationErrorCatchingInterceptor
      ]
  }));

  it('should be created', () => {
    const interceptor: RegistrationErrorCatchingInterceptor = TestBed.inject(RegistrationErrorCatchingInterceptor);
    expect(interceptor).toBeTruthy();
  });
});
