import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchaseItemsComponent } from './purchase-items.component';

describe('PurchaseItemsComponent', () => {
  let component: PurchaseItemsComponent;
  let fixture: ComponentFixture<PurchaseItemsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PurchaseItemsComponent]
    });
    fixture = TestBed.createComponent(PurchaseItemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
