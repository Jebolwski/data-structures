#include <stdio.h>
#include <stdlib.h>
#define MAX 5
int dizi[MAX];
int bas = 0;
int son = 0;

void ekle(int val)
{
    if (son != MAX)
    {
        dizi[son] = val;
        son++;
    }
    else
    {
        printf("Dizi dolu.\n");
    }
}

int cikar()
{
    if (son == 0)
    {
        printf("Cikaracak eleman yok.\n");
        return -1;
    }
    int ret = dizi[0];
    int dizi2[MAX];
    bas++;
    int x = son - bas;
    for (int i = bas; i < son; i++)
    {
        dizi2[i - bas] = dizi[i];
    }
    for (int i = 0; i < MAX; i++)
    {
        dizi[i] = dizi2[i];
    }
    bas = 0;
    son = x;
    return ret;
}

void printDizi()
{
    for (int i = bas; i < son; i++)
    {
        printf("%d ", dizi[i]);
    }
    printf("\n");
}

int main()
{
    ekle(4);
    printDizi();
    cikar();
    printDizi();
    cikar();
    printDizi();
    ekle(6);
    printDizi();
    ekle(8);
    printDizi();
    ekle(9);
    printDizi();
    ekle(10);
    printDizi();
    ekle(11);
    printDizi();
    ekle(11);
}