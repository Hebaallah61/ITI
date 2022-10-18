#include <stdio.h>
#include <stdlib.h>

int main()
{
    int sum=0;
    int num;

    do{
        printf("Enter your number: ");
        scanf("%d",&num);
        sum+=num;

    }while(sum<101);
    printf("the sum %d",sum);

    return 0;
}
