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

struct Employee{
    int id,age;
    char gender,name[100],address[200];
    double salary,overtime,tax;
};



int main()
{

    int i;
    double Net_Salary;
    struct Employee e;
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
/////////////////////////////////////////////////////////////
    gotoxy(20,5);
    scanf("%d",&e.id);

    _flushall();
    gotoxy(20,7);
    gets(e.name);

    _flushall();
    gotoxy(20,9);
    scanf("%lf",&e.salary);

    _flushall();
    gotoxy(20,11);
    scanf("%lf",&e.overtime);

    _flushall();
    gotoxy(55,5);
    gets(e.address);

    _flushall();
    gotoxy(55,7);
    scanf("%d",&e.age);

    _flushall();
    gotoxy(55,9);
    _getche(e.gender);

    _flushall();
    gotoxy(55,11);
    scanf("%lf",&e.tax);



    //Salary:%.f\nOver_Time:%.f\nAddress:%s\nAge:%d\nGender:%c\nTax:%.f

    Net_Salary=(e.salary+e.overtime)-e.tax;
    system("cls");
    printf("ID:%d\nName:%s\nNet_Salary:%lf\n",e.id,e.name,Net_Salary);


    return 0;
}
