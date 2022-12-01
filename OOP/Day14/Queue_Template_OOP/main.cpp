#include <iostream>
#define Max_len 10
using namespace std;
template<class T>///any type you pass
class Queue{

    T *qu;///qu[Max_len]
    int head,tail,Size,counter=0;

public:
    Queue(int Maxlen=5){
        cout<<"queue ctor\n";
        tail=-1;
        head=-1;
        Size=Maxlen;
        qu=new T[Size];
    }

    Queue(Queue& old){
        tail=old.tail;
        head=old.head;
        Size=old.Size;
        qu=new T[Size];
        for(int i=0;i<tail;i++)
          qu[i]=old.qu[i];
    }



    ~Queue(){
        cout<<"destructor\n";
        delete[] qu;
    }

    bool isfull(){
        return(head==0&&tail==Size-1);
    }
    bool isempty(){
        return(head==-1);
    }
    void enqueue(T n){
        if(isfull()){
         cout<<"Queue is full\n";
        }
       else{
            if(head==-1) head=0;
            tail++;
            qu[tail]=n;
            counter++;
       }


       }




    T dequeu(){
        T n;
        if(isempty()){
            cout<<"Queue is empty\n";
            return -1;
        }
        else{
            n=qu[head];

            counter--;
            if(head>=tail){
                head= -1;
                tail= -1;
            }

            else{
                head++;
                //--;
            }

        return n;

    }
    }


    T peak(){

       T temp;
        if(!isempty()){
            temp=qu[head];
            return temp;
        }

        else{
            cout<<"queue is empty\n";
            return -1;
        }


    }
    void getcount(){
        cout<<"Count is: ";
        cout<<counter;

    }

void  view();

};


///member function
template <class T>
void Queue<T>::view(){
    for(int i=0;i<tail+1;i++)
        cout<<qu[i]<<endl;
}

int main()
{


    int Size_s1,Size_s2;
    int n,i,choice;
    char m;
    cout<<"Enter Size of Queue1(integer): ";
    cin>>Size_s1;
    Queue<int> q1(Size_s1);
    cout<<"Enter Size of Queue2(char): ";
    cin>>Size_s2;
    Queue<char> q2(Size_s2);
    for(i=0;i<Size_s1;i++){
        cout<<"\nEnter a Number in queue1: ";
        cin>>n;
        q1.enqueue(n);
    }

    for(i=0;i<Size_s2;i++){
        cout<<"\nEnter a char in queue2: ";
        cin>>m;
        q2.enqueue(m);
    }


    cout<<"1-dequeue int q1\n2-peak int q1\n3-enqueue int q1\n4-q1 counter\n5-dequeue char q2\n6-peak char q2\n7-enqueue char q2\n8-q2 counter\n9-view q1\n10-view q2\n0-exit\n";
    cout<<"\nEnter your Choice: ";
    cin>>choice;
    do{
    switch(choice){
    case 1:
        cout<<q1.dequeu()<<endl;
        break;
    case 2:
        cout<<q1.peak()<<endl;
        break;
    case 3:
        cout<<"\nEnter a Number: ";
        cin>>n;
        q1.enqueue(n);
        break;
    case 4:
        q1.getcount();

        break;
    case 5:
        cout<<q2.dequeu()<<endl;
        break;
    case 6:
        cout<<q2.peak()<<endl;
        break;
    case 7:
        cout<<"\nEnter a char: ";
        cin>>m;
        q2.enqueue(m);
        break;
    case 8:
        q2.getcount();
        break;
    case 9:
        q1.view();
        break;
    case 10:
        q2.view();
        break;
    case 0:
        break;
    }
    cout<<"\nEnter your Choice: ";
    cin>>choice;
    }while(choice!=0);


    return 0;
}
