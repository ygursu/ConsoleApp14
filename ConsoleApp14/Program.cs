﻿
# include <stdio.h>
# include <conio.h>
# include <string.h>


using System;

struct kitap
{
    char adi[50];
    char yazari[25];
    int fiyati;
    int sayfasi;
    char konusu[15];
    char yayinevi[25];
};

int m = 0;
int n = 0;
int sayac = 0;
int secim = 0;
struct kitap b[100];

void sirala_konu();
void sirala_fiyat();
void bul_konu();
void bul_fiyat();

void main(void)
{
    void bilgi_giris(void);
    void menu(void);

    clrscr();

    bilgi_giris();

    menu();
}

void bilgi_giris(void)
{
    printf("\n Kac Kitap gireceksiniz : ");
    scanf("%i", &sayac);
    fflush(stdin);

    for (n = 0; n < sayac; n++)
    {
        clrscr();

        printf("\n Bilgileri giriniz : ");
        printf("\n =================== ");

        printf("\n %i. Kitap bilgileri...", n + 1);

        printf("\n Adi :");
        gets(b[n].adi);
        fflush(stdin);

        printf("\n Yazari : ");
        gets(b[n].yazari);
        fflush(stdin);

        printf("\n Fiyati  : ");
        scanf("%i", &b[n].fiyati);
        fflush(stdin);

        printf("\n Sayfasi   : ");
        scanf("%i", &b[n].sayfasi);
        fflush(stdin);

        printf("\n Konusu     : ");
        gets(b[n].konusu);
        fflush(stdin);

        printf("\n Yayinevi : ");
        gets(b[n].yayinevi);
        fflush(stdin);
    }
}

void menu(void)
{
    do
    {
        printf("\n\n  MENU ");
        printf("\n  ==== ");

        printf("\n 1. Konusuna gore sirala");
        printf("\n 2. Fiyatina gore sirala");
        printf("\n 3. Konusuna gore bul");
        printf("\n 4. Fiyatina gore bul");
        printf("\n 5. Cikis");

        printf("\n\n Seciminiz : ");
        scanf("%i", &secim);
        fflush(stdin);

        switch (secim)
        {
            case 1: sirala_konu(); break;
            case 2: sirala_fiyat(); break;
            case 3: bul_konu(); break;
            case 4: bul_fiyat();
            case 5: { }; break;
            default:; break;
        }

    } while (secim != 5);
}

void printlist(void)
{
    printf("\n No \t Adi \t Fiyati \t Sayfasi \t Konusu \t Yayinevi");
    printf("\n ================================================");

    for (n = 0; n < sayac; n++)
    {
        printf("\n %i %s \t %i \t %i \t %s \t %s",
        n + 1, b[n].adi, b[n].fiyati, b[n].sayfasi, b[n].konusu, b[n].yayinevi);
    }
}

void sirala_konu(void)
{
    char temp[50];

    for (m = 0; m < sayac - 1; m++)
    {
        for (n = m + 1; n < sayac; n++)
        {
            if (strcmp(b[m].adi, b[n].adi) == 0)
            {
                strcpy(temp, b[m].adi);
                strcpy(b[m].adi, b[n].adi);
                strcpy(b[n].adi, temp);
            }
        }
    }
    printlist();
}

void sirala_fiyat(void)
{
    int temp = 0;

    for (m = 0; m < sayac - 1; m++)
    {
        for (n = m + 1; n < sayac; n++)
        {
            if (b[m].fiyati > b[n].fiyati)
            {
                temp = b[m].fiyati;
                b[m].fiyati = b[n].fiyati;
                b[n].fiyati = temp;
            }
        }
    }
    printlist();
}


void bul_konu(void)
{
    char konusu[50];
    char found = 'N';

    clrscr();

    printf("\n Hangi konuda bir kitap ariyorsunuz: ");
    gets(konusu);
    fflush(stdin);

    for (n = 0; n < sayac; n++)
    {
        if (strcmp(konusu, b[n].konusu) == 0)
        {
            printf("\n %i %s \t %i \t %i \t %s \t %s",
            n + 1, b[n].adi, b[n].fiyati, b[n].sayfasi, b[n].konusu, b[n].yayinevi);

            found = 'Y';
            break;
        }
    }

    if (found == 'N')
        printf("\n Bu konuda bir kitap bulunamadi.");
}

void bul_fiyat(void)
{
    int fromfiyati = 0;
    int uptofiyati = 0;

    clrscr();

    printf("\n Min. Fiyati : ");
    scanf("%i", &fromfiyati);
    fflush(stdin);

    printf("\n Max. Fiyati : ");
    scanf("%i", &uptofiyati);
    fflush(stdin);


    for (n = 0; n < sayac; n++)
    {
        if (b[n].fiyati >= fromfiyati && b[n].fiyati <= uptofiyati)
        {
            printf("\n %i %s \t %i \t %i \t %s \t %s",
            n + 1, b[n].adi, b[n].fiyati, b[n].sayfasi, b[n].konusu, b[n].yayinevi);

            break;
        }
    }
}