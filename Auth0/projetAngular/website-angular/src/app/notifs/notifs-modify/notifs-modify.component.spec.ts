import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NotifsModifyComponent } from './notifs-modify.component';

describe('NotifsModifyComponent', () => {
  let component: NotifsModifyComponent;
  let fixture: ComponentFixture<NotifsModifyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NotifsModifyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NotifsModifyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
