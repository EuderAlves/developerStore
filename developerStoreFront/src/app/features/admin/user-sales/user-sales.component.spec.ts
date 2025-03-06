import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserSalesComponent } from './user-sales.component';

describe('UserSalesComponent', () => {
  let component: UserSalesComponent;
  let fixture: ComponentFixture<UserSalesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UserSalesComponent]
    });
    fixture = TestBed.createComponent(UserSalesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
