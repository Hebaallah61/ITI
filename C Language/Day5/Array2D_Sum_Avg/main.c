#include <stdio.h>
#include <stdlib.h>
#define r 50
#define c 50
int main()
{
    int m,k;
    int arr[r][c];
    int sum[r]={0};
    int i,j;
    printf("Enter Array rows * columns: ");
    scanf("%d%d",&m,&k);

    for(i=0;i<m;i++){
            for(j=0;j<k;j++){
                printf("Please enter element [%d][%d]: ",i+1,j+1);
                scanf("%d",&arr[i][j]);
            }

    }

    for(i=0;i<m;i++){
            for(j=0;j<k;j++){
               sum[i]+=arr[i][j];
            }

    }


    for(i=0;i<m;i++){
        printf("\nsum of row %d =%d",i+1,sum[i]);
    }



    return 0;
}
