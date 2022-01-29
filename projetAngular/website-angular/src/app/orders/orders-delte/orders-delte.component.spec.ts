import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrdersDelteComponent } from './orders-delte.component';

describe('OrdersDelteComponent', () => {
  let component: OrdersDelteComponent;
  let fixture: ComponentFixture<OrdersDelteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrdersDelteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrdersDelteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
