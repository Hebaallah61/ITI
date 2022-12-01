#include <stdio.h>
#include <stdlib.h>
#define r 50
#define c 50
int main()
{
    int m,k;
    int arr[r][c];
    int sum[c];
    int i,j;
    printf("Enter Array rows * columns: ");
    scanf("%d%d",&m,&k);

    for(i=0;i<m;i++){
            for(j=0;j<k;j++){
                printf("Please enter element [%d][%d]: ",i+1,j+1);
                scanf("%d",&arr[i][j]);
            }

    }

    for(i=0;i<k;i++){
            for(j=0;j<m;j++){
               sum[i]+=arr[j][i];
            }
    }


    for(i=0;i<k;i++){
      printf("\nsum of col %d =%d",i+1,sum[i]);
    }

    for(i=0;i<k;i++){
    printf("\navg of col %d =%d",i+1,sum[i]/m);
    }



}
