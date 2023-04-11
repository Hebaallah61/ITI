import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StudentsService } from '../Service/students.service';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent {
  studentselected:any={
    name: null,
    age: null,
    email: null,
    phone: null,
    courses: null,
  };

  constructor(private myActivated: ActivatedRoute, private myService: StudentsService, private router: Router) { }

  // ngOnInit(): void {
  //   let stid = this.myActivated.snapshot.params["id"];
  //   if(stid){
  //     this.myService.getstudentByID(stid).subscribe({
  //       next: (data) => {
  //         this.studentselected = data;
  //       },
  //       error: (err) => {
  //         console.log(err);
  //       },
  //     });
  //   }
  // }

  onSubmit() {
   
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
