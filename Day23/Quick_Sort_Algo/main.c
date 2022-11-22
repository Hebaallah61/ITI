#include <stdio.h>
#include <stdlib.h>

swap(int *a,int *b){
    int temp;
    temp=*a;
    *a=*b;
    *b=temp;

}

int partition(int arr[],int start,int end)
{
	int last = arr[end];
	int index_min_mum =(start-1);

	for (int j=start;j<=end-1;j++)
	{
		if (arr[j] < last)
		{
			index_min_mum++;
			swap(&arr[index_min_mum], &arr[j]);
		}
	}
	swap(&arr[index_min_mum+1],&arr[end]);
	return (index_min_mum+1);
}

void quick_sort(int arr[], int start, int end)
{
	if (start<end)
	{
		int last_index = partition(arr,start,end);
		quick_sort(arr,start,last_index-1);
		quick_sort(arr,last_index+1,end);
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
    quick_sort(x,0,4);
    print(x,5);

    return 0;
}
