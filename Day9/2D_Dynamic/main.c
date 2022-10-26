#include <stdio.h>
#include <stdlib.h>

int main()
{
   int **Arr,*sum,*avg,i,j;///rows==member , cols==subjects
   int rowsnum,colsnum;
   printf("Enter Members Number: ");
   scanf("%d",&rowsnum);
   printf("Enter Materials Number: ");
   scanf("%d",&colsnum);
   Arr=(int**) malloc(rowsnum*sizeof(int*));
   sum=(int*) malloc(rowsnum*sizeof(int));
   for(i=0;i<rowsnum;i++){
        Arr[i]=(int *)malloc(colsnum*sizeof(int));
   }

        avg=(int*)malloc(colsnum*sizeof(int));


   for(i=0;i<rowsnum;i++){
    sum[i]=0;
   }

   for(i=0;i<colsnum;i++){
    avg[i]=0;
   }

   for(i=0;i<rowsnum;i++){
    for(j=0;j<colsnum;j++){
        printf("\nMaterial[%i],Member[%i]: ",j+1,i+1);
        scanf("%d",&Arr[i][j]);
        sum[i]+=Arr[i][j];
        avg[j]+=Arr[i][j];
    }
   }

   for(i=0;i<rowsnum;i++){
    printf("\nSum of Raw[%d]=%d\n",i+1,sum[i]);
   }

   for(i=0;i<colsnum;i++){
    avg[i]/=rowsnum;

    printf("\nAvg of column[%d]=%d\n",i+1,avg[i]);
   }



   for(i=0;i<rowsnum;i++){
    free(Arr[i]);
   }

   free(Arr);
   free(sum);
   free(avg);




    return 0;
}
