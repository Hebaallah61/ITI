#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
void gotoxy(int column,int line){
    COORD coord;
    coord.X=column;
    coord.Y=line;
    SetConsoleCursorPosition(
                             GetStdHandle(STD_OUTPUT_HANDLE),coord);

}

int main()
{   int size;
    int num;
    int r,c,i;
    char x;
    do{
    printf("Enter odd number: ");
    scanf("%d",&num);
    if(num%2==0 || num==1){
        printf("The number is not odd or =1\n");
        printf("press EOF(0) to exit: ");
        scanf(" %d",&x);
    }
    else{
       size=num*num;
        r=1;
        c=(num+1)/2;
        for(i=1;i<=size;i++){
            gotoxy(c*3,r*3);
            printf("%i\n",i);
            if(i%num==0)
                r++;
            else{
                r--;
                c--;
                if(r==0)
                    r=num;
                if(c==0)
                    c=num;
           }
       }

    }
    }while(x!='\0');
    return 0;
}
