#include <stdio.h>
#include <stdlib.h>
#define NormalPen 0x07
#define HighlightPen 0xB0
#define Enter 0x0D
#define ESC 27
#include <windows.h>
#include<string.h>

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


void Delete_over(struct Employee e[],int len){

     e[len].id=000;
     gotoxy(5,17);
     printf("The Previous Element deleted\n");

}
void Newfun(struct Employee e[],int index){


    system("cls");

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
    //////////////////
    int ID,con,i;
    /////////////////
    scanf("%d",&ID);
    ///////////////////////////////
    for(i=0;i<10;i++){
        if(e[i].id==ID){

            gotoxy(5,15);
            printf("the ID is already exist press 0 to overwrite or 1 to cancel: ");
            gotoxy(70,15);
            _flushall();
            scanf("%d",&con);
            if(con==0){
                e[i].id=ID;
                Delete_over(e,i);
                gotoxy(20,7);
            }
            else
            {
                    return 0;
            }

    }
    else{
        e[index].id=ID;
        break;
    }
    }

    //////////////////////////////
    _flushall();
    gotoxy(20,7);
    gets(e[index].name);

    _flushall();
    gotoxy(20,9);
    scanf("%lf",&e[index].salary);

    _flushall();
    gotoxy(20,11);
    scanf("%lf",&e[index].overtime);

    _flushall();
    gotoxy(55,5);
    gets(e[index].address);

    _flushall();
    gotoxy(55,7);
    scanf("%d",&e[index].age);

    _flushall();
    gotoxy(55,9);
    _getche(e[index].gender);

    _flushall();
    gotoxy(55,11);
    scanf("%lf",&e[index].tax);



    }



void Display_all(struct Employee e[],int len){

    int i;
    double Net_salary;
    for(i=0;i<len;i++){
            if(e[i].id!=NULL){
                Net_salary=(e[i].salary+e[i].overtime)-e[i].tax;
                printf("\nID:%d\nName:%s\nNet_Salary:%.lf",e[i].id,e[i].name,Net_salary);
            }

    }

}

void Display(int index,struct Employee e[]){

    system("cls");
    double Net_salary;
    Net_salary=e[index].salary+e[index].overtime-e[index].tax;
    printf("\nID:%d\nName:%s\nNet_Salary:%lf\n",e[index].id,e[index].name,Net_salary);

}



void Delete_By_Id(struct Employee e[],int len){
     system("cls");
     e[len].id=0;
     printf("The Element deleted\n");

}

void Delete_By_Name(struct Employee e[],int len){
     system("cls");
     strcpy(e[len].name,"no");///////////////////////////////////
     e[len].id=0;
     printf("The Element deleted\n");
}


int main()
{

    char Menu[6][18]={"New","Display_By_ID","Display_All","Delete_By_ID","Delete_By_Name","Exit"};
    int Currant_state=0;
    int Exit_flag=0;
    int i,index,ID;
    char ch,Name[100],k[50],kl[50];

    struct Employee e[10]={0};


    do{
    //to restart with normal pen color
        textattr(NormalPen);
    // cls: clear screen
        system("cls");
    //print menu contains 3 options (new,save,exit)
        for(i=0;i<6;i++){
            if(Currant_state==i)
                textattr(HighlightPen);
            else
                textattr(NormalPen);
            gotoxy(55,9+(3*i));
            printf("%s",Menu[i]);
        }
    //get from user the choice
        ch= _getch();

        switch(ch){
        case Enter:
            switch(Currant_state){
            case 0://new
                system("cls");//to clear the screen and start to take inputs from user
                printf("Enter Index of Employee: ");
                _flushall();
                scanf("%d",&index);
                Newfun(e,index);
                //////////////////////////////////////


                /////////////////////////////////////
                getch();

                break;
            case 1://Display_By_ID
                    system("cls");
                    printf("Enter ID of Employee: ");
                    _flushall();
                    scanf("%d",&ID);
                    int Flag=0;
                    for(i=0;i<10;i++){
                        if(e[i].id==ID){
                            Flag=1;
                            Display(i,e);
                            break;
                        }

                    }
                    //printf("flage %i:",Flag);
                    if (!Flag)
                        printf("The ID is not exist\n");
                    //break;////////////////////
                            //break;


                    getch();
                    break;
            case 2://Display_All
                    system("cls");
                    printf("All Exists Employees:\n");
                    Display_all(e,10);
                    getch();

                break;
            case 3://Delete_By_ID

                  //////////////////////////
                  system("cls");
                    printf("Enter ID of Employee: ");
                    _flushall();
                    scanf("%d",&ID);
                    //int Flag=0;
                    for(i=0;i<10;i++){
                        if(e[i].id==ID){
                            Flag=1;
                            Delete_By_Id(e,i);
                            break;
                        }



                    }
                    if(!Flag)
                        printf("The ID is not exist\n");


                            //break;
                    getch();

                  break;
            case 4://Delete_By_Name
                  system("cls");
                  printf("Enter Name of Employee: ");
                  _flushall();
                  gets(Name);
                  //int Flag=0;
                  for(i=0;i<10;i++){

                    if(strcmp(e[i].name,Name)==0){
                        Flag=1;
                        Delete_By_Name(e,i);
                        break;
                    }

                  }
                  if(!Flag)
                    printf("The Name is not exist\n");

                   getch();
                break;
            case 5://exit
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
                if (Currant_state<0) Currant_state=5;
                break;
            case 80://down arrow
                Currant_state++;
                if(Currant_state>5) Currant_state=0;
                break;
            case 71://home key
                Currant_state=0;
                break;
            case 79://end key
                Currant_state=5;
                break;


            }
            break;

        }
    }while(!Exit_flag);
    getch();

    return 0;

    }
