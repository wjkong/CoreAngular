import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OnlineRebateComponent } from './online-rebate.component';

describe('OnlineRebateComponent', () => {
  let component: OnlineRebateComponent;
  let fixture: ComponentFixture<OnlineRebateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OnlineRebateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OnlineRebateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
