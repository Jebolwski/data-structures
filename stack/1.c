#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int intlength(int num)
{
    char buf[50];
    itoa(num, buf, 10);
    return strlen(buf);
}

void printarr(int *arr)
{
    for (int i = 0; i < sizeof(arr); i++)
    {
        printf("%d ", arr[i]);
    }
    printf("\n");
}

int len(int *arr)
{
    for (int i = sizeof(arr) - 1; i > -1; i--)
    {
        if (arr[i] != 0 && intlength(arr[i]) <= 8)
        {
            return i + 1;
        }
    }
    return 4;
}

int *doublesize(int *arr)
{
    int *newarr = (int *)malloc(sizeof(arr) * 2 * sizeof(int));
    for (int i = 0; i < len(arr); i++)
    {
        newarr[i] = arr[i];
    }
    newarr[len(arr)] = 32;
    return newarr;
}

int pop(int *arr)
{
    int temp = arr[len(arr) - 1];
    arr[len(arr) - 1] = 0;
    return temp;
}

void push(int *arr, int val)
{
    if (len(arr) == sizeof(arr))
    {
        printf("%d\n", sizeof(arr));
        arr = doublesize(arr);
        printf("%d\n", sizeof(arr));
        arr[len(arr)] = val;
        return;
    }
    else
    {
        arr[len(arr)] = val;
    }
    return;
}

int main()
{
    int *arr = (int *)malloc(sizeof(int) * 4);
    arr[0] = 1;
    arr[1] = 2;
    arr[2] = 3;
    printarr(arr);
    push(arr, 81);
    printarr(arr);
    push(arr, 42);
    printarr(arr);
}