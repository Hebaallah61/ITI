import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddComponent } from './add/add.component';
import { DeleteComponent } from './delete/delete.component';
import { ErrorComponent } from './error/error.component';
import { StudentDetailsComponent } from './student-details/student-details.component';
import { StudentComponent } from './student/student.component';
import { UpdateComponent } from './update/update.component';

const routes: Routes = [
  {path:"",component:StudentComponent},
  {path:"student",component:StudentComponent},
  {path:"student/:id",component:StudentDetailsComponent},
  {path:"add",component:AddComponent},
 
  {path:"update/:id",component:UpdateComponent},
  {path:"delete/:id",component:DeleteComponent},
   {path:"**",component:ErrorComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
