import { Component, Output, EventEmitter } from '@angular/core';
interface Student {
  name: string;
  age: string;
}

@Component({
  selector: 'app-reg',
  templateUrl: './reg.component.html',
  styleUrls: ['./reg.component.css']
})

export class RegComponent {
  name = '';
  age = '';
  @Output() studentAdded = new EventEmitter<Student>();

  addStudent() {
    const newStudent: Student = { name: this.name, age: this.age };
    this.studentAdded.emit(newStudent);

    this.name = '';
    this.age = '';
  }
}