#include <stdio.h>
#include <stdlib.h>
#define Max_Size 100

int main()
{
    int arr[Max_Size];
    int min,max;
    int size;
    int i=0;

    printf("Enter Array Size: ");
    scanf("%d",&size);

    for(i;i<size;i++){
        printf("Please enter element %d: ",i+1);
        scanf("%d",&arr[i]);
    }
    min=arr[0];
    max=arr[0];

   for(i=0;i<size;i++){
    if(arr[i]>max)
        max=arr[i];
    else
        min=arr[i];
   }

   printf("the max element is:%d \nthe min element is:%d",max,min);



    return 0;
}
