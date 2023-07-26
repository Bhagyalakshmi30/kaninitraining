import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UrlShortenComponent } from './url-shorten.component';

describe('UrlShortenComponent', () => {
  let component: UrlShortenComponent;
  let fixture: ComponentFixture<UrlShortenComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UrlShortenComponent]
    });
    fixture = TestBed.createComponent(UrlShortenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
