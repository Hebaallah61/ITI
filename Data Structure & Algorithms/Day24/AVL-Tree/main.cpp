

#include <iostream>
#include<stdio.h>
using namespace std;

class Node {
   public:
  int key;
  Node *left;
  Node *right;
  int height;
};

class Tree{
public:
    Tree(){}
    Node *ptree=NULL;

int height(Node *N) {///height of node(level)
  if (N == NULL)
    return 0;
  return N->height;
}

int max(int a, int b) {
  return (a > b) ? a : b;
}


Node *newNode(int key) {
  Node *node = new Node();
  node->key = key;
  node->left = node->right = NULL;
  node->height = 1;
  return (node);
}

// Rotate right
Node *rightRotate(Node *y) {
  Node *x = y->left;
  Node *T2 = x->right;
  x->right = y;
  y->left = T2;
  y->height = max(height(y->left),height(y->right)) +1;
  x->height = max(height(x->left),height(x->right)) +1;
  return x;
}

// Rotate left
Node *leftRotate(Node *x) {
  Node *y = x->right;
  Node *T2 = y->left;
  y->left = x;
  x->right = T2;
  x->height = max(height(x->left),height(x->right)) +1;
  y->height = max(height(y->left),height(y->right)) +1;
  return y;
}


int getBalanceFactor(Node *N) {
  if (N == NULL) return 0;
  return height(N->left)-height(N->right);
}


Node *insertNode(Node* &node, Node *pnew) {

  if (node == NULL)
     node=pnew;
  if (pnew->key < node->key)
    node->left = insertNode(node->left, pnew);
  else if (pnew->key > node->key)
    node->right = insertNode(node->right, pnew);
  else
    return node;

  // Update the balance factor of each node and
  // balance the tree
  node->height = 1 + max(height(node->left),height(node->right));
  int balanceFactor = getBalanceFactor(node);
  if (balanceFactor > 1) {
    if (pnew->key < node->left->key) {
      return rightRotate(node);
    }
    else if (pnew->key > node->left->key) {
      node->left = leftRotate(node->left);
      return rightRotate(node);
    }
  }
  if (balanceFactor < -1) {
    if (pnew->key > node->right->key) {
      return leftRotate(node);
    }
    else if (pnew->key < node->right->key) {
      node->right = rightRotate(node->right);
      return leftRotate(node);
    }
  }
  return node;
}


Node *node_with_min_value(Node *node) {
  Node *current = node;
  while (current->left != NULL)
    current = current->left;
  return current;
}


Node *deleteNode(Node* &root, int key) {

  if (root == NULL)
    return root;
  if (key < root->key)
    root->left = deleteNode(root->left, key);
  else if (key > root->key)
    root->right = deleteNode(root->right, key);
  else {
    if ((root->left == NULL) ||(root->right == NULL)) {
      Node *temp = root->left ? root->left : root->right;
      if (temp == NULL) {
        temp = root;
        root = NULL;
      }
      else
        *root = *temp;
      delete []temp;
    }
    else {
      Node *temp = node_with_min_value(root->right);
      root->key = temp->key;
      root->right = deleteNode(root->right,temp->key);
    }
  }

  if (root == NULL)
    return root;

  // Update the balance factor of each node and
  // balance the tree
  root->height = 1 + max(height(root->left),height(root->right));
  int balanceFactor = getBalanceFactor(root);
  if (balanceFactor > 1) {
    if (getBalanceFactor(root->left) >= 0) {
      return rightRotate(root);
    }
    else {
      root->left = leftRotate(root->left);
      return rightRotate(root);
    }
  }
  if (balanceFactor < -1) {
    if (getBalanceFactor(root->right) <= 0) {
      return leftRotate(root);
    }
    else {
      root->right = rightRotate(root->right);
      return leftRotate(root);
    }
  }
  return root;
}


   Node * search_in_tree(Node* proot,int key){
        if(proot!=NULL){
            if(proot->key==key)
                return proot;
            else if(proot->key>key)
                return search_in_tree(proot->left,key);
            else
                return search_in_tree(proot->right,key);
        }
        return NULL;

    }


    int countnodes(Node* proot){
        if(proot!=NULL){
            return countnodes(proot->left)+1+countnodes(proot->right);
        }
        return NULL;
    }


 void travers(Node *proot){

        if(proot!=NULL){
            travers(proot->left);
            cout<<proot->key<<endl;
            travers(proot->right);
        }

    }
};

int main() {
  Tree t1;
    Node *searcht;
    int number_of_nodes,value,key,delet;
    cout<<"Enter number_of_nodes: ";
    cin>>number_of_nodes;

    for(int i=0;i<number_of_nodes;i++){
        printf("Enter value %d: ",i+1);
        cin>>value;
        t1.insertNode(t1.ptree,t1.newNode(value));
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
    t1.deleteNode(t1.ptree,delet);
    t1.travers(t1.ptree);
    cout<<"numbers of nodes:"<<t1.countnodes(t1.ptree);

    cout<<"\nheight:"<<t1.height(t1.ptree);


}
