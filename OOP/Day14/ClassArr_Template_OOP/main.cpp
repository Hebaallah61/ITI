#include <iostream>

using namespace std;
template<class T>///passing any type
class intArr{
    T *arr;
    int Size;
public:
    intArr(int s){
        Size=s;
        arr=new T[Size];
    }

    intArr(const intArr &oldarr){
        Size=oldarr.Size;
        arr=new T[Size];
        for(int i=0;i<Size;i++)
            arr[i]=oldarr.arr[i];
    }
    ~intArr(){
        for(int i=0;i<Size;i++)
            arr[i]=0;
        delete []arr;
    }

///[]overloading function
    T &operator[](int index){

        if((index>=0)&&(index<Size))
            return arr[index];
    }


    void setarr(int index,T value){
        if((index>=0)&&(index<Size))
            arr[index]=value;

    }
    int getarr(int index){
         if((index>=0)&&(index<Size))
            return arr[index];
        else
            return -1;
    }

    ///get size
    int getsize(){
        return Size;
    }


} ;



int main()
{
    int i,j,n,k,num;
    char m;
    cout<<"Enter size of array1: ";
    cin>>n;
    cout<<"Enter size of array2: ";
    cin>>k;
    intArr <int>arr(n);
    intArr <char>arr1(k);
    for(i=0;i<arr.getsize();i++){
        cout<<"Enter num of array1 index["<<i<<"]: ";
        cin>>num;
        arr[i]=num;

    }

    for(j=0;j<arr1.getsize();j++){
        cout<<"Enter char of array2 index["<<j<<"]: ";
        cin>>m;
        arr1[j]=m;

    }


    for(i=0;i<arr.getsize();i++){
        cout<<"arr1 integer index["<<i<<"]: ";
        cout<<arr[i]<<endl;
    }

     for(i=0;i<arr1.getsize();i++){
        cout<<"arr2 char index["<<i<<"]: ";
        cout<<arr1[i]<<endl;
    }

    return 0;
}

