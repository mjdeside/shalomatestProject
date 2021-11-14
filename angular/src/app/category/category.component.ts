import { Component, Injector, OnInit } from '@angular/core';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { CategoryServiceProxy, CreateOrEditCategory, GetCategoryOutput, GetCategoryOutputList, PagedCategoryResultRequestDto } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { CreateOrEditCategoryComponent } from './create-or-edit-category/create-or-edit-category.component';
class CategoryInput extends PagedRequestDto {
  keyword: string;
}

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css'],
  animations: [appModuleAnimation()]
})
export class CategoryComponent  extends PagedListingComponentBase<GetCategoryOutputList>  implements OnInit  {
  
  keyword = '';
  categoryList : GetCategoryOutputList[];

  constructor(  
    private _categoryServiceProxy: CategoryServiceProxy,
    injector: Injector,
    private _modalService: BsModalService) {
    super(injector);
  }

  ngOnInit(): void {
    this.refresh();
  }

  protected list(request: CategoryInput, pageNumber: number, finishedCallback: Function): void {
    request.keyword = this.keyword;
    this._categoryServiceProxy.getAllFilter(
      request.keyword,
      request.skipCount,
      request.maxResultCount
      ).pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe(result => {
        this.categoryList = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  protected delete(entity: GetCategoryOutputList): void {
    abp.message.confirm(
      this.l('CategoryDeleteWarningMessage', entity.category.categoryName),
      undefined,
      (result: boolean) => {
        if (result) {
          this._categoryServiceProxy.delete(entity.category.id).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.refresh();
          });
        }
      }
    );
  }

  createOrEditCategory(Id?:number){
    let createOrEditCategory: BsModalRef;
    if(!Id){
      createOrEditCategory = this._modalService.show(
        CreateOrEditCategoryComponent,
        {
          class: 'modal-lg',
        }
      );
    }
    else{
      createOrEditCategory = this._modalService.show(
        CreateOrEditCategoryComponent,
        {
          class: 'modal-lg',
          initialState: {
            Id: Id,
          },
        },
      );
    }
    createOrEditCategory.content.onSave.subscribe(() => {
      this.refresh();
    });

  }
  
  
}
