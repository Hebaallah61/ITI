import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { StudentsService } from '../Service/students.service';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.css']
})
export class DeleteComponent implements OnInit {
  ID:any;
  student:any;
  constructor(myActivated:ActivatedRoute, private myService:StudentsService,private router: Router){
    this.ID = myActivated.snapshot.params["id"];
  }
  ngOnInit(): void {
    this.myService.getstudentByID(this.ID).subscribe({
      next:(data)=>{
        this.student = data;
      },
      error:(err)=>{console.log(err)},
    })
  }

  Delete(){
    if(this.student){
      this.myService.DeletestudentByID(this.ID).subscribe({
        next: (data) => {
          this.router.navigate(['/']);
        },
        error: (err) => {
          console.log(err);
        }
      })
    }
  }
}
