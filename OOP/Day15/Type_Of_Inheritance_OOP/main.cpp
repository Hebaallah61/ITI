#include <iostream>

using namespace std;
class parent{
    ///int x;
protected:
    ///int y;
public:
    int z;
    int x;
    int y;
    parent(int _x, int _y,int _z){
        x=_x;
        y=_y;
        z=_z;

    }

    int fun(){
       return  x+y+z;

    }

};
class child_01 : public parent{
///int a;
protected:
/// int b;
public:
    int c;
    int a;
    int b;
    child_01(int _a,int _b,int _c,int _x,int _y,int _z):
    parent(_x,_y,_z)
    {
        a=_a;
        b=_b;
        c=_c;

    }

    int fun(){
       return  x+y+z+a+b+c;

    }
};

class child_02 : public child_01{
///int k;
protected:
///    int l;
public:
    int m;
    int k;
    int l;
    child_02(int _k,int _l,int _m,int _x, int _y,int _z,int _a,int _b,int _c):
    child_01(_a,_b,_c,_x,_y,_z)
    {
        k=_k;
        l=_l;
        m=_m;

    }

    int fun(){
       return  x+y+z+a+b+c+k+l+m;

    }
};




int main()
{

parent obj_1(1,2,3);
obj_1.x=obj_1.y=obj_1.z=1;


child_01 obj_2(1,2,3,4,5,6);
obj_2.x=obj_2.y=obj_2.z=obj_2.a=obj_2.b=obj_2.c=2;

child_02 obj_3(1,2,3,4,5,6,7,8,9);
obj_3.x=obj_3.y=obj_3.z=obj_3.a=obj_3.b=obj_3.c=obj_3.k=obj_3.l=obj_3.m=3;

cout<<obj_3.x;

    return 0;
}
