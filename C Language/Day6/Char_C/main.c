#include <stdio.h>
#include <stdlib.h>
#define Max_Size 10
#include <string.h>
int main()
{


        int i;
        char address[Max_Size],ch;/*
        printf("Please Enter your own address \n");
        gets(address);

        printf("your address is: ");
        puts(address);
*/



        printf("Please Enter your own address \n");
        for(i=0;i<Max_Size;i++){
            ch=_getche();
            if(ch==0x0D){

                address[i]='\0';
                break;
            }
            address[i]=ch;

        }

        printf("\n ");

        i=0;
        while(address[i]!='\0'){
           printf("%c",address[i++]);
        }







    return 0;
}
