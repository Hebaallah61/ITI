#include <iostream>
#include<bits/stdc++.h>
using namespace std;


class Complex{
   public:
        int real,img;

public:
    void setreal(int r){real=r;}
    void setimg(int i){img=i;}
    int getreal(){return real;}
    int getimg(){return img;}

    Complex (int realt=0,int imgt=0){
        real=realt;
        img=imgt;
    }
    Complex sum(Complex c1,Complex c2){
        Complex num;
        num.real=c1.real+c2.real;
        num.img=c1.img+c2.img;
        return num;
    }
    Complex sub(Complex c1,Complex c2){
        Complex num;
        num.real=c1.real-c2.real;
        num.img=c1.img-c2.img;
        return num;
    }
    void print(){
        if(real>0&&img>0){
            cout<<real<<"+";
            cout<<img<<"i"<<endl;

        }
        else if(real>0&&img==0){
            cout<<real<<endl;
        }

        else if(real<0&&img>0){
            cout<<img<<"i"<<endl;
        }

        else if(real==0&&img==0){
            cout<<0;
        }
        else if(real>0||real<0&&img<0){
            cout<<real;
            cout<<img<<"i"<<endl;
        }
        else if(real==0&&img>0){
            cout<<img<<"i"<<endl;
        }
        else if(real==0&&img<0){
            cout<<img<<"i"<<endl;
        }



    }

};




int main()
{
    int R1,I1,R2,I2;
    cout<<"Please Enter the Real part  of Number 1: "<<endl;
    cin>>R1;
    cout<<"Please Enter the Img part of Number 1: "<<endl;
    cin>>I1;
    cout<<"Please Enter the Real part  of Number 2: "<<endl;
    cin>>R2;
    cout<<"Please Enter the Img part of Number 2: "<<endl;
    cin>>I2;
   Complex c1,c2,c3,c4;
   c1.setreal(R1);
   c1.setimg(I1);

   c2.setreal(R2);
   c2.setimg(I2);
    cout<<"Number1= " ;
    c1.print();
    cout<<"Number2= ";
    c2.print();

    c3 = c3.sum(c1, c2);
    cout<<"sum= ";
    c3.print();
    c4=c4.sub(c1,c2);
    cout<<"sub= ";
    c4.print();

    return 0;
}



