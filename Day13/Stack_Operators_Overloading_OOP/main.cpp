#include <iostream>

using namespace std;

class Stack{
int *st;///st[5] convert to pointer
int tos;
int Size;
public:
    Stack(int s=5){
        //cout<<"stack ctor\n";
        Size=s;
        tos=0;
        st=new int[Size];

    }

    ///CC(copy constractotr)----------------------------
    Stack(Stack &oldst){
        tos=oldst.tos;
        Size=oldst.Size;
        st=new int [Size];
        for(int i=0;i<Size;i++)
         st[i]=oldst.st[i];
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
///reverse

     /*Stack reverse_fun(){

        Stack r;

        for(int i=tos-1 ;i >= 0 ;i--){
            r.Push(st[i]);
        }

        return r;

    }*/
    Stack reverse_fun()
    {
        Stack R(*this);

        for (int i=0; i<tos/2; i++)
        {
            int temp = st[i];
             R.st[i] = st[tos-i-1];
             R.st[tos-i-1]= temp;
        }

        return R;
    }
///equality function
Stack &operator=(const Stack &r){///r is another name foe st
    delete[] st;
    Size=r.Size;
    tos=r.tos;
    st=new int[Size];
    for(int i=0;i<tos;i++)
        st[i]=r.st[i];
    return *this;
}
///[]operator overloading
int & operator[](int index){
    if((index>=0)&&(index<tos))
        return st[index];

}

///+operator overloading(concatenate)
Stack operator+(const Stack &st2){
  int tempsize=Size+st2.Size;
  Stack con(tempsize+1);
  for(int i=0;i<tos;i++){
    con.Push(st[i]);
  }
  for(int i=0;i<st2.tos;i++){
    con.Push(st2.st[i]);
  }

  return con;

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
    int Size_s1,Size_s2,flag=0;
    int n,i,choice;
    Stack s1,s2,s3;
    cout<<"Enter Size of Stack1: ";
    cin>>Size_s1;
    Stack sttest;
    cout<<"Enter Size of Stack2: ";
    cin>>Size_s2;
    Stack sttest2;
    Stack sttest3,sttemp;
    for(i=0;i<Size_s1;i++){
        cout<<"\nEnter a Number in stack 1: ";
        cin>>n;
        sttest.Push(n);
    }

    for(i=0;i<Size_s2;i++){
        cout<<"\nEnter a Number in stack 2: ";
        cin>>n;
        sttest2.Push(n);
    }

    cout<<"1-pop\n2-peak\n3-view all\n4-reverse\n5-test(stack3=stack1)\n6-test(stack1[1])\n7-test(stack1+stack2)\n0-exit\n";
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
        s3=sttest.reverse_fun();
        view_content(s3);
        break;
    case 5:
        sttest3=sttest;
        cout <<"test for stack3 pop is: " <<sttest3.pop() <<endl;
        break;
    case 6:
        cout <<"test for stack1[1]:"<<sttest[1]<<endl;
        break;
    case 7:
        sttemp=sttest+sttest2;
        view_content(sttemp);
        break;
    case 0:
        break;
    }
    cout<<"\nEnter your Choice: ";
    cin>>choice;
    }while(choice!=0);

    return 0;
}
