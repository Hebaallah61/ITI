import { Component } from '@angular/core';

@Component({
  selector: 'app-compo1',
  templateUrl: './compo1.component.html',
  styleUrls: ['./compo1.component.css']
})
export class Compo1Component {
input:string="";
Rest(){
this.input="";
console.log(this.input);
}
}
