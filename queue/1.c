#include <stdio.h>
#include <stdlib.h>

typedef struct n n;

struct n
{
    int x;
    n *next;
};

typedef n node;

node *enqueue(node *head, int x)
{
    if (head == NULL)
    {
        head = (node *)malloc(sizeof(node));
        head->x = x;
        head->next = NULL;
        return head;
    }
    else
    {
        node *temp = head;
        while (temp->next != NULL)
        {
            temp = temp->next;
        }
        temp->next = (node *)malloc(sizeof(node));
        temp->next->x = x;
        temp->next->next = NULL;
        return head;
    }
}

int dequeue(node *head)
{
    if (head == NULL)
    {
        printf("Queue is empty.\n");
        return -1;
    }
    if (head->next == NULL)
    {
        int holdn = head->x;
        node *messi = NULL;
        head = messi;
        return holdn;
    }
    node *temp = head;
    while (temp->next->next != NULL)
    {
        temp = temp->next;
    }
    node *hold = temp->next;
    int holdn = hold->x;
    temp->next = NULL;
    free(hold);
    return holdn;
}

void printqueue(node *queue)
{
    if (queue == NULL)
    {
        printf("Queue is empty.\n");
        return;
    }
    while (queue != NULL)
    {
        printf("%d ", queue->x);
        queue = queue->next;
    }
    printf("\n");
}

int main()
{
    node *queue = NULL;
    printqueue(queue);
    queue = enqueue(queue, 10);
    printqueue(queue);
    queue = enqueue(queue, 20);
    printqueue(queue);
    queue = enqueue(queue, 30);
    printqueue(queue);
    dequeue(queue);
    printqueue(queue);
    dequeue(queue);
    printqueue(queue);
    dequeue(queue);
    printqueue(queue);
    queue = enqueue(queue, 30);
    printqueue(queue);
    return 0;
}