#include <stdio.h>
#define r 50
#define c 50
int main()
{
    int m,k,l,q,s;
    int arr1[r][c];
    int arr2[r][c];
    int mult[r][c]={0};
    int i,j;
    char x;
    /*printf("Enter Array rows * columns for matrix one: ");
    scanf("%d%d",&m,&k);

    printf("Enter Array rows * columns for matrix two: ");
    scanf("%d%d",&l,&q);*/

    /*while(k!=l){

        printf("Error column of first matrix not equal to row of the second.\n");
        printf("Enter Array rows * columns for matrix one: ");
        scanf("%d%d",&m,&k);

        printf("Enter Array rows * columns for matrix two: ");
        scanf("%d%d",&l,&q);

    }*/
//////or
    do{

        printf("Enter Array rows * columns for matrix one: ");
        scanf("%d%d",&m,&k);

        printf("Enter Array rows * columns for matrix two: ");
        scanf("%d%d",&l,&q);

        if(k!=l){
            printf("Error column of first matrix not equal to row of the second.\n");
            printf("press EOF(0) to exit: ");
            scanf(" %d",&x);
        }
        else{


        for(i=0;i<m;i++){
            for(j=0;j<k;j++){
                printf("Please enter element [%d][%d] of array one: ",i+1,j+1);
                scanf("%d",&arr1[i][j]);
            }

        }

        for(i=0;i<l;i++){
                for(j=0;j<q;j++){
                    printf("Please enter element [%d][%d] of array two: ",i+1,j+1);
                    scanf("%d",&arr2[i][j]);
                }

        }

        for(i=0;i<m;i++){
            for(j=0;j<q;j++){
                for(s=0;s<k;s++)
                  mult[i][j]+=arr1[i][s]*arr2[s][j];
                  printf("%d\t",mult[i][j]);
            }
            printf("\n");
        }

        }
        }while(x!='\0');






    return 0;
}
