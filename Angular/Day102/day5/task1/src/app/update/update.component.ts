// import { Component, OnInit } from '@angular/core';
// import { ActivatedRoute, Route } from '@angular/router';
// import { StudentsService } from '../Service/students.service';

// @Component({
//   selector: 'app-update',
//   templateUrl: './update.component.html',
//   styleUrls: ['./update.component.css']
// })
// // export class UpdateComponent implements OnInit{


// //   ID:any;
// //   student:any;
// //   constructor(myActivated:ActivatedRoute, private myService:StudentsService){
// //     this.ID = myActivated.snapshot.params["id"];
// //   }
// //   ngOnInit(): void {
// //     this.myService.getstudentByID(this.ID).subscribe({
// //       next:(data)=>{
// //         this.student = data;
// //       },
// //       error:(err)=>{console.log(err)},
// //     })
// //   }

// //   onsubmit(){

// //   }
// // }
// export class UpdateComponent implements OnInit{
//   constructor(private myActivated:ActivatedRoute, private myService:StudentsService,private readonly route:Route){ }
// studentselected:any={
//   id=null,
//   name:null,
//   age:null,
//   email:null,
//   phone:null,
//   courses:null,
// };

// ngOnInit():void{
//   let stid=this.myActivated.snapshot.params["id"];
// if(stid){
//   this.myService.getstudentByID(stid).subscribe({

//     next:(data)=>{
//               this.studentselected = data;
//             },
//             error:(err)=>{console.log(err)},
//   });
// }
// }
// onsubmit(){
//   if(this.studentselected.id){
//     this.myService.UpdatestudentByID(this.studentselected.id,this.studentselected).subscribe({
//       next:(data)=>{
//         this.route.navigate(['/']);
//       },
//       error:(err)=>{console.log(err);
//       }
//     });
//   }else{
//     this.myService.AddNewstudent(this.studentselected).subscribe({
//       next:(data)=>{
//         this.route.navigate(['/']);
//       },
//       error:(err)=>{console.log(err);
      
//   }
// });
//   }
// }
// }
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StudentsService } from '../Service/students.service';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit{
  studentselected:any={
    id: null,
    name: null,
    age: null,
    email: null,
    phone: null,
    courses: null,
  };

  constructor(private myActivated: ActivatedRoute, private myService: StudentsService, private router: Router) { }

  ngOnInit(): void {
    let stid = this.myActivated.snapshot.params["id"];
    if(stid){
      this.myService.getstudentByID(stid).subscribe({
        next: (data) => {
          this.studentselected = data;
        },
        error: (err) => {
          console.log(err);
        },
      });
    }
  }

  onSubmit() {
    if(this.studentselected.id){
      this.myService.UpdatestudentByID(this.studentselected.id, this.studentselected).subscribe({
        next: (data) => {
          this.router.navigate(['/']);
        },
        error: (err) => {
          console.log(err);
        }
      });
    } else {
      this.myService.AddNewstudent(this.studentselected).subscribe({
        next: (data) => {
          this.router.navigate(['/']);
        },
        error: (err) => {
          console.log(err);
        }
      });
    }
  }
}
