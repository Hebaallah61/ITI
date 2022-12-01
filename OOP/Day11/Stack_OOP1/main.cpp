#include <iostream>

using namespace std;
class Stack{
int *st;///st[5] convert to pointer
int tos;
int Size;
public:
    Stack(int len){
        cout<<"stack ctor\n";
        Size=len;
        tos=0;
        st=new int[Size];

    }

    ~Stack(){
    cout<<"destructor\n";
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





};
int main()
{
    int Size_s,flag=0;
    int n,i,choice;
    cout<<"Enter Size of Stack: ";
    cin>>Size_s;
    Stack sttest(Size_s);
    for(i=0;i<Size_s;i++){
        cout<<"\nEnter a Number: ";
        cin>>n;
        sttest.Push(n);
    }
    /*sttest.Push(3);
    sttest.Push(4);
    sttest.Push(5);*/
    cout<<"1-pop\n2-peak\n0-exit\n";
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
    case 0:
        break;
    }
    cout<<"\nEnter your Choice: ";
    cin>>choice;
    }while(choice!=0);
    /*cout<<sttest.pop()<<endl;
    cout<<sttest.peak()<<endl;
    cout<<sttest.peak()<<endl;
    cout<<sttest.pop()<<endl;*/
    return 0;
}
