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

// listede istenilen bir düğümden sonra eleman ekleme
void addtoMiddle(nptr dugum1, nptr dugum2)
{
    nptr temp = dugum1->ileri;
    dugum1->ileri = dugum2;
    dugum2->ileri = temp;
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
    int count = 0;
    listptr templist = list;
    while (templist->bas)
    {
        templist->bas = templist->bas->ileri;
        count++;
    }
    return count;
}

// listede istenilen bir düğümden sonra eleman ekleme
void addtoMiddle2(listptr liste, nptr dugum)
{
    nptr temp = liste->bas;
    for (int i = 0; i < (listSize(liste) / 2) - 1; i++)
    {
        temp = temp->ileri;
    }
    dugum->ileri = temp->ileri;
    temp->ileri = dugum;
}

// listenin sonuna eleman ekleme
void addtoEnd(listptr liste, nptr dugum)
{
    if (liste->bas == NULL)
    {
        liste->bas = dugum;
        liste->son = dugum;
        return;
    }
    else
    {
        liste->son->ileri = dugum;
        dugum->ileri = NULL;
        liste->son = dugum;
    }
}

// listenin başına eleman ekleme
void addtoHead(listptr liste, nptr dugum)
{
    if (liste->son == NULL)
    {
        liste->son = dugum;
    }
    dugum->ileri = liste->bas;
    liste->bas = dugum;
}

// istenilen sıradaki elemanı getiren fonk
nptr getNode(listptr liste, int x)
{
    nptr temp = liste->bas;
    if (x > listSize(liste))
    {
        printf("Istediginiz indeks listeyi asiyor.\n");
        return NULL;
    }
    for (int i = 0; i < x; i++)
    {
        temp = temp->ileri;
    }
    return temp;
}

// listeyi bastırma
void printList(listptr list)
{
    nptr head = list->bas;
    while (head)
    {
        printf("%d --> ", head->data);
        head = head->ileri;
    }
    printf("NULL\n");
}

// veriye göre eleman çağırma
nptr listSearch(listptr list, int x)
{
    nptr temp = list->bas;
    while (temp)
    {
        if (temp->data == x)
        {
            printf("Eleman bulundu.\n");
            return temp;
        }
        temp = temp->ileri;
    }
    printf("Bu eleman listede bulunmamaktadir.\n");
    return NULL;
}

// listenin başından eleman silme
void removeHead(listptr list)
{
    if (list->bas == NULL)
    {
        printf("Liste bos.\n");
        return;
    }
    if (list->bas->ileri == NULL)
    {
        nptr temp = list->bas;
        list->bas = NULL;
        list->son = NULL;
        free(temp);
        return;
    }
    nptr temp = list->bas;
    list->bas = list->bas->ileri;
    free(temp);
}

// listenin sonundan eleman silme
void removeEnd(listptr list)
{
    if (list->son == NULL)
    {
        printf("Liste bos.\n");
        return;
    }
    if (list->bas == list->son)
    {
        nptr temp = list->bas;
        list->bas = NULL;
        list->son = NULL;
        free(temp);
        return;
    }
    nptr temp = list->bas;
    while (temp->ileri->ileri)
    {
        temp = temp->ileri;
    }
    nptr temp2 = temp->ileri;
    temp->ileri = NULL;
    free(temp2);
    return;
}

// listenin ortasından eleman silme
void removeMiddle(listptr liste)
{
    if (liste->bas == NULL)
    {
        printf("Liste bos.\n");
        return;
    }
    if (liste->bas == liste->son)
    {
        nptr temp = liste->bas;
        liste->bas = NULL;
        liste->son = NULL;
        free(temp);
        return;
    }
    nptr temp = liste->bas;
    for (int i = 0; i < (listSize(liste) / 2) - 1; i++)
    {
        liste->bas = liste->bas->ileri;
    }
    nptr temp2 = liste->bas->ileri;
    liste->bas->ileri = liste->bas->ileri->ileri;
    liste->bas = temp;
    free(temp2);
    return;
}

int main()
{
    listptr list = newList();
    nptr n1 = newNode(10);
    nptr n2 = newNode(20);
    nptr n3 = newNode(25);
    nptr n4 = newNode(30);
    addtoHead(list, n1);
    addtoEnd(list, n2);
    printList(list);
    addtoEnd(list, n4);
    addtoHead(list, n3);
    printList(list);
    addtoMiddle2(list, newNode(34));
    printList(list);
    removeHead(list);
    printList(list);
    removeMiddle(list);
    printList(list);
}