#include <iostream>
#include <conio.h>
#include <string>
#include <cstring>
#include <bits/stdc++.h>
#include <strstream>

using namespace std;

int countt=0;
class Complex{
    int real;
    int img;
public:
    void setreal(int r){real=r;}
    void setimg(int i){img=i;}
    int getreal(){return real;}
    int getimg(){return img;}

    Complex(Complex &n){
        real=n.real;
        img=n.img;
        countt++;
    }
    Complex (int r,int i){
        real=r;
        img=i;
        countt++;
    }
    Complex (int n){
        real=n;
        img=n;
        countt++;
    }


    Complex (){
        countt++;
    }
    Complex sum(Complex &n){
        Complex result;
        result.real=real+n.real;
        result.img=img+n.img;
        return result;
    }
    Complex sub(Complex c){
        c.real-=real;
        c.img-=img;
        return c;
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

    ///--------------------------(c1-c2)
    Complex operator -(const Complex &c){
        real-=c.real;
        img-=c.img;
        return *this;
    }


    ///----------------------------(c2-7)
    Complex operator-(int x){
        Complex result(real-x,img);
        return result;
    }

    ///----------------------------(c1-=7)
     Complex operator-=(int x){
        real-=x;
        img=img;
        return *this;
    }


    ///----------------------------(--c1)
        Complex operator--(){
            real--;
            return *this;
        }

    ///----------------------------(c1--)
        Complex operator--(int){
            Complex temp(*this);
            real--;
            return temp;
        }

    ///-----------------------------(c1==c2)
        Complex operator ==(const Complex &c){
             if(real==c.real)
                cout<<"True";
            else
                cout<<"False";

        }

    ///-----------------------------(c1!=c2)
        Complex operator !=(const Complex &c){
             if(real!=c.real)
                cout<<"True";
             else
                cout<<"False";

        }

    ///-----------------------------(c1>c2,c1>=c2)
         Complex operator >(const Complex &c){
             if(real>c.real)
                cout<<"first is grater than second\n";
             else
                cout<<"first is not grater than second\n";
        }

        Complex operator >=(const Complex &c){
             if(real>=c.real)
                cout<<"first is grater than or equal second\n";
             else
                cout<<"first is not grater than or equal second\n";

        }

    ///-----------------------------(c1<c2,c1<=c2)
        Complex operator <(const Complex &c){
             if(real<c.real)
                cout<<"second is grater than first\n";
            else
                cout<<"second is not grater than first\n";

        }

        Complex operator <=(const Complex &c){
             if(real<=c.real)
                cout<<"second is grater than or equal first\n";
            else
                cout<<"second is not grater than or equal first\n";

        }
    ///-----------------------------(int)c1
        operator int(){///no complex because of compiler
            return real;
        }

    ///-----------------------------(char*)c1

        string tost(int l){
            stringstream ss;
            ss<<l;
            string s;
            ss>>s;
            return s;
        }


       operator char*(){

            string R=tost(real);
            string I=tost(img);
            char* s=new char[100];
            int counter=0;
            for(int i=0;i<R.length();i++){
                s[counter]=R[i];
                 counter++;
            }


            s[counter++]='+';
            for(int i=0;i<I.length();i++){
                s[counter]=I[i];
                counter++;
            }

            s[counter++]='i';
            s[counter]='\0';




            return s;
        }

};



///---------------------------(7-c2)
     Complex operator-(int x,Complex& R){
        Complex result(x-R.getreal(),R.getimg());
        return result;
    }

///----------------------------(7-=c1)!!
    Complex operator-=(int x,Complex& R){
        Complex result;
        result=x-R.getreal();
        return result;
    }



int main()
{
    int R1,I1,R2,I2,R3,I3,R4,R5,I6,R6;

    cout<<"Please Enter the Real part  of Number 1: "<<endl;
    cin>>R1;
    cout<<"Please Enter the Img part of Number 1: "<<endl;
    cin>>I1;
    cout<<"Please Enter the Real part  of Number 2: "<<endl;
    cin>>R2;
    cout<<"Please Enter the Img part of Number 2: "<<endl;
    cin>>I2;
    cout<<"Please Enter the Real part  of Number 3: "<<endl;
    cin>>R3;
    cout<<"Please Enter the Img part of Number 3: "<<endl;
    cin>>I3;
    cout<<"Please Enter the Real part  of Number 4: "<<endl;
    cin>>R4;
    cout<<"Please Enter the Real part of Number 5: "<<endl;
    cin>>R5;
    cout<<"Please Enter the Real part  of Number 6: "<<endl;
    cin>>R6;
    cout<<"Please Enter the Img part of Number 6: "<<endl;
    cin>>I6;

    Complex c1(R1,I1),c2(R2),c3,c4,c5,c6;
    Complex c1_(R3,I3),c7(R4),c8(R5),c9(R6,I6),c10(13,5);
    char *ch=c10;
    cout<<"Number1= " ;
    c1.print();
    cout<<"Number2= ";
    c2.print();
    cout<<"Number3= " ;
    c7.print();
    cout<<"Number4= ";
    c8.print();

    c3 = c1.sum(c2);
    cout<<"sum= ";
    c3.print();
    c4=c1-c2;///c4=c2.sub(c1);
    cout<<"sub= ";
    c4.print();
    c5=c2-3;///-------------
    cout<<"c2-3= ";
    c5.print();
    c5=3-c2;///-------------
    cout<<"3-c2= ";
    c5.print();
    c1-=3;///-------------
    cout<<"(c1-=3)= ";
    c1.print();
    3-=c1;///-------------
    cout<<"(3-=c1)= ";
    c1.print();

    ///-------------
    --c1_;
    cout<<"(--c3)= ";
    c1_.print();
    ///-------------
    c6=c1_-- ;
    cout<<"(c3--)= ";
    c6.print();
    ///-------------
    cout<<"\n(c4!=c5): ";
    c7!=c8;
    ///-------------
    cout<<"\n(c4==c5): ";
    c7==c8;
    ///-------------
    cout<<"\n(c4>c5): ";
    c7>c8;
    ///-------------
    cout<<"(c4>=c5): ";
    c7>=c8;
    ///-------------
    cout<<"(c4<c5): ";
    c7<c8;
    ///-------------
    cout<<"(c4<=c5): ";
    c7<=c8;
    ///-------------
    cout<<"(int)c9: ";
    cout<<(int)c9<<endl;
    ///-------------
    cout<<"(char*)c9: ";
    int i=0;
    char* s = c10;
    while(s[i]!='\0')
            {
                cout << s[i];
                i++;
            }
    cout<<"\nnum of object is: "<<countt<<endl;
    return 0;
}
