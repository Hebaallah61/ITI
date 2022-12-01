#include <stdio.h>
#include <stdlib.h>
#define size 20
int main()
{
    int arr[size];
    int s,i;
    int *ptr;
    ptr=&arr[0];

    printf("Enter size of array: ");
    scanf("%d",&s);

    for(i=0;i<s;i++){

        printf("Enter number of index[%d]: ",i);
        scanf("%d",ptr);
        ptr++;
    }

    ptr=&arr[0];

    for(i=0;i<s;i++){

        printf("Value of index[%d]=%d\n",i,*ptr);
        ptr++;

    }

    return 0;
}
