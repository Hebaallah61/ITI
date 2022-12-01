#include <iostream>
#include<stdio.h>
using namespace std;

class Node{
public:
 int Data;
 Node *pnext;
 Node *pprev;
};

class DLlist{
    public:

 Node *pstart=NULL;
 Node *plast=NULL;


 Node *newnode(int Data){

    Node *pnew=new Node;
    if(pnew==NULL) return 0;
    //scanf("%d",&pnew->Data);
    pnew->Data=Data;
    pnew->pnext=pnew->pprev=NULL;
    return pnew;

}

void  isertnode(int Data){
    Node *pnew=newnode(Data);
    if(pstart==NULL){
        pstart=plast=pnew;
    }
    else{
        Node* psearch=pstart;
        while((psearch!=NULL)&&(psearch->Data<Data)){
            psearch=psearch->pnext;
        }
        if(psearch==NULL){
            plast->pnext=pnew;
            pnew->pprev=plast;
            plast=pnew;
        }
        else if(psearch==pstart){
            pstart->pprev=pnew;
            pnew->pnext=pstart;
            pstart=pnew;
        }


        else{
           /* pnew->pnext=psearch->pnext;
            pnew->pnext->pprev=pnew;
            psearch->pnext=pnew;
            pnew->pprev=psearch;*/

            psearch->pprev->pnext=pnew;
            pnew->pnext=psearch;
            pnew->pprev=psearch->pprev->pnext;

        }

    }
}

void Display_all(){
    Node *pdisplay=pstart;
    while(pdisplay!=NULL){
        printf("Display_all ID:%d\n",pdisplay->Data);
        pdisplay=pdisplay->pnext;
    }
}

 Node *search_in_list(int id){
     Node* psearch=pstart;


    while(psearch){
        if(psearch->Data==id)
            break;
        else
            psearch=psearch->pnext;
    }
    return psearch;
}
void Display(int id){
     Node*pdisplay=search_in_list(id);
    if(pdisplay==NULL)
        printf("ID:%d NOT FOUND",id);
    else{

       printf("\nDisplayed ID:%d",pdisplay->Data);
    }
}
void Delete_By_Id(int ID){
     Node* pdelete=search_in_list(ID);
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
        delete[]pdelete;

        printf("The Element deleted\n");
     }


}
void Delete_all(){
     Node *pdelete;
     while(pstart!=NULL){
        pdelete=pstart;
        pstart=pstart->pnext;
        delete[]pdelete;
     }
     plast=NULL;
     printf("The All Elements are deleted\n");
}
};



int main()
{
    DLlist l;
    l.isertnode(1);
    l.isertnode(2);
    l.isertnode(9);
    l.Display_all();
    cout<<endl;
    l.isertnode(5);
    l.Display_all();
    cout<<endl;
    l.Display(1);
    cout<<endl;
    l.Delete_By_Id(1);
    cout<<endl;
    l.Display_all();
    return 0;
}
