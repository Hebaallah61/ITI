#include <stdio.h>
#include <stdlib.h>

void merge(int arr[],int start,int mid,int end){
    int length1=mid-start+1;
    int length2=end-mid;
    int leftarr[length1];
    int rigtharr[length2];
    int start_temp=start;

    for(int i=0;i<length1;i++){
        leftarr[i]=arr[start+i];
    }

    for(int j=0;j<length2;j++){
        rigtharr[j]=arr[mid+j+1];
    }


    int i=0,j=0;
    while((i<length1)&&(j<length2)){///merge based on smallest num
        if(leftarr[i]<=rigtharr[j]){///<=
            arr[start_temp]=leftarr[i];
            i++;
        }
        else{
            arr[start_temp]=rigtharr[j];
            j++;
        }
        start_temp++;
    }


    while(i<length1){///if there is more index we will put them as it is
        arr[start_temp]=leftarr[i];
        start_temp++;
        i++;
    }

    while(j<length2){
        arr[start_temp]=rigtharr[j];
        start_temp++;
        j++;
    }

}



void merge_sort(int arr[],int start ,int end){
    if(start<end){
        int middle=start+(end-start)/2;
        merge_sort(arr,start,middle);
        merge_sort(arr,middle+1,end);
        merge(arr,start,middle,end);
    }

}

void print(int arr[],int size){

for(int i=0;i<size;i++){
        printf("%d ",arr[i]);
        printf("\n");
    }

}

int main()
{
    int x[5]={1,2,5,3,7};
    merge_sort(x,0,4);
    print(x,5);

    return 0;
}
