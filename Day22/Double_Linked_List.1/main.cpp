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


class Stack{

  public:

     Stack(){}
     Node *pstart=NULL;
     Node *ptop=NULL;

    int isfull(){
        return false;
    }


    int isempty(){
        if(pstart==NULL){
            return true;
        }
        else return false;
    }

    void push(Employee e){
        Node *pnew=newnode();
        pnew->Data.id=e.id;
        pnew->Data.age=e.age;
        strcpy(pnew->Data.name,e.name);

        if(isempty()){
            ptop=pstart=pnew;
        }
        else{
            ptop->pnext=pnew;
            pnew->pprev=ptop;
            ptop=pnew;
        }
    }

        void pop(){
            Node *pnew;
            pnew=ptop;
            if(isempty())
                cout<<"stack is empty";
            else if(ptop==pstart){
                    ptop=NULL;
                    pstart=NULL;
                    delete[] pnew;
            }

            else{
                ptop->pprev->pnext=NULL;
                ptop=pnew->pprev;
                delete []pnew;
            }


        }

        void tope(){
            if(isempty()){
                cout<<"empty stack";
            }
            else

                cout<<ptop->Data.id<<' '<<ptop->Data.name<<' '<<ptop->Data.age<<endl;
        }


        void ssize(){
            int s=0;
            if(isempty())
                cout<<"empty stack!";
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
                cout<<"empty stack.";
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
    Stack x;
    Employee e1(1,23,"hana");
    Employee e2(2,55,"sara");
    Employee e3(3,60,"alia");
    x.push(e1);
    x.push(e2);
    x.push(e3);
    x.ssize();
    x.pop();
    x.tope();
    x.ssize();
    x.displayall();
    return 0;
}
