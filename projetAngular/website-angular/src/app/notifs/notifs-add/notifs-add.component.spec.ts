import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NotifsAddComponent } from './notifs-add.component';

describe('NotifsAddComponent', () => {
  let component: NotifsAddComponent;
  let fixture: ComponentFixture<NotifsAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NotifsAddComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NotifsAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
