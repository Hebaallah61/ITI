#include <iostream>
#define Max_len 10
using namespace std;

class Queue{

    int qu[Max_len],head,tail,Size,counter=0;

public:
    Queue(int Maxlen){
    cout<<"queue ctor\n";
    tail=-1;
    head=-1;
    ///Size=0;
    //int Size_len[Maxlen];
    Size=Maxlen;
    //qu=new int[Size];
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
    void enqueue(int n){
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




    int dequeu(){
        int n;
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


    int peak(){

       int temp=0;
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



};

int main()
{


    int Size_s;
    int n,i,choice;
    cout<<"Enter Size of Queue: ";
    cin>>Size_s;
    Queue q1(Size_s);
    for(i=0;i<Size_s;i++){
        cout<<"\nEnter a Number: ";
        cin>>n;
        q1.enqueue(n);
    }


    cout<<"1-dequeue\n2-peak\n3-enqueue\n4-\counter\n0-exit\n";
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
    case 0:
        break;
    }
    cout<<"\nEnter your Choice: ";
    cin>>choice;
    }while(choice!=0);

    /*q1.dequeu();
    q1.enqueue(10);
    q1.enqueue(11);
    q1.enqueue(12);
    q1.dequeu();*/

    return 0;
}
