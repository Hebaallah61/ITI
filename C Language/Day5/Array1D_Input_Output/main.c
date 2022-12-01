#include <stdio.h>
#include <stdlib.h>
#define Max_Size 100
int main()
{
    int size=5;
    int arr[Max_Size];
    int i=0;

    printf("Enter Array Size: ");
    scanf("%d",&size);

    for(i;i<size;i++){
        printf("Please enter element %d: ",i+1);
        scanf("%d",&arr[i]);
    }

   for(i=0;i<size;i++){
       printf("\n Array of index [%d] is:%d ",i,arr[i]);
   }
    return 0;
}
