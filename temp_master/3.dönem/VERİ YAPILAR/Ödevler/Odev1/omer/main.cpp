#include <iostream>
#include <fstream>
#include <stdio.h>
#include <stdlib.h>
#include <sstream> 
#include <iomanip>

#include "Dugum.h"
#include "SatirListesi.h"
#include "YoneticiListesi.h"

using namespace std;

YoneticiListesi* dosyadan_YoneticiListesi();
SatirListesi* satirdan_SatirListesi(string);
void yazdir_YoneticiListesi(YoneticiListesi*, int, int);
void yazdir_SatirListesi(SatirListesi*, int, Dugum*);

int main(int argc, char** argv) {
	YoneticiListesi* yl = dosyadan_YoneticiListesi();
	int boyut = yl->boyut;
	int b = 1;
	int s = 8;
	int dugum_yeri = 1;
	char giris;
	Dugum* silinecek_dugum = NULL;
	bool silinecek_var = false;
	yazdir_YoneticiListesi(yl, b, s);
	yazdir_SatirListesi(yl->n_inci_dugum(b + dugum_yeri - 1)->sl, dugum_yeri, silinecek_dugum);
	int son_yer;
	while (true) {
		cin >> giris;
		switch (giris) {
			case 'c':
				silinecek_var = false;
				silinecek_dugum = NULL;
				dugum_yeri = dugum_yeri + 1;
				son_yer = s % 8;
				if (son_yer == 0) son_yer = 8;
				if (dugum_yeri > son_yer) dugum_yeri = son_yer;
				break;

			case 'z':
				silinecek_var = false;
				silinecek_dugum = NULL;
				dugum_yeri = dugum_yeri - 1;
				if (dugum_yeri < 1) dugum_yeri = 1;
				break;
			
			case 'd':
				silinecek_var = false;
				silinecek_dugum = NULL;
				if (boyut > s) {
					b = s + 1;
					s += 8;
					if (boyut < s) s = boyut;
					son_yer = s % 8;
					if (son_yer == 0) son_yer = 8;
					if (dugum_yeri > son_yer) dugum_yeri = son_yer;
				}
				break;

			case 'a':
				silinecek_var = false;
				silinecek_dugum = NULL;
				if (b != 1) {
					b -= 8;
					s = b + 7;
				}
				break;

			case 'p':
				silinecek_var = false;
				silinecek_dugum = NULL;
				yl->sil(yl->n_inci_dugum(b + dugum_yeri - 1));
				boyut = yl->boyut;
				if (b > yl->boyut)  b = b - 8;
				if (boyut < s) s = boyut;
				son_yer = s % 8;
				if (son_yer == 0) son_yer = 8;
				if (dugum_yeri > son_yer) dugum_yeri = son_yer;
				break;
		
			case 'k':
				if (silinecek_var) {
					yl->n_inci_dugum(b + dugum_yeri - 1)->sl->sil(silinecek_dugum);
					silinecek_var = false;
					silinecek_dugum = NULL;
					if (yl->n_inci_dugum(b + dugum_yeri - 1)->sl->eleman_sayisi == 0) {
						yl->sil(yl->n_inci_dugum(b + dugum_yeri - 1));
						boyut = yl->boyut;
						if (b > yl->boyut)  b = b - 8;
						if (boyut < s) s = boyut;
						son_yer = s % 8;
						if (son_yer == 0) son_yer = 8;
						if (dugum_yeri > son_yer) dugum_yeri = son_yer;
					}
				} else {
					silinecek_dugum = yl->n_inci_dugum(b + dugum_yeri - 1)->sl->rastgele_dugum_sec();
					silinecek_var = true;
				}
				break;
		}
		yazdir_YoneticiListesi(yl, b, s);
		yazdir_SatirListesi(yl->n_inci_dugum(b + dugum_yeri - 1)->sl, dugum_yeri, silinecek_dugum);
	}
	
	return 0;
}

YoneticiListesi* dosyadan_YoneticiListesi() {
	YoneticiListesi* yl = new YoneticiListesi();
	ifstream dosya("veriler.txt");
	string satir;
	while(getline(dosya, satir)) {
		SatirListesi* sl = satirdan_SatirListesi(satir);
		yl->ekle(sl);
	}
	return yl;
}

SatirListesi* satirdan_SatirListesi(string satir) {
	SatirListesi* sl = new SatirListesi();
	string yedek;
	stringstream ss(satir);
	while(getline(ss, yedek, ' ')) {
		int sayi = atoi(yedek.c_str());
		sl->ekle(sayi);
	};
	return sl;
};

void yazdir_YoneticiListesi(YoneticiListesi* yl, int b, int s) {
	SatirListesiDugum* sld = yl->ilk;
	system("cls");
	for (int i = 1; i < b; i++) {
		sld = sld->sonraki;
	}

	SatirListesiDugum* tmp;

	if (yl->ilk == sld) {
		cout << "ilk" << setw(100) << " " << "--->" << endl;
	} else {
		cout << "<--" << setw(100) << " " << "--->" << endl;
	}

	tmp = sld;
	for (int i = b; i <= s; i++) {
		cout << " " << tmp << " ";
		if (i != s) cout << "    "; 
		tmp = tmp->sonraki;
	}
	cout << endl;

	tmp = sld;
	for (int i = b; i <= s; i++) {
		cout << "----------";
		if (i != s) cout << "    "; 
		tmp = tmp->sonraki;
	}
	cout << endl;

	tmp = sld;
	for (int i = b; i <= s; i++) {
		cout << "|" << setfill('0') << setw(8) << tmp->onceki << setfill(' ') << "|";
		if (i != s) cout << "    "; 
		tmp = tmp->sonraki;
	}
	cout << endl;

	tmp = sld;
	for (int i = b; i <= s; i++) {
		cout << "----------";
		if (i != s) cout << "    "; 
		tmp = tmp->sonraki;
	}
	cout << endl;

	tmp = sld;
	for (int i = b; i <= s; i++) {
		cout << "|" << setw(8) << tmp->sl->ortalamayi_hesapla() << "|";
		if (i != s) cout << "    "; 
		tmp = tmp->sonraki;
	}
	cout << endl;

	tmp = sld;
	for (int i = b; i <= s; i++) {
		cout << "----------";
		if (i != s) cout << "    "; 
		tmp = tmp->sonraki;
	}
	cout << endl;

	tmp = sld;
	for (int i = b; i <= s; i++) {
		cout << "|" << setfill('0') << setw(8) << tmp->sonraki << setfill(' ') << "|";
		if (i != s) cout << "    "; 
		tmp = tmp->sonraki;
	}
	cout << endl;


	tmp = sld;
	for (int i = b; i <= s; i++) {
		cout << "----------";
		if (i != s) cout << "    "; 
		tmp = tmp->sonraki;
	}
	cout << endl;
}

void yazdir_SatirListesi(SatirListesi* sl, int yer, Dugum* silinecek) {
	Dugum* d = sl->ilk;
	int kaydirma = 14 * (yer - 1);
	string silinecek_msg = "";
	cout << endl;
	cout << setw(kaydirma) << "" << "^^^^^^^^^^" << endl;
	while (d != NULL) {
		if (d == silinecek) {
			silinecek_msg = "      <=== silinecek secili";
		} else {
			silinecek_msg = "";
		}
		cout << setw(kaydirma) << "" << " " << d << " " << endl;
		cout << setw(kaydirma) << "" << "----------" << endl;
		cout << setw(kaydirma) << "" << "|" << setw(5) << d->deger << "   |" << endl;
		cout << setw(kaydirma) << "" << "----------" << silinecek_msg << endl;
		cout << setw(kaydirma) << "" << "|" << setfill('0') << setw(8) << d->sonraki << setfill(' ') << "|" << endl;
		cout << setw(kaydirma) << "" << "----------" << endl;
		cout << endl;
		d = d->sonraki;
	}
}

