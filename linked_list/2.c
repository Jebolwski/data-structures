#include <stdio.h>
#include <stdlib.h>

typedef struct n n;

struct n
{
    int x;
    n *next;
    n *prev;
};

typedef n node;

void print_list(node *root)
{
    while (root != NULL)
    {
        printf("%d ", root->x);
        root = root->next;
    }
    printf("\n");
}

void add_to_list(node *root, int val)
{
    while (root->next != NULL)
    {
        root = root->next;
    }
    root->next = (node *)malloc(sizeof(node));
    root->next->x = val;
    root->next->next = NULL;
    root->next->prev = root;
}

void remove_from_list(node *root, int val)
{
    while (root->next != NULL)
    {
        if (root->next->x == val)
        {
            node *del = root->next;
            root->next->next->prev = root;
            root->next = root->next->next;
            free(del);
            break;
        }
        root = root->next;
    }
}

void update_list(node *root, int old_value, int new_value)
{
    while (root != NULL)
    {
        if (root->x == old_value)
        {
            root->x = new_value;
            break;
        }
        root = root->next;
    }
    return;
}

void main()
{
    node *root = (node *)malloc(sizeof(node));
    root->x = 5;
    root->prev = NULL;
    root->next = (node *)malloc(sizeof(node));
    root->next->x = 10;
    root->next->next = NULL;
    root->next->prev = root->next;
    add_to_list(root, 15);
    print_list(root);
    add_to_list(root, 20);
    print_list(root);
    remove_from_list(root, 15);
    print_list(root);
    update_list(root, 10, 21);
    print_list(root);
}