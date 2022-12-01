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
{
    int i,r,c;
    r=1;
    c=(3+1)/2;
    for(i=1;i<=9;i++){
        gotoxy(c*3,r*3);
        printf("%i",i);
        if(i%3==0)
            r++;
        else{

            c--;
            r--;
            if(r==0)
                r=3;
            if(c==0)
                c=3;
        }
    }


    return 0;
}
