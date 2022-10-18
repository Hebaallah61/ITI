#include <stdio.h>
#include <stdlib.h>

int main()
{

int M;
printf("please Enter your choice from the  menu\n1-soccer\n2-swimming\n3-running\n: ");
scanf("%d",&M);
switch(M){

    case 1:
        printf("ohhhh soccer is amazing");
    break;

    case 2:
        printf("I think swimming it is very good for your body");
    break;

    case 3:
        printf("I also love running it makes me feel free");
    break;
    default:
        printf("ohhh your choice is not in our menu");
    break;
}
    return 0;
}
