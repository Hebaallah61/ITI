#include <iostream>
#include<stdio.h>

using namespace std;

class Node{
    public:
int key;
Node *pleft;
Node *pright;
};

class Tree{
public:
    Tree(){}
    Node *ptree=NULL;
    Node* newnode(int value){
        Node *pnew=new Node();
        pnew->pleft=pnew->pright=NULL;
        pnew->key=value;
        return pnew;
    }

    void insertnode(Node* &proot,Node *pnew){///refrance to pointer
        if(proot==NULL){
            proot=pnew;
        }
        else if (pnew->key<proot->key){
            insertnode(proot->pleft,pnew);
        }
        else{
            insertnode(proot->pright,pnew);
        }

    }

    Node * search_in_tree(Node* proot,int key){
        if(proot!=NULL){
            if(proot->key==key)
                return proot;
            else if(proot->key>key)
                return search_in_tree(proot->pleft,key);
            else
                return search_in_tree(proot->pright,key);
        }
        return NULL;

    }


    int countnodes(Node* proot){
        if(proot!=NULL){
            return countnodes(proot->pleft)+1+countnodes(proot->pright);
        }
        return NULL;
    }

    int getmax(Node* proot){
        while(proot->pright!=NULL){
            proot=proot->pright;

        }
        return proot->key;
    }

    void delete_2(Node* &proot){
        Node* deletet=proot;
        if(proot->pleft==NULL){
            proot=proot->pright;
            delete [] deletet;
        }
        else if(proot->pright==NULL){
            proot=proot->pleft;
            delete [] deletet;
        }
        else{
            int ptemp=getmax(proot->pleft);///search to find max
            proot->key=ptemp;
            delete_1(proot->pleft,ptemp);


        }
    }


    void delete_1(Node* &proot,int key){///search
        if(key<proot->key)
            delete_1(proot->pleft,key);
        else if(key>proot->key)
            delete_1(proot->pright,key);
        else
            delete_2(proot);///found
    }


    void travers(Node *proot){

        if(proot!=NULL){
            travers(proot->pleft);
            cout<<proot->key<<endl;
            travers(proot->pright);
        }

    }


};




int main()
{
    Tree t1;
    Node *searcht;
    int number_of_nodes,value,key,delet;
    cout<<"Enter number_of_nodes: ";
    cin>>number_of_nodes;

    for(int i=0;i<number_of_nodes;i++){
        printf("Enter value %d: ",i+1);
        cin>>value;
        t1.insertnode(t1.ptree,t1.newnode(value));
    }
    t1.travers(t1.ptree);
    cout<<"Enter the key of search: ";
    cin>>key;
    searcht=t1.search_in_tree(t1.ptree,key);
    if(searcht!=NULL)
        cout<<"Found"<<endl;
    else
        cout<<"Not Found"<<endl;
    cout<<"numbers of nodes:"<<t1.countnodes(t1.ptree);

    cout<<"\nEnter the key to delete: ";
    cin>>delet;
    t1.delete_1(t1.ptree,delet);
    t1.travers(t1.ptree);
    cout<<"numbers of nodes:"<<t1.countnodes(t1.ptree);

    return 0;
}
