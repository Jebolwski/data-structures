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
        if (root->next == root)
        {
            printf("%d", root->x);
            printf("\n");
            return;
        }
        else
        {
            node *temp = root;
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

node *remove_from_list(node *root, int val)
{
    node *temp = root;
    if (root->next == root && root->x == val)
    {
        free(root);
        return NULL;
    }
    if (root->x == val)
    {
        node *temp = root;
        while (temp->next != root)
        {
            temp = temp->next;
        }
        temp->next = root->next;
        node *ret = root->next;
        free(root);
        return ret;
    }
    while (temp->next != root)
    {
        if (temp->next->x == val)
        {
            node *del = temp->next;
            temp->next = temp->next->next;
            free(del);
            return root;
        }
        temp = temp->next;
    }
    printf("Couldnt find the item in list (%d)\n", val);
    return root;
}

int main()
{
    node *root = NULL;
    print_list(root);
    root = add_to_list(root, 15);
    print_list(root);
    root = add_to_list(root, 20);
    print_list(root);
    root = add_to_list(root, 25);
    print_list(root);
    root = remove_from_list(root, 15);
    print_list(root);
    root = remove_from_list(root, 20);
    print_list(root);
    root = remove_from_list(root, 25);
    print_list(root);
}