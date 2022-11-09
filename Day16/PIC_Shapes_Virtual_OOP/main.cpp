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
///class shape color
class Shape_color{
protected:
    int color;
public:
    Shape_color(int c){
        color=c;
    }
    void stcolor(int c){
    color=c;
    }

    int getcolor(){
    return color;
    }

};


///shape class
class shape:public Shape_color{

public:

    shape(int c):Shape_color(color){}

    virtual void draw()=0;///virtual method

};





class Rect:public  shape{///inheritance

    point ul;
    point lr;
    int num;
public:

    Rect(int x1,int y1,int x2,int y2,int c)///
        :ul(x1,y1),lr(x2,y2)
        ,shape(c)
    {
        //color=c;
    }

    ~Rect(){//cout<<"rec destructor\n";
    }
    void draw(){
        rectangle(ul.getx(),ul.gety(),lr.getx(),lr.gety());
    }


};


class Line :public shape{
    point start;
    point ends;
    int num;
public:

    Line(int x1,int y1,int x2,int y2,int c)
        :start(x1,y1),ends(x2,y2)
        ,shape(c)
    {
        //color=c;
    }

    ~Line(){//cout<<"Line destructor\n";
    }

     void draw(){
        line(start.getx(),start.gety(),ends.getx(),ends.gety());
    }
};


class Triangle :public shape{

    point a;
    point b;
    point c;
    int num;
public:

    Triangle(int x1,int y1,int x2,int y2,int x3,int y3,int c)
        :a(x1,y1),b(x2,y2),c(x3,y3)
        ,shape(c)
    {
        //color=c;
    }

    ~Triangle(){//cout<<"Triangle destructor\n";
    }

     void draw(){
        line(a.getx(),a.gety(),b.getx(),b.gety());
        line(b.getx(),b.gety(),c.getx(),c.gety());
        line(c.getx(),c.gety(),a.getx(),a.gety());
    }




};


class Circle :public shape{
point a;
int radius;
int num;

public:


    Circle(int x1,int y1,int r,int c)
        :a(x1,y1),shape(color)
    {
        //color=c;
        radius=r;

    }

    ~Circle(){//cout<<"Line destructor\n";
    }

     void draw(){
        circle(a.getx(),a.gety(),radius);
    }





};


///class picture  ------------------------------
class Pic
{
    Rect* pRect;
    Line* pLine;
    Triangle* pTriang;
    Circle* pCirc;
    int RNum,TNum,LNum,CNum;
public:
    Pic(){
        RNum = 0 ; pRect = NULL;
        TNum = 0 ; pTriang = NULL;
        CNum = 0 ; pCirc = NULL;
        LNum = 0 ; pLine = NULL;

        //cout<<"Pic Ctor01 \n";
    }
    Pic ( Rect* rArr , int R,Line* lArr,int l,Triangle* tArr,int t,Circle* cArr,int c){
        pRect = rArr;
        RNum = R;
        pLine=lArr;
        LNum=l;
        pTriang=tArr;
        TNum=t;
        pCirc=cArr;
        CNum=c;
        //cout<<"Pic Ctor02 \n";
    }
    ~Pic() {//cout <<"Pic Destructor \n";
    }
    void SetRect ( Rect* rArr , int R){
        pRect = rArr;
        RNum = R;
    }

    void SetLine ( Line* lArr , int l){
        pLine = lArr;
        LNum = l;
    }

    void SetTriang ( Triangle* tArr , int t){
        pTriang = tArr;
        TNum = t;
    }

    void SetCirc ( Circle* cArr , int c){
        pCirc = cArr;
        CNum = c;
    }


    void draw(shape** sh,int c)
    {
        for ( int i=0 ; i < c; i++)
            sh[i]->draw();

    }



};



int main()
{

    initgraph();


    Rect *rArr ;
    Line *lArr ;
    Triangle *tArr ;
    Circle *cArr ;

    rArr = new Rect[1]{Rect(574 , 87 , 1088 , 468 ,100)};

    cArr = new Circle[1]{Circle(840,280,200,100)};

    tArr = new Triangle[1]{Triangle(585,88,1088,88,842,204,100)};

    shape *sh[3]={rArr,cArr,tArr};
    Pic p;
    setcolor(11);
    p.draw(sh,3);





    delete []rArr;
    delete []tArr;
    delete []cArr;






    return 0;
}
