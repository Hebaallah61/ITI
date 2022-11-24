#include <stdio.h>
#include <stdlib.h>

int binary_search(int *arr,int key,int size){
    int high=size-1,low=0,mid;
    while(high>=low){
        mid=(low+high)/2;
        if(arr[mid]==key)
            return mid;
        else if(arr[mid]>key)
            high=mid-1;
        else
            low=mid+1;
    }
    return -1;
}


int main()
{
    int n,value,index=0;
    printf("Enter size of arr:");
    scanf("%d",&n);
    int *arr=(int *)malloc(n*sizeof(int));
    for(int i=0;i<n;i++){
        printf("Enter arr[%d]:",i);
        scanf("%d",&arr[i]);
    }
    printf("Enter the Value to search:");
    scanf("%d",&value);
    index=binary_search(arr,value,n);
    printf("index:%d",index);

    return 0;
}
