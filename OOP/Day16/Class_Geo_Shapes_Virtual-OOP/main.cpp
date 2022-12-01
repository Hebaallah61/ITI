#include <iostream>


                                                   ///virtual method C++
using namespace std;
///abstract class with pure virtual method
class Geoshape{
protected:
    int dim1, dim2;
public:
    Geoshape(){}
    Geoshape(int d1,int d2){
    dim1=d1;
    dim2=d2;

    }
    ~Geoshape(){}
    void setd1(int d1){dim1=d1;}
    void setd2(int d2){dim2=d2;}
    int getd1(){return dim1;}
    int getd2(){return dim2;}
    //virtual
     virtual double Calc_Area()=0;
    //virtual double Sum_Shapes_Area() = 0;///virtual function of sum

};

class Rect:public Geoshape{
public:
    Rect(){}
    Rect(int h,int w):Geoshape(w,h){}
    ~Rect(){}
    double Calc_Area(){return dim1*dim2;}///implement of virtual method
    void setd1(int d1){dim1=d1;}///override of set & get
    void setd2(int d2){dim2=d2;}
    int getd1(){return dim1;}
    int getd2(){return dim2;}


};

class Circle:public Geoshape{
protected:
   int radius;
public:
    Circle(){}
    Circle(int r):Geoshape(r,r){}
    ~Circle(){}
    double Calc_Area(){return 3.14*dim1*dim2;}
 ///override of set & get in this case it will cause a problem because of changing the radius of circle as dim1 different from dim 2
    /*void setd1(int d1){dim1=d1;}
      void setd2(int d2){dim2=d2;}
      int getd1(){return dim1;}
      int getd2(){return dim2;}*/
};

class Triangle:public Geoshape{
public:
    Triangle(){}
    Triangle(int h,int w):Geoshape(w,h){}
    ~Triangle(){}
    double Calc_Area(){return 0.5*dim1*dim2;}
    void setd1(int d1){dim1=d1;}///override of set & get
    void setd2(int d2){dim2=d2;}
    int getd1(){return dim1;}
    int getd2(){return dim2;}

};

class Square:public Geoshape{
public:
    Square(){}
    Square(int l):Geoshape(l,l){}
    ~Square(){}
    double Calc_Area(){return dim1*dim2;}
 ///override of set & get in this case it will cause a problem because of changing the dim of square as dim1 different from dim 2
    /*void setd1(int d1){dim1=d1;}///override of set & get
    void setd2(int d2){dim2=d2;}
    int getd1(){return dim1;}
    int getd2(){return dim2;}*/


};
///virtual method -------------------------------------------------------------------------------------
double Sum_Shapes_Area(Geoshape** Garr,int c){
    double sum=0;
    for(int i=0;i<c;i++){

        sum+=Garr[i]->Calc_Area();
    }
    return sum;

}


int main()
{
    Triangle arrt[2]={Triangle(0,0),Triangle(0,0)};
    Circle arrc[2]={Circle(0),Circle(0)};
    Rect arrr[2]={Rect(0,0),Rect(0,0)};
    Square arrs[2]={Square(0),Square(0)};
    int n,i=0,d1,d2,x=0;
    char choice;
    cout<<"\t\t\t\t\t\tchoose the shape\n";
    cout<<"a-Triangle\nb-Square\nc-Circle\nd-Rectangle\n0-exit\n";
    cout<<"Enter your choice: ";
    cin>>choice;
    do{
    switch(choice){
    case 'a':
        {
        cout<<"Enter dim1: ";
        cin>>d1;
        cout<<"Enter dim2: ";
        cin>>d2;
        Geoshape *pt=new Triangle();
        Triangle T(d1,d2);
        arrt[i]=T;
        i++;
        cout<<"Area: "<<T.Calc_Area()<<endl;
        }

        break;
    case 'b':
        {
        cout<<"Enter dim: ";
        cin>>d1;
        Geoshape *pt=new Square();
        Square S(d1);
        arrs[i]=S;
        i++;
        cout<<"Area: "<<S.Calc_Area()<<endl;
        }

        break;

    case 'c':
        {
        cout<<"Enter radius: ";
        cin>>d1;
        Geoshape *pt=new Circle();
        Circle C(d1);
        arrc[i]=C;
        i++;
        cout<<"Area: "<<C.Calc_Area()<<endl;
        }

        break;
    case 'd':
        {
        cout<<"Enter dim1: ";
        cin>>d1;
        cout<<"Enter dim2: ";
        cin>>d2;
        Geoshape *pt=new Rect();
        Rect R(d1,d2);
        arrr[i]=R;
        i++;
        cout<<"Area: "<<R.Calc_Area()<<endl;
        }

        break;

    }
    cout<<"Enter your choice: ";
    cin>>choice;
    }while(choice!='0');






Geoshape *ptr[8]={arrt,&arrt[1],arrc,&arrc[1],arrr,&arrr[1],arrs,&arrs[1]};

cout<<"sum of all areas: ";
cout<<Sum_Shapes_Area(ptr,8);


    return 0;
}
