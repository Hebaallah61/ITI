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

 typedef struct Employee{
    int id,age;
    char gender,name[100],address[200];
    double salary,overtime,tax;
}Employee;
Employee e[10]={0};



char* line_editior(int xpos, int ypos, int frage, int srang)
{
    int x = xpos, y = ypos, tempendx = xpos; ///xpos=column,ypos=row
    char *arr = (char*) calloc(10,sizeof(char));///dynaimc allocation for arr of 10 cells with char size
    char *current,*start, *end; ///pointers that appear my position on the string or number
    current = start = end = arr;///first we make  current, start and end point to the first cell of array
    char ch;///character that i will read soon
    int exitflage = -1;///the flag that dedicate if i will go on while or exit
    while(exitflage == -1)
    {
        ch = getch();///read from keyboard a char

        switch (ch)
        {
        case Enter:///if you press enter key
            exitflage = 1;///change the flag to exit from while loop
            *end='\0';///put the 0 at the end of the input
            break;
        case -32:///if it is candidate key
            ch = _getch();///read again to know which one is it
            switch (ch)
            {
            case 71://home
                current = arr;///if it is the home key
                gotoxy(xpos,ypos);
                break;
            case 79://end
                current = end;///if it is the end key
                gotoxy(tempendx,y);
                break;
            case 75://left
                if(current > start)///if it is the left key
                {
                    current--;
                    gotoxy(--x,y);
                }
                break;
            case 77://right
                if(current < end)///if it is the right key
                {
                    current++;
                    gotoxy(++x,y);
                }
                break;
            }
            break;
        default:
            if(ch >= frage && ch <= srang)///after the any case you choose you should check if you will print the char or not
            {

                    *current = ch;
                    gotoxy(x++,y);
                    printf("%c",ch);
                    current++;
                    end++;
                    tempendx++;

            }
        }
    }
    return arr;
}



void Delete_over(struct Employee e[],int len){

     e[len].id=000;
     gotoxy(5,17);
     printf("The Previous Element deleted\n");

}


void Newfun(struct Employee e[],int index){
   ///build the form body
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

    ///draw the cells once opening the new
    drawbox(20,5);
    drawbox(20,7);
    drawbox(20,9);
    drawbox(20,11);
    drawbox(55,5);
    drawbox(55,7);
    drawbox(55,9);
    drawbox(55,11);

     ///read the data from user and make validations
    _flushall();
    int ID=0,con,i;
    ID=atoi(line_editior(20,5,48,57));
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

    _flushall();
    gotoxy(20,7);

    strcpy(e[index].name,line_editior(20,7,97,122));

    _flushall();
    gotoxy(20,9);

    e[index].salary = atoi(line_editior(20,9,48,57));

    _flushall();
    gotoxy(20,11);

    e[index].overtime = atoi(line_editior(20,11,48,57));

    _flushall();
    gotoxy(55,5);

    strcpy(e[index].address, line_editior(55,5,97,122));

    _flushall();
    gotoxy(55,7);

    e[index].age = atoi(line_editior(55,7,48,57));
    _flushall();

    gotoxy(55,9);

    e[index].gender = atoi(line_editior(55,9,97,122));

    _flushall();
    gotoxy(55,11);

    e[index].tax = atoi(line_editior(55,11,48,57));

    _getch();

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
     strcpy(e[len].name,"no");
     e[len].id=0;
     printf("The Element deleted\n");
}

void drawbox(int xpos ,int ypos ){
int i;
for(i=0;i<10;i++){
        textattr(HighlightPen);///for drawing the cells of writing
        gotoxy(xpos+i,ypos);
        printf(" ");
    }

}



int main()
{

    char Menu[6][18]={"New","Display_By_ID","Display_All","Delete_By_ID","Delete_By_Name","Exit"};
    int Currant_state=0;
    int Exit_flag=0;
    int i,index,ID;
    char ch,Name[100],k[50],kl[50];

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
        int Flag=0;
        switch(ch){
        case Enter:
            switch(Currant_state){
            case 0://new
                system("cls");//to clear the screen and start to take inputs from user
                printf("Enter Index of Employee: ");
                _flushall();
                scanf("%d",&index);
                Newfun(e,index);
                getch();

                break;
            case 1://Display_By_ID
                    system("cls");
                    printf("Enter ID of Employee: ");
                    _flushall();
                    scanf("%d",&ID);
                    for(i=0;i<10;i++){
                        if(e[i].id==ID){
                            Flag=1;
                            Display(i,e);
                            break;
                        }

                    }

                    if (!Flag)
                        printf("The ID is not exist\n");

                    getch();
                    break;
            case 2://Display_All
                    system("cls");
                    printf("All Exists Employees:\n");
                    Display_all(e,i);
                    getch();

                break;
            case 3://Delete_By_ID
                  system("cls");
                    printf("Enter ID of Employee: ");
                    _flushall();
                    scanf("%d",&ID);
                    for(i=0;i<10;i++){
                        if(e[i].id==ID){
                            Flag=1;
                            Delete_By_Id(e,i);
                            break;
                        }

                    }
                    if(!Flag)
                        printf("The ID is not exist\n");

                    getch();

                  break;
            case 4://Delete_By_Name
                  system("cls");
                  printf("Enter Name of Employee: ");
                  _flushall();
                  gets(Name);
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
