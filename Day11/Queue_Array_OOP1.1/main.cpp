#include <iostream>
#define Max 5

using namespace std;
class Queue
{
    int *qu, head, tail,Size,counter=0;

    public:
    Queue(int len) {
        Size=len;
        qu = new int[Size];
        head = tail = -1;
    }

    ~Queue(){
        cout<<"destructor\n";
        delete[] qu;
    }
    bool isfull(){
        return(getcount()==Size);
    }
    bool isempty(){
        return(getcount()==0);
    }

    void enqueue(int n) {
        if(isfull()){
         cout<<"Queue is full\n";
        }
         else {
            qu[tail++]=n;
            counter++;
        }
    }


    int dequeue() {
        int i;
        if(isempty()){
            cout<<"Queue is empty\n";

        } else {
            int temp=qu[0];
            for(i=0;i<tail;i++){
                qu[i]=qu[i+1];
            }
            tail--;
            counter--;
        }
    }

    int peak(){
        return qu[tail];
    }

    int getcount(){
        return counter;
    }



};


int main()
{

    int Size_s;
    int n,i,choice;
    cout<<"Enter Size of Queue: ";
    cin>>Size_s;
    Queue q(Size_s);
    cout<<"\n\n Enter your choice :"
            <<"\n 1. enqueue an element into Queue."
            <<"\n 2. dequeue an element from Queue."
            <<"\n 3. Exit the program.\n"
            <<"\n 4. peak element.\n"
            <<"\n 5. print counter.\n";
            cin>>choice;
    while(choice != 4)
    {
        switch (choice) {
            case 1:
                cout<<"\nEnter a Number: ";
                cin>>n;
                q.enqueue(n);
                break;
            case 2:
                q.dequeue();
                break;
            case 4:
                q.peak();
                break;
            case 5:
                q.getcount();
                break;
            case 3:
                break;
        }
        cout<<"\nEnter your Choice: ";
        cin>>choice;
    }

    return 0;
}
