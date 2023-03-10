#include <stdio.h>
#include <stdlib.h>

typedef struct n n;

struct n
{
    int val;
    n *left;
    n *right;
};

typedef n node;

node *addnode(node *struc, int x)
{
    node *root = struc;

    if (root == NULL)
    {
        root = (node *)malloc(sizeof(node));
        root->val = x;
        root->left = NULL;
        root->right = NULL;
        return root;
    }
    else
    {
        if (root->right == NULL && root->val < x)
        {
            root->right = (node *)malloc(sizeof(node));
            root->right->val = x;
            root->right->right = NULL;
            root->right->left = NULL;
            return struc;
        }
        else if (root->left == NULL && root->val > x)
        {
            root->left = (node *)malloc(sizeof(node));
            root->left->val = x;
            root->left->right = NULL;
            root->left->left = NULL;
            return struc;
        }
        if (root->val < x)
        {
            addnode(root->right, x);
        }
        else if (root->val >= x)
        {
            addnode(root->left, x);
        }
    }
}

int max(node *root)
{
    node *temp = root;
    while (temp->right != NULL)
    {
        temp = temp->right;
    }
    printf("Max value is : %d\n", temp->val);
}

int min(node *root)
{
    node *temp = root;
    while (temp->left != NULL)
    {
        temp = temp->left;
    }
    printf("Max value is : %d\n", temp->val);
}

void printnode(node *root)
{
    if (root == NULL)
    {
        return;
    }
    printnode(root->left);
    printf("%d ", root->val);
    printnode(root->right);
}

void find(node *root, int x)
{
    if (root == NULL)
    {
        printf("This is null.\n");
        return;
    }
    if (root->val == x)
    {
        printf("%d is in the tree.\n", x);
        return;
    }
    else if (root->right && root->val < x)
    {
        find(root->right, x);
    }
    else if (root->left && root->val > x)
    {
        find(root->left, x);
    }
    else
    {
        printf("%d doesnt exist in the tree.\n", x);
    }
}

node *sil(node *root, int x)
{
    if (root == NULL)
    {
        printf("This is null.\n");
        return root;
    }

    node *temp = root;
    if (temp->val == x)
    {
        temp = NULL;
        return root;
    }
    else if (temp->right && temp->val < x)
    {
        sil(temp->right, x);
    }
    else if (temp->left && temp->val > x)
    {
        sil(temp->left, x);
    }
}

int main()
{
    node *root = NULL;
    root = addnode(root, 10);
    printnode(root);
    printf("\n");

    addnode(root, 15);
    printnode(root);
    printf("\n");

    addnode(root, 12);
    printnode(root);
    printf("\n");

    addnode(root, 9);
    printnode(root);
    printf("\n");

    addnode(root, 2);
    printnode(root);
    printf("\n");

    max(root);
    min(root);

    find(root, 15);

    root = sil(root, 2);
    printnode(root);
    printf("\n");
}