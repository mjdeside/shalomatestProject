import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateorEditProductComponent } from './createor-edit-product.component';

describe('CreateorEditProductComponent', () => {
  let component: CreateorEditProductComponent;
  let fixture: ComponentFixture<CreateorEditProductComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateorEditProductComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateorEditProductComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
