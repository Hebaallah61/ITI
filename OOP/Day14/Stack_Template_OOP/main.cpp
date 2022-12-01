#include <iostream>

using namespace std;
template <class T>
class Stack{
T *st;///st[5] convert to pointer
int tos;
int Size;
public:
    Stack(int s=5){
        //cout<<"stack ctor\n";
        Size=s;
        tos=0;
        st=new T[Size];

    }

    ///CC(copy constractotr)----------------------------
    Stack(Stack &oldst){
        tos=oldst.tos;
        Size=oldst.Size;
        st=new T [Size];
        for(int i=0;i<tos;i++)
         st[i]=oldst.st[i];
    }

    ~Stack(){
    int i;
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

     void Push(T n){ ///put the number without return
     if(!isfull())
        st[tos++]=n;
     else
        cout<<"stack is full\n";


     }

     T pop(){///return the number
        if(!isempty())
            return st[--tos];
        else{
            cout<<"stack is empty\n";
            return -1;
        }


     }


     T peak(){
        T temp;
        if(!isempty()){
            temp=st[tos-1];
            return temp;
        }

        else{
            cout<<"stack is empty\n";
            return -1;
        }

     }

    Stack reverse_fun()
    {
        Stack R(*this);

        for (int i=0; i<tos/2; i++)
        {
             T temp = st[i];
             R.st[i] = st[tos-i-1];
             R.st[tos-i-1]= temp;
        }

        return R;
    }


///view function
void  view();

};


///member function
template <class T>
void Stack<T>::view(){
    for(int i=0;i<tos;i++)
        cout<<st[i]<<endl;
}


int main()
{
    int Size_s1,Size_s2,flag=0;
    int n,i,choice;
    char m;
    cout<<"Enter Size of Stack1(integer): ";
    cin>>Size_s1;
    Stack<int>s3;
    Stack<char>s4;
    Stack<int>s1(Size_s1);
    cout<<"Enter Size of Stack2(char): ";
    cin>>Size_s2;
    Stack<char>s2(Size_s2);
    for(i=0;i<Size_s1;i++){
        cout<<"\nEnter a Number in stack 1: ";
        cin>>n;
        s1.Push(n);
    }

    for(i=0;i<Size_s2;i++){
        cout<<"\nEnter a char in stack 2: ";
        cin>>m;
        s2.Push(m);
    }

    cout<<"1-pop int s1\n2-peak int s1\n3-view all s1\n4-reverse int s1\n5-pop char s2\n6-peak char s2\n7-view all char s2\n8-reverse char s2\n0-exit\n";
    cout<<"\nEnter your Choice: ";
    cin>>choice;
    do{
    switch(choice){
    case 1:
        cout<<s1.pop()<<endl;
        break;
    case 2:
        cout<<s1.peak()<<endl;
        break;
    case 3:
        s1.view();
           break;
    case 4:
        s3=s1.reverse_fun();
        s3.view();
        break;
    case 5:
        cout<<s2.pop()<<endl;
        break;
    case 6:
        cout<<s2.peak()<<endl;
        break;
    case 7:
        s2.view();
           break;
    case 8:
        s4=s2.reverse_fun();
        s4.view();
        break;
    case 0:
        break;
    }
    cout<<"\nEnter your Choice: ";
    cin>>choice;
    }while(choice!=0);

    return 0;
}
