#include <stdio.h>
#include <stdlib.h>

int index_min_value(int arr[],int start_index,int end_index){
    int index=start_index;///temp
    for(int i=start_index+1;i<end_index;i++){
        if(arr[i]<arr[index])
            index=i;
    }
return index;

}

swap(int *a,int *b){
    int temp;
    temp=*a;
    *a=*b;
    *b=temp;

}


void selection_sort(int arr[],int size){
    int index;
    for(int i=0;i<size;i++){
        index=index_min_value(arr,i,size);
        swap(&arr[i],&arr[index]);
    }

    for(int i=0;i<size;i++){
        printf("%d",arr[i]);
    }


}



int main()
{
    int x[5]={1,3,6,8,2};
    selection_sort(x,5);

    return 0;
}
