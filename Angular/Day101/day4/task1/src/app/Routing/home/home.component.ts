import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  formValidation=new FormGroup({
    name:new FormControl("Nour",[Validators.minLength(4),Validators.required]),
    age:new FormControl(22,[Validators.min(20),Validators.max(40),Validators.required]),
    email:new FormControl(null,[Validators.email,Validators.required])
  })
get nameVal(){
return this.formValidation.controls["name"].valid
}

get ageVal(){
  return this.formValidation.controls["age"].valid
  }

  get emailVal(){
    return this.formValidation.controls["email"].valid
    }

  alertfun(){
    if(this.formValidation.valid){
      alert("Data Is Valid");
    }else{
      alert("Data Not Valid")
    }
  }
}
