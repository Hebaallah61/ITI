#include <stdio.h>
#include <stdlib.h>
#define NormalPen 0x07
#define HighlightPen 0xB0
#define Enter 0x0D
#define ESC 27
#include <windows.h>

void textattr(int i){
    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE),i);
}

void gotoxy (int x,int y){
    COORD coord;
    coord.X=x;
    coord.Y=y;
    SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE),coord);


}

struct Employee{
    int id,age;
    char gender,name[100],address[200];
    double salary,overtime,tax;
};

void Newfun(struct Employee e[],int len){

    int i;
    for(i=0;i<len;i++){
    system("cls");
    textattr(HighlightPen);
    gotoxy(5,5);
    printf("ID: ");

    gotoxy(5,7);
    printf("Name: ");

    gotoxy(5,9);
    printf("Salary: ");

    gotoxy(5,11);
    printf("Over_Time: ");

    gotoxy(40,5);
    printf("Address: ");


    gotoxy(40,7);
    printf("Age: ");

    gotoxy(40,9);
    printf("Gender: ");

    gotoxy(40,11);
    printf("Tax: ");
    //////////////////////////////////////////////////////////////
    _flushall();
    gotoxy(20,5);
    scanf("%d",&e[i].id);

    _flushall();
    gotoxy(20,7);
    gets(e[i].name);

    _flushall();
    gotoxy(20,9);
    scanf("%lf",&e[i].salary);

    _flushall();
    gotoxy(20,11);
    scanf("%lf",&e[i].overtime);

    _flushall();
    gotoxy(55,5);
    gets(e[i].address);

    _flushall();
    gotoxy(55,7);
    scanf("%d",&e[i].age);

    _flushall();
    gotoxy(55,9);
    _getche(e[i].gender);

    _flushall();
    gotoxy(55,11);
    scanf("%lf",&e[i].tax);



    }

}

void Display(struct Employee e[],int len){

    int i;
    double Net_salary;
    for(i=0;i<3;i++){
        Net_salary=e[i].salary+e[i].overtime-e[i].tax;
        printf("ID:%d\nName:%s\nNet_Salary:%lf\n",e[i].id,e[i].name,Net_salary);
    }

}

int main()
{

    char Menu[3][10]={"New","Display","Exit"};
    int Currant_state=0;
    int Exit_flag=0;
    int i;
    char ch,Name;

    struct Employee e[3];


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


                Newfun(e,3);


                break;
            case 1://Display
                system("cls");
                printf("Employees:\n");
                Display(e,3);
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
