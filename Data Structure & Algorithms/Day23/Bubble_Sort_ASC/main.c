#include <stdio.h>
#include <stdlib.h>


swap(int *a,int *b){
    int temp;
    temp=*a;
    *a=*b;
    *b=temp;

}

void Bubble_Sort(int arr[],int size){
    int swapped;
    for(int i=0;i<size-1;i++){
        swapped=0;
        for(int j=0;j<size-i-1;j++){
            if(arr[i]>arr[j+1]){
                swap(&arr[j],&arr[j+1]);
                swapped=1;
            }

        }
        if(swapped==0) break;
    }


}

void print(int arr[],int size){

for(int i=0;i<size;i++){
        printf("%d ",arr[i]);
    }

}

int main()
{
    int x[5]={1,2,3,4,5};
    int y[5]={1,2,6,3,7};
    int z[5]={4,9,5,7,3};

    Bubble_Sort(x,5);
    print(x,5);
    printf("\n");
    Bubble_Sort(y,5);
    print(x,5);
    printf("\n");
    Bubble_Sort(z,5);
    print(x,5);
    printf("\n");
    return 0;
}
