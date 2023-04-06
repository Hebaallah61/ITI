import { Component,Input } from '@angular/core';
interface Student {
  name: string;
  age: string;
}
@Component({
  selector: 'app-data-show',
  templateUrl: './data-show.component.html',
  styleUrls: ['./data-show.component.css']
})
export class DataShowComponent {
  @Input() students: Student[] = [];
}
