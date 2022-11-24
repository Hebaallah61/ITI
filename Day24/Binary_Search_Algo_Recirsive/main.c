#include <stdio.h>
#include <stdlib.h>

int binary_search(int *arr,int low,int high,int key){
        int mid=(low+high)/2;
        if(arr[mid]==key)
            return mid;
        else if(arr[mid]>key)
            return binary_search(arr,0,mid-1,key);
        else
            return binary_search(arr,mid+1,high,key);

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
    index=binary_search(arr,0,n,value);
    printf("index:%d",index);

    return 0;
}
