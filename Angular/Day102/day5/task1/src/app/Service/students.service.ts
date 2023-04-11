import { Injectable } from '@angular/core';
import{HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class StudentsService {

  constructor(private readonly myclient:HttpClient) { }
  private readonly URL = "http://localhost:3000/student";
  getAllstudents(){
    return this.myclient.get(this.URL);
  }
  getstudentByID(id:any){
    return this.myclient.get(this.URL+'/'+id);
  }
  AddNewstudent(user:any){
    return this.myclient.post(this.URL, user);
  }

  UpdatestudentByID(id:any,user:any){
    return this.myclient.put(this.URL+"/"+id, user);
  }

  DeletestudentByID(id:any){
    return this.myclient.delete(this.URL+"/"+id);
  }

}
