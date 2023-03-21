#include <stdio.h>
#include <stdlib.h>

typedef struct node node;

struct node
{
    int data;
    node *ileri;
};

typedef struct node n;
typedef n *nptr;

// Düğüm oluşturma
nptr newNode(int veri)
{
    nptr nptr1 = (nptr)malloc(sizeof(nptr));
    nptr1->data = veri;
    nptr1->ileri = NULL;
    return nptr1;
}

// stack
struct stack
{
    nptr bas;
};

// liste
struct stackDizi
{
    int bas;
    int boyut;
    nptr *dizi;
};

typedef struct stack stack;
typedef stack *stackptr;

// stack oluşturma
stackptr newStack()
{
    stackptr stack = (stackptr)malloc(sizeof(stack));
    stack->bas = NULL;
    return stack;
}

// stack boyutu
int size(stackptr stack)
{
    if (stack->bas == NULL)
    {
        return 0;
    }
    int count = 0;
    stackptr tempstack = stack;
    while (tempstack->bas)
    {
        tempstack->bas = tempstack->bas->ileri;
        count++;
    }
    return count;
}

// stackin başına eleman ekleme
void push(stackptr stack, nptr dugum)
{
    dugum->ileri = stack->bas;
    stack->bas = dugum;
}

// stacki bastırma
void printStack(stackptr stack)
{
    nptr head = stack->bas;
    while (head)
    {
        printf("| %d |\n", head->data);
        head = head->ileri;
    }
    printf("\n");
}

// stack başından eleman silme
nptr pop(stackptr stack)
{
    nptr temp = stack->bas->ileri;
    stack->bas = stack->bas->ileri;
    return temp;
}

nptr peek(stackptr stack)
{
    return stack->bas;
}

int main()
{
    stackptr stack = newStack();
    push(stack, newNode(5));
    printStack(stack);
    push(stack, newNode(6));
    push(stack, newNode(7));
    printStack(stack);
}