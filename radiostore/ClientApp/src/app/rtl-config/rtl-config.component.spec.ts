import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RtlConfigComponent } from './rtl-config.component';

describe('RtlConfigComponent', () => {
  let component: RtlConfigComponent;
  let fixture: ComponentFixture<RtlConfigComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RtlConfigComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RtlConfigComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
