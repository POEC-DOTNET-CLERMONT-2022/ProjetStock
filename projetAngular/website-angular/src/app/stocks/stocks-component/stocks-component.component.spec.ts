import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StocksComponentComponent } from './stocks-component.component';

describe('StocksComponentComponent', () => {
  let component: StocksComponentComponent;
  let fixture: ComponentFixture<StocksComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StocksComponentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StocksComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
