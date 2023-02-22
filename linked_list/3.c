//! Circular Linked List
#include <stdio.h>
#include <stdlib.h>

typedef struct n n;

struct n
{
    int x;
    n *next;
};

typedef n node;

void print_list(node *root)
{
    if (root != NULL)
    {
        node *temp = root;
        if (temp->next == root)
        {
            printf("%d", temp->x);
        }
        else
        {
            while (temp->next != root)
            {
                printf("%d ", temp->x);
                temp = temp->next;
            }
            printf("%d ", temp->x);
        }
    }
    else
    {
        printf("There is no item in the list");
    }
    printf("\n");
}

node *add_to_list(node *root, int val)
{
    if (root == NULL)
    {
        root = (node *)malloc(sizeof(node));
        root->x = val;
        root->next = root;
        return root;
    }
    node *temp = root;
    if (temp->next == root)
    {
        temp->next = (node *)malloc(sizeof(node));
        temp->next->x = val;
        temp->next->next = root;
    }
    else
    {
        while (temp->next != root)
        {
            temp = temp->next;
        }
        temp->next = (node *)malloc(sizeof(node));
        temp->next->x = val;
        temp->next->next = root;
    }
    return root;
}

void remove_from_list(node *root, int val)
{
    node *temp = root;
    if (root->x == val)
    {
        node *tempo = root;

        while (temp->next != tempo)
        {
            printf("mesi");
            temp = temp->next;
        }
        printf("%d\n", temp->x);
        temp->next = root->next;
        free(tempo);
        return;
    }
    while (temp->next != root)
    {
        if (temp->next->x == val)
        {
            node *del = temp->next;
            temp->next = temp->next->next;
            free(del);
            return;
        }
        temp = temp->next;
    }
    printf("Couldnt find the item in list (%d)\n", val);
    return;
}

int main()
{
    node *root = NULL;
    print_list(root);
    root = add_to_list(root, 15);
    print_list(root);
    root = add_to_list(root, 20);
    print_list(root);
    remove_from_list(root, 15);
    print_list(root);
}