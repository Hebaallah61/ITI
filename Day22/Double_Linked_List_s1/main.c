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


struct Node{
struct Employee Data;
struct Node *pnext;
struct Node *pprev;
};

struct Node *pstart;
struct Node *plast;




struct Node *newnode(){
    struct Node *pnew=(struct Node*)malloc(sizeof (struct Node));
    if(pnew==NULL) exit(0);
    ///
    _flushall();
    gotoxy(20,5);
    scanf("%d",&pnew->Data.id);

    _flushall();
    gotoxy(20,7);
    gets(pnew->Data.name);

    _flushall();
    gotoxy(20,9);
    scanf("%lf",&pnew->Data.salary);

    _flushall();
    gotoxy(20,11);
    scanf("%lf",&pnew->Data.overtime);

    _flushall();
    gotoxy(55,5);
    gets(pnew->Data.address);

    _flushall();
    gotoxy(55,7);
    scanf("%d",&pnew->Data.age);

    _flushall();
    gotoxy(55,9);
    _getche(pnew->Data.gender);

    _flushall();
    gotoxy(55,11);
    scanf("%lf",&pnew->Data.tax);
    ///

    //pnew->Data=e;
    pnew->pnext=pnew->pprev=NULL;
    return pnew;
    //////////////////////////////////////////////////////////////
    ///return (struct Node*)malloc(sizeof(struct Node));
    //////////////////
}
void  addnode(){
    struct Node *pnew=newnode();
    if(plast==NULL){
        plast=pstart=pnew;
    }
    else{
        plast->pnext=pnew;
        pnew->pprev=plast;
        plast=pnew;
    }
}
void Display_all(){
    struct Node *pdisplay=pstart;
    double Net_salary;
    while(pdisplay!=NULL){
        Net_salary=(pdisplay->Data.salary+pdisplay->Data.overtime)-pdisplay->Data.tax;
        printf("\nID:%d\nName:%s\nNet_Salary:%.lf",pdisplay->Data.id,pdisplay->Data.name,Net_salary);
        pdisplay=pdisplay->pnext;
    }

}
struct Node *search_in_list(int id){
struct Node* psearch=pstart;


while(pstart){
    if(psearch->Data.id==id)
        break;
    else
        psearch=psearch->pnext;
}
return psearch;
}
void Display(int id){
    struct Node*pdisplay=search_in_list(id);
    if(pdisplay==NULL)
        printf("ID:%d NOT FOUND",id);
    else{
       system("cls");
       double Net_salary;
       Net_salary=(pdisplay->Data.salary+pdisplay->Data.overtime)-pdisplay->Data.tax;
       printf("\nID:%d\nName:%s\nNet_Salary:%.lf",pdisplay->Data.id,pdisplay->Data.name,Net_salary);
    }
}
void Delete_By_Id(int ID){
    struct Node* pdelete=search_in_list(ID);
     if(pdelete==NULL)
        printf("The ID:%d NOT FOUND",ID);
     else{
        if(pstart==plast){
            pstart=plast=NULL;
        }
        else if(pstart==pdelete){
            pstart=pstart->pnext;
            pstart->pprev=NULL;
        }
        else if(plast==pdelete){
            plast=plast->pprev;
            plast->pnext=NULL;
        }
        else{
            pdelete->pprev->pnext=pdelete->pnext;
            pdelete->pnext->pprev=pdelete->pprev;
        }
        free(pdelete);
        system("cls");
        printf("The Element deleted\n");
     }


}

void Delete_all(){
     struct Node *pdelete;
     while(pstart!=NULL){
        pdelete=pstart;
        pstart=pstart->pnext;
        free(pdelete);
     }
     plast=NULL;
     system("cls");
     printf("The All Elements are deleted\n");
}


int main()
{

    char Menu[6][18]={"New","Display_By_ID","Display_All","Delete_By_ID","Delete_All","Exit"};
    int Currant_state=0;
    int Exit_flag=0;
    int i,index,ID;
    char ch,Name[100],k[50],kl[50];

    struct Employee e;


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
                _flushall();

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

                addnode();
                getch();

                break;
            case 1://Display_By_ID
                    system("cls");
                    printf("Enter ID of Employee: ");
                    _flushall();
                    scanf("%d",&ID);
                    Display(ID);
                    getch();

                    break;
            case 2://Display_All
                    system("cls");
                    printf("All Exists Employees:\n");
                    Display_all();
                    getch();

                break;
            case 3://Delete_By_ID
                    system("cls");
                    printf("Enter ID of Employee: ");
                    _flushall();
                    scanf("%d",&ID);
                    Delete_By_Id(ID);
                    getch();

                  break;
            case 4://Delete_All
                  Delete_all();
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
