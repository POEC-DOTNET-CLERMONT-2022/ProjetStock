import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StocksUpdateComponent } from './stocks-update.component';

describe('StocksUpdateComponent', () => {
  let component: StocksUpdateComponent;
  let fixture: ComponentFixture<StocksUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StocksUpdateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StocksUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
