#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
#include <conio.h>
#include <string.h>
#define NormalPen 0x07
#define HighlightPen 0xB0
#define Enter 0x0D
#define ESC 27
void gotoxy (int x,int y){
    COORD coord;
    coord.X=x;
    coord.Y=y;
    SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE),coord);


}

void textattr(int i){
    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE),i);
}
int main()
{
    char Menu[3][5]={"New","Save","Exit"};
    int Currant_state=0;
    int Exit_flag=0;
    int i;
    char ch,Name;
    FILE *fp;
    do{
    //to restart with normal pen color
        textattr(NormalPen);
    // cls: clear screen
        system("cls");
    //print menu contains 3 options (new,save,exit)
        for(i=0;i<3;i++){
            if(Currant_state==i)
                textattr(HighlightPen);
            else
                textattr(NormalPen);
            gotoxy(55,10+(3*i));
            printf("%s",Menu[i]);
        }
    //get from user the choice
        ch= _getch();

        switch(ch){
        case Enter:
            switch(Currant_state){
            case 0://new
                system("cls");//to clear the screen and start to take inputs from user
                printf("Enter your Name\t");
                //gets(Name);
                getch();
                break;
            case 1://save
                system("cls");
                printf("your Name saved\t");
                //gets(Name);
                getch();
                break;
            case 2://exit
                Exit_flag=1;
                break;

            }
            break;
        case ESC:
            Exit_flag=1;
            break;
        case -32://this is mean the button is extended key so you should read again
            ch=_getch();
            switch(ch){
            case 72://up arrow
                Currant_state--;
                if (Currant_state<0) Currant_state=2;
                break;
            case 80://down arrow
                Currant_state++;
                if(Currant_state>2) Currant_state=0;
                break;
            case 71://home key
                Currant_state=0;
                break;
            case 79://end key
                Currant_state=2;
                break;


            }
            break;

        }
    }while(!Exit_flag);
    getch();
    return 0;
}
