#include <stdio.h>
#include <stdlib.h>

typedef struct node node;

struct node
{
    int data;
    node *sol;
    node *sag;
};

typedef struct node n;
typedef n *nptr;

struct tree
{
    node *kok;
};

typedef struct tree t;
typedef t *tptr;

nptr newNode(int x)
{
    nptr nptr1 = (nptr)malloc(sizeof(n));
    nptr1->data = x;
    nptr1->sag = NULL;
    nptr1->sol = NULL;
    return nptr1;
}

tptr newTree(nptr nptr1)
{
    tptr tptr1 = (tptr)malloc(sizeof(t));
    tptr1->kok = nptr1;
    return tptr1;
}

void addToTree(tptr tree, nptr node)
{
    if (tree->kok == NULL)
    {
        tree->kok = node;
        return;
    }
    nptr tmp = tree->kok;
    while (tmp != NULL)
    {
        if (node->data > tmp->data)
        {
            if (tmp->sag != NULL)
            {

                tmp = tmp->sag;
            }
            else
            {
                tmp->sag = node;
                return;
            }
        }
        else
        {
            if (tmp->sol != NULL)
            {

                tmp = tmp->sol;
            }
            else
            {
                tmp->sol = node;
                return;
            }
        }
    }
}

nptr searchNode(tptr tree1, int x)
{
    if (tree1->kok == NULL)
    {
        printf("Agac bos.\n");
    }
    nptr temp = tree1->kok;
    while (temp != NULL)
    {
        if (temp->data == x)
        {
            printf("%d agacta bulundu.\n", x);
            return temp;
        }
        else
        {
            if (temp->data > x)
            {
                temp = temp->sol;
            }
            else
            {
                temp = temp->sag;
            }
        }
    }
    printf("Aranan deger (%d) agacta yok.\n", x);
}

nptr minNode(tptr tree)
{
    if (tree->kok == NULL)
    {
        printf("Agacin koku bos.\n");
    }
    nptr temp = tree->kok;
    while (temp->sol != NULL)
    {
        temp = temp->sol;
    }
    return temp;
}

nptr maxNode(tptr tree)
{
    if (tree->kok == NULL)
    {
        printf("Agacin koku bos.\n");
    }
    nptr temp = tree->kok;
    while (temp->sag != NULL)
    {
        temp = temp->sag;
    }
    return temp;
}

void removeNode(tptr tree, int x)
{
    if (tree->kok == NULL)
    {
        printf("Agac bos.\n");
    }
    nptr temp = tree->kok;
    while (temp != NULL)
    {
        if (temp->sag && temp->sag->data == x)
        {
            if (temp->sag->sag == NULL && temp->sag->sol == NULL)
            {
                temp->sag = NULL;
            }
            else if (temp->sag->sag != NULL && temp->sag->sol != NULL)
            {
                temp->sag->sag->sol = temp->sag->sol;
                temp->sag = temp->sag->sag;
            }
            else if (temp->sag->sag != NULL && temp->sag->sol == NULL)
            {
                temp->sag = temp->sag->sag;
            }
            else if (temp->sag->sag == NULL && temp->sag->sol != NULL)
            {
                temp->sag = temp->sag->sol;
            }
            return;
        }

        if (temp->sol && temp->sol->data == x)
        {
            if (temp->sol->sag == NULL && temp->sol->sol == NULL)
            {
                temp->sol = NULL;
            }
            else if (temp->sol->sag != NULL && temp->sol->sol != NULL)
            {
                temp->sol->sag->sol = temp->sol->sol;
                temp->sol = temp->sol->sag;
            }
            else if (temp->sol->sag != NULL && temp->sol->sol == NULL)
            {
                temp->sol = temp->sol->sag;
            }
            else if (temp->sol->sag == NULL && temp->sol->sol != NULL)
            {
                temp->sol = temp->sol->sol;
            }
            return;
        }

        if (temp->data > x)
        {
            temp = temp->sag;
        }
        else
        {
            temp = temp->sol;
        }
    }
    printf("Silmek istenen deger (%d) agacta yok.\n", x);
}

int main()
{
    tptr tree = newTree(newNode(4));
    searchNode(tree, 4);
    searchNode(tree, 5);
    addToTree(tree, newNode(5));
    addToTree(tree, newNode(1));
    addToTree(tree, newNode(8));
    searchNode(tree, 8);
    removeNode(tree, 8);
    return 0;
}