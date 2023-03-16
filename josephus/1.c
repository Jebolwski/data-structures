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

// liste
struct liste
{
    nptr bas;
    nptr son;
};

typedef struct liste list;
typedef list *listptr;

// boş tek yönlü liste oluşturma
listptr newList()
{
    listptr list = (listptr)malloc(sizeof(list));
    list->bas = NULL;
    list->son = NULL;
    return list;
}

// listenin sonuna eleman ekleme
void addtoEnd(listptr liste, nptr dugum)
{
    if (liste->bas == NULL)
    {
        liste->bas = dugum;
        liste->son = dugum;
        liste->bas->ileri = liste->bas;
        return;
    }
    else
    {
        liste->son->ileri = dugum;
        dugum->ileri = liste->bas;
        liste->son = dugum;
    }
}

// bir sonraki düğümü silme
void removeNext(nptr node)
{
    nptr temp = node->ileri;
    node->ileri = node->ileri->ileri;
    free(temp);
}

// listenin boyutu
int listSize(listptr list)
{
    if (list->bas == NULL)
    {
        return 0;
    }
    if (list->son == list->bas)
    {
        return 1;
    }
    int count = 1;
    nptr temp = list->bas->ileri;
    while (temp != list->bas)
    {
        temp = temp->ileri;
        count++;
    }
    return count;
}

// listenin başından eleman silme
void removeHead(listptr list)
{
    if (list->bas == NULL)
    {
        printf("Liste bos.\n");
        return;
    }
    if (list->bas->ileri == list->bas)
    {
        nptr temp = list->bas;
        list->bas = NULL;
        list->son = NULL;
        free(temp);
        return;
    }
    nptr temp = list->bas;
    list->bas = list->bas->ileri;
    list->son->ileri = list->bas;
    free(temp);
}

// listeyi bastırma
void printList(listptr list)
{
    if (list->bas != NULL)
    {

        printf("%d --> ", list->bas->data);
        nptr head = list->bas->ileri;
        while (head != list->bas)
        {
            printf("%d --> ", head->data);
            head = head->ileri;
        }
        printf("NULL\n");
    }
    else
    {
        printf("Liste Bos.\n");
    }
}

int main()
{
    listptr liste = newList();
    printf("Listenin boyutu : ");
    int x;
    scanf("%d", &x);
    for (int i = 0; i < x; i++)
    {
        addtoEnd(liste, newNode(i + 1));
    }
    nptr temp = liste->bas;
    while (listSize(liste) > 2)
    {
        if (temp->ileri == liste->bas)
        {
            nptr t = temp->ileri;
            temp->ileri = temp->ileri->ileri;
            liste->bas = temp->ileri;
            free(t);
            temp = liste->bas;
        }
        else
        {
            removeNext(temp);
            temp = temp->ileri;
        }
        printList(liste);
    }
    printf("Sona kalan kisi : %d", temp->data);
    return 1;
}