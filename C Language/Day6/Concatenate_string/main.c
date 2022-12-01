#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#define Max_Size 10
int main()
{
    char First[Max_Size], Second[Max_Size];


    printf("Enter your first part of your address: ");
    gets(First);

    printf("\nEnter your second part of your address:");
    gets(Second);

    strcat(First," ");
    strcat(First,Second);
    printf("\naddress is: %s",First);

    return 0;
}
