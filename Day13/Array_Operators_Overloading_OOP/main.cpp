#include <iostream>

using namespace std;

class intArr{
    int *arr,Size;
public:
    intArr(int s){
        Size=s;
        arr=new int[Size];
    }

    intArr(const intArr &oldarr){
        Size=oldarr.Size;
        arr=new int[Size];
        for(int i=0;i<Size;i++)
            arr[i]=oldarr.arr[i];
    }
    ~intArr(){
        for(int i=0;i<Size;i++)
            arr[i]=0;
        delete []arr;
    }
///equality function
    intArr& operator =(const intArr &r){///without & need arr0 in return
        delete []arr;
        Size=r.Size;
        arr=new int[Size];
        for(int i=0;i<Size;i++)
            arr[i]=r.arr[i];
        return *this;
    }
///[]overloading function
    int &operator[](int index){

        if((index>=0)&&(index<Size))
            return arr[index];
    }
    void setarr(int index,int value){
        if((index>=0)&&(index<Size))
            arr[index]=value;

    }
    int getarr(int index){
         if((index>=0)&&(index<Size))
            return arr[index];
        else
            return -1;
    }
    ///+overloading function
    intArr operator+(intArr &arr0){
        intArr r(Size);
        for(int i=0;i<r.getsize();i++)
            r.arr[i]=arr0.getarr(i)+arr[i];
        return r;
    }
    ///get size
    int getsize(){
        return Size;
    }


} ;



int main()
{
    int i,j,n,m,num;
    cout<<"Enter size of array1: ";
    cin>>n;
    cout<<"Enter size of array2: ";
    cin>>m;
    intArr arr(n);
    intArr arr1(m);
    for(i=0;i<arr.getsize();i++){
        cout<<"Enter num of array1 index["<<i<<"]: ";
        cin>>num;
        arr[i]=num;

    }

    for(j=0;j<arr1.getsize();j++){
        cout<<"Enter num of array2 index["<<j<<"]: ";
        cin>>num;
        arr1[j]=num;

    }


    for(i=0;i<arr1.getsize();i++){
        cout<<"sum of index["<<i<<"]: ";
        cout<<arr[i]+arr1[i]<<endl;
    }

    return 0;
}

