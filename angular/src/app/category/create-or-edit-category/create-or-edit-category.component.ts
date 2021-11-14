import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { CategoryServiceProxy, CreateOrEditCategory } from '@shared/service-proxies/service-proxies';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-create-or-edit-category',
  templateUrl: './create-or-edit-category.component.html',
  styleUrls: ['./create-or-edit-category.component.css']
})
export class CreateOrEditCategoryComponent  extends AppComponentBase implements OnInit {

  Id:number;
  @Output() onSave = new EventEmitter<any>();

  name:string = "";
  Title = "Create Category";
  category: CreateOrEditCategory =new CreateOrEditCategory();
  saving = false;
 


  constructor(
    public bsModalRef: BsModalRef, 
    private _categoryServiceProxy: CategoryServiceProxy,
    injector: Injector
    )
     {
      super(injector);
     }

  ngOnInit(): void {
    
    if(this.Id){
      this._categoryServiceProxy.getCategoryById(this.Id).subscribe(result=>{
        this.category = result;
      });
      this.Title ='Edit Category';
    }
    
  }
  save(){

    this.saving = true;
    this._categoryServiceProxy.createOrEdit(this.category).subscribe( () => {
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
