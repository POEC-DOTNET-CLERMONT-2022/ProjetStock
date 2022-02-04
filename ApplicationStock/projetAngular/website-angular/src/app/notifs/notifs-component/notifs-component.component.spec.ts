import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NotifsComponentComponent } from './notifs-component.component';

describe('NotifsComponentComponent', () => {
  let component: NotifsComponentComponent;
  let fixture: ComponentFixture<NotifsComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NotifsComponentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NotifsComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
