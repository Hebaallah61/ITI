import { Component } from '@angular/core';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})
export class StudentsComponent {
students:{name:string,age:string,country:string}[]=[
  {name:"Heba",age:"22",country:"London"},
  {name:"Ali",age:"22",country:"London"},
  {name:"Mohammed",age:"25",country:"London"},
  {name:"Ahmed",age:"23",country:"Los"},
  {name:"Nour",age:"22",country:"Los"},
  {name:"Tarak",age:"25",country:"UK"},

]
}
