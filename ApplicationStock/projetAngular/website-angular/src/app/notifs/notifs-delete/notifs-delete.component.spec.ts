import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NotifsDeleteComponent } from './notifs-delete.component';

describe('NotifsDeleteComponent', () => {
  let component: NotifsDeleteComponent;
  let fixture: ComponentFixture<NotifsDeleteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NotifsDeleteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NotifsDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
