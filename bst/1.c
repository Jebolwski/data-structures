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
}