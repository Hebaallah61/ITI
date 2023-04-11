import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent {
  // id=0; 
  User:{id:number,name:string,age:string,country:string}={id:1,name:"Heba",age:"22",country:"London"} 
  constructor(myact:ActivatedRoute){
    this.User.id=myact.snapshot.params["id"];
    console.log(this.User.id);
  }
}
