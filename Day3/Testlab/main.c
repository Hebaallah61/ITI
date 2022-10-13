#include <stdio.h>
#include <stdlib.h>

int main()
{
    int v;
    int h;
    printf("enter the first number");
    scanf("%d",&v);
    printf("enter the second number");
    scanf("%d",&h);

    int z=v&h;
    int n=v|h;
    int x=v^h;
    int l=v<<1;
    int r=h>>1;
    printf("\nand is: %d\nor is: %d\nxor is: %d\nshift left is: %d\nshift right is: %d",z,n,x,l,r);
    return 0;
}
