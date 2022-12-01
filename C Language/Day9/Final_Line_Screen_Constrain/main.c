#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <string.h>
#include<windows.h>
#define NormalPen 0x0F
#define HighlightPen 0xB0
#define Enter 0x0D
#define ESC 27
#define Size 3


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


///prototypes of functions
void Newfun(Employee*);
char** line_editor(int NL, int *MLL, int *xpos, int *ypos, int *schar, int *echar);
void Display(Employee*);
void Display_all(Employee*);
void delete_by_id(Employee*);
void delete_by_name(Employee*);
void drawbox(int xpos,int ypos);
int main()
{
    char menu[6][18] = {"New","Display_By_ID","Display_All","Delete_By_ID","Delete_By_Name","Exit"};
    int i, current = 0, ExitFlag = 0;
    char ch;
    Employee *e = (Employee*)calloc(10,sizeof(Employee));

    do
    {
        textattr(NormalPen);
        system("cls");

        for(i = 0 ; i<6; i++)
        {
            if(current == i)
                textattr(HighlightPen);
            else textattr(NormalPen);

            gotoxy(50,10+(3*i));
            printf("%s",menu[i]);
        }

        ch = _getch();

        switch (ch)
        {
        case Enter:
            switch (current)
            {
            case 0:
                Newfun(e);
                break;
            case 1:
                Display(e);
                break;
            case 2:
                Display_all(e);
                break;
            case 3:
                delete_by_id(e);
                break;
            case 4:
                delete_by_name(e);
                break;
            case 5:
                ExitFlag = 1;
                break;
            }
            break;
        case ESC:
            ExitFlag = 1;
            break;
        case -32:
            ch = _getch();
            switch (ch)
            {
            case 72:///up
                current--;
                if(current<0) current = 5;
                break;
            case 80:///down
                current++;
                if(current>5) current =0;
                break;
            case 71:///home
                current = 0;
                break;
            case 79:
                current = 5;
                break;
            }
        }
    }
    while(!ExitFlag==1);

    free(e);
    return 0;
}

///------------------------------------------------------------------------
void Newfun(Employee* e)
{
    int index,i;
    char ch = '\0';

    system("cls");
    printf("Please Enter Index you want to add in: ");
    scanf("%d",&index);
    if(e[index].id != 0)
    {
        printf("There is an employee at index %d!\n",index);
        printf("Press any key to return...");
        _getch();
    }
    else
    {
        system("cls");
        int NL = 8;
        int xpos[8] = {20,20,20,20,55,55,55,55};
        int ypos[8] = {5,7,9,11,5,7,9,11};
        int schar[8] = {48,97,48,48,97,48,97,48};
        int echar[8] = {57,122,57,57,122,57,122,57};
        int MLL[8] = {5,15,7,7,15,3,1,7};



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

        gotoxy(15,5);
        char **data = line_editor(NL,MLL,xpos,ypos,schar,echar);
        system("cls");

        _getch();
        ///put the data of employee at its position
        e[index].id = atoi(data[0]);
        strcpy(e[index].address,data[1]);
        e[index].age = atoi(data[2]);
        e[index].gender = data[3][0];
        strcpy(e[index].name,data[4]);
        e[index].salary = atoi(data[5]);
        e[index].overtime = atoi(data[6]);
        e[index].tax = atoi(data[7]);

        for(i = 0 ; i < NL ; i++)
            free(data[i]); ///free from heap
        free(data);

    }
}

void Display_all(Employee *e)
{
    system("cls");
    int i;
    double Net_salary=0;///--------------------------------------
    for(i = 0 ; i <10; i++)
    {
        if(e[i].id != 0)
        {
            Net_salary=(e[i].salary+e[i].overtime)-e[i].tax;
                printf("\nID:%d\nName:%s\nNet_Salary:%.lf",e[i].id,e[i].name,Net_salary);
        }
    }

    _getch();
}

char** line_editor(int NL, int *MLL, int *xpos, int *ypos, int *schar, int *echar)
{
    char **ARR = (char**) calloc(NL,sizeof(char*));
    char current[NL], end[NL];
    char ch;
    int exit = -1;///the flag that dedicate if i will go on while or exit
    int i,j;
    int current_line = 0;

    for(i = 0; i < NL; i++) ///allocate the arr cells
    {
        ARR[i] = (char*) malloc(sizeof(char)*MLL[i]);
    }

    for(i = 0; i < NL; i++) ///make all cells =0 as initialization
    {
        current[i] = end[i] = 0;
    }


    while(exit == -1)
    {
        gotoxy(xpos[current_line]+current[current_line], ypos[current_line]); ///to start from the start of the cell
        ch = getch();
        switch (ch)
        {
        case Enter:///if you press enter key
            for(i = 0; i < NL ; i++)
                ARR[i][end[i]]='\0'; ///put the 0 at the end of the input
            exit = 1;///change the flag to exit from while loop
            break;
        case 9:///tab as a move arround the cells
            if(current_line < NL-1)
            {
                current_line++;
            }
            else current_line = 0;
            break;
        case -32:///if it is candidate key
            ch = _getch(); ///read again to know which one is it
            switch (ch)
            {
            case 72:///up
                if(current_line > 0)
                {
                    current_line--;
                }
                else current_line = 7;
                break;
            case 80:///down
                if(current_line < NL-1)
                {
                    current_line++;
                }
                else current_line = 0;
                break;
            case 75:///left
                if(current[current_line] > 0)
                {
                    current[current_line]--;
                }
                break;
            case 77:///right
                if(current[current_line] < end[current_line])
                {
                    current[current_line]++;
                }
                break;
            case 71:///home
                current[current_line] = 0;
                break;
            case 79:///end
                current[current_line] = end[current_line];
                break;
            }
            break;
        default:
            if(ch >= schar[current_line] && ch <= echar[current_line] && current[current_line] <= end[current_line])
                ///after the any case you choose you should check if you will print the char or not
            {

                ARR[current_line][current[current_line]] = ch;
                printf("%c",ch);
                current[current_line]++;
                if(end[current_line] < MLL[current_line]-1 && current[current_line] == end[current_line]+1)
                {
                    end[current_line]++;
                }
            }
        }
    }
    textattr(NormalPen);
    return ARR;
}

void Display(Employee *e)
{
    int id ,i ,flage = -1;
    char ch = '\0';
    double Net_salary=0;
    system("cls");
    printf("Enter Employee ID: ");
    scanf("%d",&id);
    system("cls");///-------------------------------
    for(i = 0 ; i <10; i++)
    {
        if(e[i].id == id)
        {
            Net_salary=e[i].salary+e[i].overtime-e[i].tax;
            printf("\nID:%d\nName:%s\nNet_Salary:%lf\n",e[i].id,e[i].name,Net_salary);
            flage = 1;
            break;
        }
    }
    if(flage == -1)
    {
        system("cls");
        printf("There is no Employee with ID %d",id);

    }

    _getch();
}

void delete_by_id(Employee *e)
{
    int id ,i ,flage = -1;
    char ch = '\0';

    system("cls");
    printf("Enter Employee id: ");
    scanf("%d",&id);

    for(i = 0 ; i <10; i++)
    {
        if(e[i].id == id)
        {
            printf("Employee deleted successfully!\n");
            e[i].id = 0;
            e[i].name[0] = '\0';
            e[i].gender = '\0';
            e[i].salary = 0;
            e[i].overtime = 0;
            e[i].tax = 0;
            e[i].address[0] = '\0';
            e[i].age = 0;
            flage = 1;
            break;
        }
    }
    if(flage == -1)
    {
        system("cls");
        printf("Employee with id not exist %d",id);

    }

    _getch();
}

void delete_by_name(Employee *e)
{
    int i ,flage = -1;
    char ch = '\0';
    char name[10];

    system("cls");
    printf("Please Enter Employee Name: ");
    scanf("%s",name);
    for(i = 0 ; i <10; i++)
    {
        if(!strcmp(e[i].name,name))
        {
            printf("Employee with Name %s delete successfully!\n",name);
            e[i].id = 0;
            e[i].name[0] = '\0';
            e[i].gender = '\0';
            e[i].salary = 0;
            e[i].overtime = 0;
            e[i].tax = 0;
            e[i].address[0] = '\0';
            e[i].age = 0;
            flage = 1;
            break;
        }
    }
    if(flage == -1)
    {
        system("cls");
        printf("There is no Employee with input name\n");

    }

    _getch();

}




void drawbox(int xpos ,int ypos ){
int i;
for(i=0;i<10;i++){
        textattr(HighlightPen);///for drawing the cells of writing
        gotoxy(xpos+i,ypos);
        printf(" ");
    }

}

