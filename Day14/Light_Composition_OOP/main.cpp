#include <iostream>
#include "E:\heba\CodeBlocks\MinGW\include\graphics.h"
#include <dos.h>
#include <conio.h>
using namespace std;



class point{
    int x,y;
public:
    point(){
     x=y=0;
    }
    point(int _x,int _y){

        x=_x;
        y=_y;
    }
    ~point(){
        //cout<<"point destructor\n";
    }

    int getx(){return x;}
    int gety(){return y;}

    void setx(int _x){x=_x;}
    void sety(int _y){y=_y;}

    void show(){
        cout<<"("<<x<<","<<y<<")\n";
    }

};


class Rect{

    point ul;
    point lr;
    int color;
public:
    rec(){
        int color=0;
    }

    Rect(int x1,int y1,int x2,int y2,int c)
        :ul(x1,y1),lr(x2,y2)
    {
        color=c;
    }

    ~Rect(){//cout<<"rec destructor\n";
    }
    void Draw(){
        rectangle(ul.getx(),ul.gety(),lr.getx(),lr.gety());
    }


};


class Line{
    point start;
    point ends;
    int color;
public:
    Line(){
        int color=0;
    }

    Line(int x1,int y1,int x2,int y2,int c)
        :start(x1,y1),ends(x2,y2)
    {
        color=c;
    }

    ~Line(){//cout<<"Line destructor\n";
    }

     void draw(){
        line(start.getx(),start.gety(),ends.getx(),ends.gety());
    }
};


class Triangle{

    point a;
    point b;
    point c;
    int color;
public:

    Triangle(){
        int color=0;
    }

    Triangle(int x1,int y1,int x2,int y2,int x3,int y3,int c)
        :a(x1,y1),b(x2,y2),c(x3,y3)
    {
        color=c;
    }

    ~Triangle(){//cout<<"Triangle destructor\n";
    }

     void draw(){
        line(a.getx(),a.gety(),b.getx(),b.gety());
        line(b.getx(),b.gety(),c.getx(),c.gety());
        line(c.getx(),c.gety(),a.getx(),a.gety());
    }




};


class Circle{
point a;
int radius;
int color;

public:

    Circle(){
        int color=0;
    }

    Circle(int x1,int y1,int r,int c)
        :a(x1,y1)
    {
        color=c;
        radius=r;

    }

    ~Circle(){//cout<<"Line destructor\n";
    }

     void draw(){
        circle(a.getx(),a.gety(),radius);
    }





};



int main()
{

    initgraph();




    Rect R(742,294,1050,351,100);
    R.Draw();
    setcolor (11);
    setfontcolor(9);
    Line L1(742,293,847,172,100);
    L1.draw();

    Line L2(1051,293,948,171,100);
    L2.draw();

    Line L3(850,172,949,172,100);
    L3.draw();

    Line L4(843,257,881,256,100);
    L4.draw();

    Line L5(843,257,842,68,100);
    L5.draw();

    Line L6(881,256,881,67,100);
    L6.draw();

    Line L7(864,242,864,70,100);
    L7.draw();

    Line L8(940,266,938,76,100);
    L8.draw();

    Line L9(971,264,972,75,100);
    L9.draw();

    Triangle t1(828,65,863,7,898,66,100);
    t1.draw();

    Triangle t2(844,256,862,242,883,257,100);
    t2.draw();

    Circle c1(956,80,53,100);
    c1.draw();

    Circle c2(956,283,50,100);
    c2.draw();

    Circle c3(860,280,50,100);
    c3.draw();


    return 0;
}
