#include <iostream>

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
    Complex sum(Complex c){///with &=4cons,without &=4cons
        c.real+=real;
        c.img+=img;
        return c;
    }
    Complex sub(Complex c){
        c.real-=real;
        c.img-=img;
        return c;
    }


    /*~Complex(){
        cout<<"des"<<endl;
    }*/
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
    Complex c1(R1,I1),c2(R2,I2),c3,c4;

    cout<<"Number1= " ;
    c1.print();
    cout<<"Number2= ";
    c2.print();

    c3 = c1.sum(c2);
    cout<<"sum= ";
    c3.print();
    c4=c1.sub(c2);
    cout<<"sub= ";
    c4.print();
    cout<<"\nnum of object is: "<<countt<<endl;
    return 0;
}
