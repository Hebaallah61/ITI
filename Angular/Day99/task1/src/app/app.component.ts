import { Component } from '@angular/core';
interface Student {
  name: string;
  age: string;
}
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'task1';
  students: Student[] = [];

  onStudentAdded(student: Student) {
    if (+student.age <= 40 && +student.age >= 20 && student.name.length>=3) {
    
    this.students.push(student);
    }
}
}
