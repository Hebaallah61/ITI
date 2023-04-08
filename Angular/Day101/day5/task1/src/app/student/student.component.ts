import { Component, OnInit } from '@angular/core';
import { StudentsService } from '../Service/students.service';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})

export class StudentComponent implements OnInit {
  constructor(private myservice:StudentsService){}
  students:any;
  ngOnInit(): void {
    this.myservice.getAllstudents().subscribe(
      {
      next:(data)=>{
        this.students=data;
      },
      error:(err)=>{}
    });
  }

}
