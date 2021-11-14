import { Component, Injector, OnInit } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import {  GetProductOutputList, ProductServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { CreateorEditProductComponent } from './createor-edit-product/createor-edit-product.component';

class ProductInput extends PagedRequestDto {
  keyword:string;
}

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
  animations: [appModuleAnimation()]
})
export class ProductComponent   extends PagedListingComponentBase<GetProductOutputList>  implements OnInit {

  
  keyword = '';
  productList: GetProductOutputList[];
  advancedFiltersVisible = false;
  constructor(
    private _productServiceProxy: ProductServiceProxy,
    injector:Injector,
    private _modalService: BsModalService
    ) 
  {
    super(injector);
  }

  ngOnInit(): void {
    this.refresh();

  }

  protected list(request: ProductInput, pageNumber: number, finishedCallback: Function): void {
    request.keyword = this.keyword;
    console.log(this.keyword);
    this._productServiceProxy.getAll(
      request.keyword,
      request.skipCount,
      request.maxResultCount).pipe(
        finalize(() => {
          finishedCallback();
        })
      ).subscribe(result=>{
        this.productList = result.items;
        this.showPaging(result, pageNumber);
      });

  }

  protected delete(entity: GetProductOutputList): void {
    abp.message.confirm(
      this.l('ProductDeleteWarningMessage', entity.category.categoryName),
      undefined,
      (result: boolean) => {
        if (result) {
          this._productServiceProxy.delete(entity.product.id).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.refresh();
          });
        }
      }
    );
  }

  createOrEditProduct(Id?:number){
    let createOrEditProduct: BsModalRef;
    if(!Id){
      createOrEditProduct = this._modalService.show(
        CreateorEditProductComponent,
        {
          class: 'modal-lg',
        }
      );
    }
    else{
      createOrEditProduct = this._modalService.show(
        CreateorEditProductComponent,
        {
          class: 'modal-lg',
          initialState: {
            Id: Id,
          },
        },
      );
    }
    createOrEditProduct.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

}
