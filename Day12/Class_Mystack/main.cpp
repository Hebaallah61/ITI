#include <iostream>

using namespace std;

class Stack{
int *st;///st[5] convert to pointer
int tos;
int Size;
public:
    Stack(int len=5){
        //cout<<"stack ctor\n";
        Size=len;
        tos=0;
        st=new int[Size];

    }



    ~Stack(){
    int i;
    for(i=0;i<tos;i++)
        st[i]=-1;
    //cout<<"destructor\n";
    delete[] st;

    }

    int isfull(){///bool is okay
        if(tos==Size)///0
            return 1;
        else
            return 0;
    ///int isfull() return(tos==5);
    }
     int isempty(){ ///bool is okay
        return(tos==0);

     }

     void Push(int n){ ///put the number without return
     if(!isfull())
        st[tos++]=n;
     else
        cout<<"stack is full\n";


     }

     int pop(){///return the number
        if(!isempty())
            return st[--tos];
        else{
            cout<<"stack is empty\n";
            return -1;
        }


     }


     int peak(){
        int temp=0;
        if(!isempty()){
            temp=st[tos-1];
            return temp;
        }

        else{
            cout<<"stack is empty\n";
            return -1;
        }

     }


     Stack reverse_fun(){

        Stack r;
        int temp=tos,i;
        for(i=0;i<tos+i;i++){
            r.Push(peak());
            tos--;

        }
        tos=temp;

        return r;

}


friend void view_content(Stack s);

};


///without CC(copy constructor)
void view_content(Stack s){
    int i;
    for(i=0;i<s.tos;i++)///without friend it will be compilation error
        cout<<s.st[i]<<endl;

}



int main()
{
    int Size_s,flag=0;
    int n,i,choice;
    Stack s1,s2;
    cout<<"Enter Size of Stack: ";
    cin>>Size_s;
    Stack sttest(Size_s);
    for(i=0;i<Size_s;i++){
        cout<<"\nEnter a Number: ";
        cin>>n;
        sttest.Push(n);
    }

    cout<<"1-pop\n2-peak\n3-view all\n4-reverse\n0-exit\n";
    cout<<"\nEnter your Choice: ";
    cin>>choice;
    do{
    switch(choice){
    case 1:
        cout<<sttest.pop()<<endl;
        break;
    case 2:
        cout<<sttest.peak()<<endl;
        break;
    case 3:
        view_content(sttest);
           break;
    case 4:
        cout<<sttest.reverse_fun().pop()<<endl;

        break;
    case 0:
        break;
    }
    cout<<"\nEnter your Choice: ";
    cin>>choice;
    }while(choice!=0);

    return 0;
}
