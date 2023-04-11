import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Compo2Component } from './compo2.component';

describe('Compo2Component', () => {
  let component: Compo2Component;
  let fixture: ComponentFixture<Compo2Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Compo2Component ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Compo2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
