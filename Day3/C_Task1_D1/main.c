#include <stdio.h>
#include <stdlib.h>

int main()
{
    printf("Hello World");
    int num;
    printf("\nPlease Enter Number: ");
    scanf("%d",&num);
    char ch=num;
    printf("\nThe Hexa_Number is:%X",num);
    printf("\nThe character of the %d is: %c",num,ch);

    return 0;
}
