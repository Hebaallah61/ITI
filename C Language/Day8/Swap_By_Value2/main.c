#include <stdio.h>
#include <stdlib.h>

//int A=5;
//int B=6;
void swap(int x,int y){

int temp;
temp=x;
x=y;
y=temp;


}

int main()
{

    int A,B;
    printf("Enter two numbers: ");
    scanf("%d%d",&A,&B);
    swap(A,B);
    printf("A=%d\tB=%d",A,B);

    return 0;
}
