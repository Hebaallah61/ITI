#include <stdio.h>
#include <stdlib.h>
#define size 20
int main()
{
    int *arr[size];
    int s,i;



    printf("Enter size of array: ");
    scanf("%d",&s);

    for(i=0;i<s;i++){

        printf("Enter number of index[%d]: ",i);
        scanf("%d",arr+i);

    }



    for(i=0;i<s;i++){

        printf("Value of index[%d]=%d\n",i, arr[i]);
        arr+1;

    }

    return 0;
}
