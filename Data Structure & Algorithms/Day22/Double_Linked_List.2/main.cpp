#include <iostream>
#include<string.h>
using namespace std;
class Employee{
    public:
    int id,age;
    char gender,name[100],address[200];
    double salary,overtime,tax;
    Employee(){}
    Employee(int x,int y,char z[]){
    id=x;
    age=y;
    strcpy(name,z);
    }
};

class Node{
    public:
     Employee Data;
     Node *pnext;
     Node *pprev;
};

 Node *newnode(){
    Node *pnew=new Node;
    if(pnew==NULL) return 0;
    pnew->pnext=pnew->pprev=NULL;
    return pnew;
}

class queueue{
public:
    Node *pstart=NULL;
    Node *plast=NULL;

    queueue(){}


    int isfull(){
    return false;
    }


    int isempty(){
        if(pstart==NULL){
            return true;
        }
        else return false;
    }
public:
  void enqueue(Employee e){
    Node *pnew=newnode();
    pnew->Data.id=e.id;
    pnew->Data.age=e.age;
    strcpy(pnew->Data.name,e.name);

    if(isempty()){
        plast=pstart=pnew;
    }
    else{
        pnew->pprev=plast;
        plast->pnext=pnew;
        plast=pnew;
    }
}

void dequeue(){
    Node *pnew;
    pnew=pstart;
    if(isempty())
        cout<<"queue is empty";
    else if(pstart==plast){
            plast=pstart=NULL;
            delete[] pnew;
    }

    else{
        pstart->pnext->pprev=NULL;
        pstart=pnew->pnext;
        delete []pnew;
    }


}

void tope(){
    if(isempty()){
        cout<<"empty queue";
    }
    else

        cout<<pstart->Data.id<<' '<<pstart->Data.name<<' '<<pstart->Data.age<<endl;
}


void ssize(){
    int s=0;
    if(isempty())
        cout<<"empty queue!";
    else{
        Node* ptr=pstart;
        while(ptr!=NULL){
            s++;
            ptr=ptr->pnext;
        }
    }
    cout<<"size:"<<s<<endl;
}

void displayall(){
    Node *ptr=pstart;
    if(isempty())
        cout<<"empty queue.";
    else{

        while(ptr!=NULL){

            cout<<ptr->Data.id<<' '<<ptr->Data.name<<' '<<ptr->Data.age<<endl;
            ptr=ptr->pnext;
        }

}

}
};




int main()
{

    Employee e1(1,23,"hana");
    Employee e2(2,55,"sara");
    Employee e3(3,60,"alia");
    Employee e4(1,23,"ali");
    Employee e5(2,55,"nor");
    queueue x;
    x.enqueue(e1);
    x.enqueue(e2);
    x.enqueue(e3);
    x.enqueue(e4);
    x.enqueue(e5);
    x.tope();
    x.ssize();
    x.displayall();
    x.dequeue();
    x.tope();
    x.displayall();
    return 0;
}
