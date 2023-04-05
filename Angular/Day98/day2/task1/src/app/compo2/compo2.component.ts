import { Component } from '@angular/core';

@Component({
  selector: 'app-compo2',
  templateUrl: './compo2.component.html',
  styleUrls: ['./compo2.component.css']
})
export class Compo2Component {
interval:any;
img:number=1;
slide(move:number){
  if(this.img==7 && move==1)return
  if(this.img==1 && move==-1)return
  this.img+=move;
}
play(){
this.interval=setInterval(()=>{
  if(this.img==7)this.img=1
  else this.slide(1)
},1000)
}
stop(){
clearInterval(this.interval);
}
}
