#include <iostream>


                                                   ///overriding in C++
using namespace std;

class Geoshape{
protected:
    int dim1, dim2;
public:
    Geoshape(int d1,int d2){
    dim1=d1;
    dim2=d2;
    }
    ~Geoshape(){}
    void setd1(int d1){dim1=d1;}
    void setd2(int d2){dim2=d2;}
    int getd1(){return dim1;}
    int getd2(){return dim2;}

};

class Rect:protected Geoshape{
public:
    Rect(int h,int w):Geoshape(w,h){}
    ~Rect(){}
    int Calc_Area(){return dim1*dim2;}
    void setd1(int d1){dim1=d1;}///override of set & get
    void setd2(int d2){dim2=d2;}
    int getd1(){return dim1;}
    int getd2(){return dim2;}

};

class Circle:protected Geoshape{
protected:
   int radius;
public:
    Circle(int r):Geoshape(r,r){}
    ~Circle(){}
    int Calc_Area(){return 3.14*dim1*dim2;}
 ///override of set & get in this case it will cause a problem because of changing the radius of circle as dim1 different from dim 2
    /*void setd1(int d1){dim1=d1;}
      void setd2(int d2){dim2=d2;}
      int getd1(){return dim1;}
      int getd2(){return dim2;}*/
};

class Triangle:protected Geoshape{
public:
    Triangle(int h,int w):Geoshape(w,h){}
    ~Triangle(){}
    int Calc_Area(){return 0.5*dim1*dim2;}
    void setd1(int d1){dim1=d1;}///override of set & get
    void setd2(int d2){dim2=d2;}
    int getd1(){return dim1;}
    int getd2(){return dim2;}

};

class Square:protected Geoshape{
public:
    Square(int l):Geoshape(l,l){}
    ~Square(){}
    int Calc_Area(){return dim1*dim2;}
 ///override of set & get in this case it will cause a problem because of changing the dim of square as dim1 different from dim 2
    /*void setd1(int d1){dim1=d1;}///override of set & get
    void setd2(int d2){dim2=d2;}
    int getd1(){return dim1;}
    int getd2(){return dim2;}*/


};

int Sum_Shapes_Area(int s1,int s2,int s3,int s4,int *arrc,int *arrt,int *arrs,int *arrr){
       int c=0,t=0,r=0,s=0,total=0;
       for(int i=0;i<s1;i++)///circles area
           c+=arrc[i];
       for(int i=0;i<s2;i++)///triangles area
           t+=arrt[i];
       for(int i=0;i<s3;i++)///circles area
           s+=arrs[i];
       for(int i=0;i<s4;i++)///circles area
           r+=arrr[i];
       total=c+t+s+r;
       return total;

}



int main()
{
   ///Rect R1(10,13);
   ///cout<<R1.Calc_Area()<<endl;
   ///Square S1(10);
   ///not allowed after making set & get protected
   ///S1.setd1(100);
   /// S1.setd2(5);
   ///cout<<S1.Calc_Area();
   ///S1.Geoshape::setd1(6);///this is not good practice solution is making set&get protected
    int arrT[5]={0};
    int arrS[5]={0};
    int arrC[5]={0};
    int arrR[5]={0};
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
        cout<<"Enter dim1";
        cin>>d1;
        cout<<"Enter dim2";
        cin>>d2;
        Triangle T(d1,d2);
        arrT[i]=T.Calc_Area();
        i++;
        cout<<"Area: "<<T.Calc_Area()<<endl;
        }

        break;
    case 'b':
        {
        cout<<"Enter dim";
        cin>>d1;
        Square S(d1);
        arrS[i]=S.Calc_Area();
        i++;
        cout<<"Area: "<<S.Calc_Area()<<endl;
        }

        break;

    case 'c':
        {
        cout<<"Enter radius";
        cin>>d1;
        Circle C(d1);
        arrC[i]=C.Calc_Area();
        i++;
        cout<<"Area: "<<C.Calc_Area()<<endl;
        }

        break;
    case 'd':
        {
        cout<<"Enter dim1";
        cin>>d1;
        cout<<"Enter dim2";
        cin>>d2;
        Rect R(d1,d2);
        arrR[i]=R.Calc_Area();
        i++;
        cout<<"Area: "<<R.Calc_Area()<<endl;
        }

        break;

    }
    cout<<"Enter your choice: ";
    cin>>choice;
    }while(choice!='0');


cout<<"\n Sum of All Areas of All Entered Shapes: ";
x=Sum_Shapes_Area(5,5,5,5,arrC,arrT,arrS,arrR);
cout<<x;



    return 0;
}
