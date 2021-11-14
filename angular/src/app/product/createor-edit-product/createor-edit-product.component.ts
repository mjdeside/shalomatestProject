import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { CategoryServiceProxy, CreateOrEditProduct, GetCategoryOutputList, ProductServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-createor-edit-product',
  templateUrl: './createor-edit-product.component.html',
  styleUrls: ['./createor-edit-product.component.css']
})
export class CreateorEditProductComponent extends AppComponentBase implements OnInit {

  @Output() onSave = new EventEmitter<any>();
  product: CreateOrEditProduct = new CreateOrEditProduct();
  categoryList: GetCategoryOutputList[] = [];
  saving = false;
  Title = 'Create Product';
  Id:number;

  constructor(
    public bsModalRef: BsModalRef, 
    private _productServiceProxy: ProductServiceProxy,
    private _categoryserviceProxy: CategoryServiceProxy,
    injector: Injector
    )
     {
      super(injector);
     }

  ngOnInit(): void {

    if(this.Id){
        this._productServiceProxy.getProductById(this.Id).subscribe(result=>{
            this.product = result;
            this.Title = 'Edit Product';
        });
    }
    this._categoryserviceProxy.getAll().subscribe(result=>{
      this.categoryList = result;
      console.log(this.categoryList);
    });
  
  }

  save():void{
    this.saving = true;
    this._productServiceProxy.createOrEdit(this.product).subscribe( () => {
      this.saving = false;
      this.notify.info(this.l('SavedSuccessfully'));
      this.bsModalRef.hide();
      this.onSave.emit();
    },
    () => {
      this.saving = false;
    });
  }

}
