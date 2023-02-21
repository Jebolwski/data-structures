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
    while (root != NULL)
    {
        printf("%d ", root->x);
        root = root->next;
    }
    printf("\n");
}

void add_to_end(node *root, int value)
{
    if (root == NULL)
    {
        printf("Root yok");
        return;
    }
    while (root->next != NULL)
    {
        root = root->next;
    }
    root->next = (node *)malloc(sizeof(node));
    root->next->x = value;
    root->next->next = NULL;
}

void delete_from_list(node *root, int value)
{
    while (root != NULL)
    {
        if (root->next->x == value)
        {
            node *to_be_deleted = root->next;
            root->next = root->next->next;
            free(to_be_deleted);
            break;
        }
        root = root->next;
    }
    return;
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
    root->x = 10;
    root->next = NULL;
    for (int i = 1; i < 11; i++)
    {
        add_to_end(root, i * 1.5);
    }

    print_list(root);
    delete_from_list(root, 13);
    print_list(root);
    delete_from_list(root, 12);
    print_list(root);
    update_list(root, 9, 61);
    print_list(root);
}